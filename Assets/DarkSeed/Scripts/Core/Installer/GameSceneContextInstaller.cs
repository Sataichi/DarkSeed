using UnityEngine;
using Zenject;
using DarkSeed.Core.Characters;
using DarkSeed.Core.Data;
using DarkSeed.Core.Data.Control;
using DarkSeed.Core.Managers;
using DarkSeed.Utils.Constants;
using Unity.Cinemachine;

namespace DarkSeed.Core.Installer
{
    public class GameSceneContextInstaller : MonoInstaller
    {
        [Header("Player Settings")]
        [SerializeField] private Player _playerPrefab;
        [SerializeField] private CinemachineCamera _playerCameraPrefab;
        [SerializeField] private MovementScriptable _playerMovementData;
        [SerializeField] private BodyRotationScriptable _playerBodyRotationData;
        [SerializeField] private DashScriptable _playerDashData;

        public override void InstallBindings()
        {
            BindSceneCoroutineHolder();

            BindPlayer();

            BindGameStateManager();
        }

        private void BindGameStateManager()
        {
            Container.Bind<GameStateManager>()
                .FromNewComponentOnNewGameObject()
                .UnderTransformGroup(TransformGroups.Managers)
                .AsSingle()
                .NonLazy();
        }

        private void BindPlayer()
        {
            Container.Bind<MovementScriptable>()
                .WithId(PlayerIDs.MovementData)
                .FromInstance(_playerMovementData)
                .AsSingle();

            Container.Bind<BodyRotationScriptable>()
                .WithId(PlayerIDs.BodyRotationData)
                .FromInstance(_playerBodyRotationData)
                .AsSingle();

            Container.Bind<DashScriptable>()
                .WithId(PlayerIDs.DashData)
                .FromInstance(_playerDashData)
                .AsSingle();

            Container.Bind<CinemachineCamera>()
                .WithId(PlayerIDs.Camera)
                .FromComponentInNewPrefab(_playerCameraPrefab)
                .UnderTransformGroup(TransformGroups.Cameras)
                .AsSingle()
                .NonLazy();

            Container.Bind<Player>()
                .FromComponentInNewPrefab(_playerPrefab)
                .UnderTransformGroup(TransformGroups.Players)
                .AsSingle()
                .NonLazy();
        }

        private void BindSceneCoroutineHolder()
        {
            Container.Bind<CoroutineHolder>()
                .WithId(SceneIDs.CoroutineHolder)
                .FromNewComponentOnNewGameObject()
                .UnderTransformGroup(TransformGroups.Managers)
                .AsSingle()
                .NonLazy();
        }
    }
}