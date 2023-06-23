using Assets.Game.Scripts.Services;
using Assets.Game.Scripts.Services.SwipeSceneLoader;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Game.Scripts.SwipeSceneLoader
{
    public class ButtonSceneChanger : MonoBehaviour, ISceneTransitionManager
    {
        [SerializeField] private Button _changeSceneButton;

        private void Awake()
        {
            _changeSceneButton.onClick.AddListener(СhangeScene);
        }

        private void OnDestroy()
        {
            _changeSceneButton.onClick.RemoveListener(СhangeScene);
        }

        public void СhangeScene()
        {
            AllServices.Container.Single<ISceneTransitionVerificationService>().CheckAndPerformSceneTransition();
        }
    }
}