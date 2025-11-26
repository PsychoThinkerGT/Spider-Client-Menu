using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace StupidTemplate.Patches
{
    internal class Image
    {
        public static Material SpiderImage;

        static Image()
        {
            GameObject runner = new GameObject("ImageLoader");
            Object.DontDestroyOnLoad(runner);
            runner.AddComponent<MonoBehaviourHook>().StartCoroutine(
                LoadImage("https://files.imagetourl.net/uploads/1762642203663-121637d3-2530-4ec2-841c-e2c7301563c6.png", mat => SpiderImage = mat)
            );
        }

        private static IEnumerator LoadImage(string url, System.Action<Material> callback)
        {
            using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(url))
            {
                yield return uwr.SendWebRequest();

                if (uwr.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError($"Image download failed: {uwr.error}");
                    callback?.Invoke(null);
                    yield break;
                }

                Texture2D tex = DownloadHandlerTexture.GetContent(uwr);

                // Find shader safely
                Shader shader = Shader.Find("GorillaTag/UberShader");
                if (shader == null)
                {
                    Debug.LogWarning("UberShader not found, falling back to Standard");
                    shader = Shader.Find("Standard");
                }

                Material mat = new Material(shader);
                mat.mainTexture = tex;
                mat.EnableKeyword("_USE_TEXTURE");

                callback(mat);
            }
        }
    }

    public class MonoBehaviourHook : MonoBehaviour { }
}
