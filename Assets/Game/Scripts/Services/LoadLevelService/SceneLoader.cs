using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Game.Scripts.State
{
    public class SceneLoader
    {
        private readonly ICorutineRunner _coruoutineRunner;

        public SceneLoader(ICorutineRunner coruoutineRunner) =>
            _coruoutineRunner = coruoutineRunner;

        public void Load(String name, Action onLoaded = null, PopupController popup = null) =>
            _coruoutineRunner.StartCoroutine(LoadScene(name, onLoaded,popup));

        public IEnumerator LoadScene(String nextScene, Action onLoaded = null, PopupController popup = null)
        {
            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(nextScene, LoadSceneMode.Single);

            if (popup == null)
            {
                while (!waitNextScene.isDone)
                {
                    yield return null;
                }
            }
            else
            {
                float progress = 0f;
                float loadSpeed = 0.5f;

                while (progress < 1f)
                {
                    progress += loadSpeed * Time.deltaTime;
                    progress = Mathf.Clamp01(progress);

                    popup.ProgressBar.fillAmount = progress;
                    popup.LoadPercentages.text = Math.Round(progress * 100f).ToString() + "%";

                    yield return null;
                }
            }
            onLoaded?.Invoke();
        }
    }
}