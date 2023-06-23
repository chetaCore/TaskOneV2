using Assets.Game.Scripts.State;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Game.Scripts.Services
{
    public class SceneTransitionVerificationService : ISceneTransitionVerificationService
    {
        public void CheckAndPerformSceneTransition()
        {
            switch (SceneManager.GetActiveScene().name)
            {
                case "ViewingGalleryImage":
                    AllServices.Container.Single<IGameStateMachine>().Enter<LoadLevelState, string>("Gallery");
                    break;

                case "Gallery":
                    AllServices.Container.Single<IGameStateMachine>().Enter<LoadLevelState, string>("Main");
                    break;

                default:
                    break;
            }
        }
    }
}