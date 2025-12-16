using DarkSeed.Core.Managers;
using Zenject;

namespace DarkSeed.Core.Installer
{
    public class GameSceneContextInstaller : MonoInstaller<GameSceneContextInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<GameStateManager>().AsSingle();
        }
    }
}