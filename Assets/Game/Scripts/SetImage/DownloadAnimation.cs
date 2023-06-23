using DG.Tweening;
using UnityEngine;

namespace Assets.Game.Scripts.SetImage
{
    public class DownloadAnimation: MonoBehaviour
    {
        [SerializeField]private Transform _spriteTransform;
        [SerializeField] private float _rotationDuration = 1f;
        
        private Sequence _animSequence;

        public void StartAnimation()
        {
            _animSequence = DOTween.Sequence();
            _animSequence.Append(_spriteTransform.DORotate(new Vector3(0f, 0f, 360f), _rotationDuration, RotateMode.FastBeyond360)
            .SetLoops(-1, LoopType.Restart));

            _animSequence.Play();
        }

        public void StopAnimation()
        {
            _animSequence.Kill();
            _spriteTransform.rotation = Quaternion.identity;
        }

        private void OnDestroy()
        {
            _animSequence.Kill();
        }
    }
}