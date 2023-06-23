using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Game.Scripts.Services.LoadImageService
{
    public interface ILoadImageSerivice: IService
    {
        Task<Sprite> DownloadImageAsync(string imageUrl);
    }
}