﻿using Assets.Game.Scripts.Services;
using Assets.Game.Scripts.Services.LoadImageService;
using Assets.Game.Scripts.Services.SceneTransitionVerificationService;

namespace Assets.Game.Scripts.State
{
    public class BootstrapState : IState
    {
        private const string Boot = "Boot";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _services;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, AllServices services)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _services = services;

            RegisterServices();
        }

        public void Enter()
        {
            _sceneLoader.Load(Boot, onLoaded: EnterLoadLevel);
        }

        public void Exit()
        {
            //throw new NotImplementedException();
        }

        private void EnterLoadLevel()
        {
            _stateMachine.Enter<LoadLevelState, string>("main");
        }

        private void RegisterServices()
        {
            _services.RegisterSingle<IGameStateMachine>(_stateMachine);
            _services.RegisterSingle<ILoadImageSerivice>(new LoadImageSerivice());
            _services.RegisterSingle<GetSelectedGalleryImageService>(new GetSelectedGalleryImageService());
            _services.RegisterSingle<ISceneTransitionVerificationService>(new SceneTransitionVerificationService());
        }
    }
}