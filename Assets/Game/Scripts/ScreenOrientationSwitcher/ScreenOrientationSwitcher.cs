using UnityEngine;

namespace Assets.Game.Scripts.ScreenOrientationSwitcher
{
    public class ScreenOrientationSwitcher : MonoBehaviour
    {
        public Orientations orientations;
        private ScreenOrientation _defaultOrintaton;

        public enum Orientations
        {
            PortraitOrientation,
            LandscapeOrientation,
            AutoOrientation
        }


        private void Start()
        {
            _defaultOrintaton = Screen.orientation;
            Screen.orientation = ScreenOrientation.AutoRotation;

        }

        private void OnDestroy()
        {
            Screen.orientation = _defaultOrintaton;
        }

    
    }
}