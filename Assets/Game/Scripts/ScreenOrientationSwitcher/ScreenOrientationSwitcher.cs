using UnityEngine;

namespace Assets.Game.Scripts.ScreenOrientationSwitcher
{
    public class ScreenOrientationSwitcher: MonoBehaviour
    {
        public bool allowPortrait = true;
        public bool allowPortraitUpsideDown = false;
        public bool allowLandscapeLeft = true;
        public bool allowLandscapeRight = true;

        private void Start()
        {
            SetAllowedOrientations();
            Screen.orientation = ScreenOrientation.AutoRotation;
        }

        public void SetAllowedOrientations()
        {
            Screen.autorotateToPortrait = allowPortrait || Screen.orientation == ScreenOrientation.Portrait;
            Screen.autorotateToPortraitUpsideDown = allowPortraitUpsideDown || Screen.orientation == ScreenOrientation.PortraitUpsideDown;
            Screen.autorotateToLandscapeLeft = allowLandscapeLeft || Screen.orientation == ScreenOrientation.LandscapeLeft;
            Screen.autorotateToLandscapeRight = allowLandscapeRight || Screen.orientation == ScreenOrientation.LandscapeRight;
        }
    }
}