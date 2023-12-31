﻿using UnityEngine;

namespace Assets.Game.Scripts.Services.SwipeSceneLoader
{
    public class SwipeSceneChanger : MonoBehaviour, ISceneTransitionManager
    {
        private ISceneTransitionVerificationService _sceneTransition;

        private void Awake()
        {
            _sceneTransition = AllServices.Container.Single<ISceneTransitionVerificationService>();
        }

        private void Update()
        {
            СhangeScene();
        }

        public void СhangeScene()
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    _sceneTransition.CheckAndPerformSceneTransition();
                }
            }
            else if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);
                    if (touch.phase == TouchPhase.Ended && touch.deltaPosition.x < 0)
                    {
                        _sceneTransition.CheckAndPerformSceneTransition();
                    }
                }
            }
            else if (Input.GetKeyUp(KeyCode.Escape))
            {
                _sceneTransition.CheckAndPerformSceneTransition();
            }
        }
    }
}