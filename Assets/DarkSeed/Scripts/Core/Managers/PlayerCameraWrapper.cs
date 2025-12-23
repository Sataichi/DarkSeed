using Unity.Cinemachine;
using Zenject;
using DarkSeed.Core.Characters;
using DarkSeed.Utils.Constants;

namespace DarkSeed.Core.Managers
{
    public class PlayerCameraWrapper : IInitializable
    {
        private Player _player;
        private CinemachineCamera _camera;
        
        public PlayerCameraWrapper(Player player, [Inject(Id = PlayerIDs.Camera)] CinemachineCamera camera)
        {
            _player = player;
            _camera = camera;
        }

        public void Initialize()
        {
            _camera.LookAt = _player.transform;
            _camera.Follow = _player.transform;
        }
    }
}