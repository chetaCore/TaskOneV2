using Assets.Game.Scripts.Services;

namespace Assets.Game.Scripts.SetImage
{
    public class ViewingSceneSpriteInstaller : SpriteInstaller
    {
        private void Start()
        {
            _image.sprite = AllServices.Container.Single<GetSelectedGalleryImageService>().CurrentSprite;
        }
    }
}