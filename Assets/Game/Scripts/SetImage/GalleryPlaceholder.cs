using UnityEngine;

namespace Assets.Game.Scripts.SetImage
{
    public class GalleryPlaceholder : MonoBehaviour
    {
        [SerializeField] private GameObject _gallaryElement;

        private void Start()
        {
            CreateElements();
        }

        private async void CreateElements()
        {
            GameObject newElement;
            for (int i = 1; i <= Constans.GallaryImageCount; i++)
            {
                newElement = Instantiate(_gallaryElement);
                newElement.GetComponent<RectTransform>().SetParent(transform, false);

                if (newElement.TryGetComponent(out DownloadAnimation animation))
                    animation.StartAnimation();

                await newElement.GetComponent<URlSpriteInstaller>().SetSprite(Constans.GallaryImageUrl + i + ".jpg");

                animation?.StopAnimation();
            }
        }
    }
}