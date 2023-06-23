using Assets.Game.Scripts.Services;
using Assets.Game.Scripts.SetImage;
using Assets.Game.Scripts.State;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Game.Scripts.SceneTransitions
{
    public class ViewingTransition : MonoBehaviour
    {
        [SerializeField] private URlSpriteInstaller _installer;

        [SerializeField] private Button _transitionButton;

        private void Awake()
        {
            _transitionButton.onClick.AddListener(() =>
            {
                if (!_installer.IsReady) return;

                AllServices.Container.Single<GetSelectedGalleryImageService>().CurrentSprite = GetComponent<Image>().sprite;

                AllServices.Container.Single<IGameStateMachine>().Enter<LoadLevelState, string>("ViewingGalleryImage");
            });
        }
    }
}