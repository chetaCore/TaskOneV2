using Assets.Game.Scripts.State;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Game.Scripts.Services.SwipeSceneLoader
{
    public class SwipeSceneLoader : MonoBehaviour, ISwipeSceneLoader
    {
        private void Update()
        {
            СhangeViewingScene();
        }

        

        public void СhangeViewingScene()
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
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
            else if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);
                    if (touch.phase == TouchPhase.Ended && touch.deltaPosition.x < 0)
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
        }
    }
}