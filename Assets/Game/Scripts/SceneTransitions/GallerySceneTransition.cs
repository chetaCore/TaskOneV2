using Assets.Game.Scripts.Services;
using Assets.Game.Scripts.State;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Game.Scripts.TransferButtons
{
    public class GallerySceneTransition : MonoBehaviour
    {
        [SerializeField] private Button _transitionButton;

        private void Awake()
        {
            _transitionButton.onClick.AddListener(() =>
            {
                Screen.orientation = ScreenOrientation.AutoRotation;
                AllServices.Container.Single<IGameStateMachine>().Enter<LoadLevelState, string>("Gallery");
            });
        }
    }
}