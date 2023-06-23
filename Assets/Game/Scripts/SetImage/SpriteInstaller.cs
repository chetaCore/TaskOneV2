using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Game.Scripts.SetImage
{
    public class SpriteInstaller: MonoBehaviour
    {
        [SerializeField] protected Image _image;

        public virtual Task<bool> SetSprite(string url) { return Task.FromResult(true); }

        public virtual void SetSprite(Sprite sprite) { }
    }
}