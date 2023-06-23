using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Game.Scripts.Services.LoadImageService
{
    public class LoadImageSerivice : ILoadImageSerivice
    {
        public async Task<Sprite> DownloadImageAsync(string imageUrl)
        {
            using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(imageUrl))
            {
                var requestOperation = www.SendWebRequest();

                while (!requestOperation.isDone)
                {
                    await Task.Delay(300);
                }

                if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
                {
                    Debug.Log("Ошибка загрузки картинки: " + www.error);
                    return null;
                }
                else
                {
                    Texture2D texture = DownloadHandlerTexture.GetContent(www);

                    Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);

                    return sprite;
                }
            }
        }
    }
}