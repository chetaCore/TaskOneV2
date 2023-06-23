using Assets.Game.Scripts.Services;
using Assets.Game.Scripts.Services.LoadImageService;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Game.Scripts.SetImage
{
    public class URlSpriteInstaller : SpriteInstaller
    {
        private bool _isReady = false;

        public bool IsReady { get => _isReady;}

        public override async Task<bool> SetSprite(string url)
        {
            Sprite downloadedSprite = await AllServices.Container.Single<ILoadImageSerivice>().DownloadImageAsync(url);
            if (downloadedSprite != null)
            {
                _image.sprite = downloadedSprite;

                _isReady = true;
                return true;
            }
            else
            {
                _isReady = true;
                return true;
                //_image.sprite = Constans.ErrorImage
            }
        }
    }
}