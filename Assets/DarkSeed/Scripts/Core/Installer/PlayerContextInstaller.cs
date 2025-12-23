using System;
using System.Linq;
using Zenject;
using DarkSeed.Core.Controls;
using DarkSeed.Core.Controls.BodyRotations;
using DarkSeed.Core.Controls.Dashes;
using DarkSeed.Core.Controls.Movements;
using DarkSeed.Core.Managers;
using DarkSeed.Core.Managers.Impl;
using DarkSeed.Utils.Constants;
using UnityEngine;

namespace DarkSeed.Core.Installer
{
    public class PlayerContextInstaller : MonoInstaller<PlayerContextInstaller>
    {
        public override void InstallBindings()
        {
            BindPlayerCameraWrapper();
            BindPlayerMovement();
            BindPlayerDash();
        }

        private void BindPlayerCameraWrapper()
        {
            Container.BindInterfacesTo<PlayerCameraWrapper>()
                .AsSingle();
        }

        private void BindPlayerMovement()
        {
            Container.Bind<Movement>()
                .WithId(PlayerIDs.Movement)
                .To<PlayerMovement>()
                .AsSingle()
                .NonLazy();

            Container.Bind<BodyRotation>()
                .WithId(PlayerIDs.BodyRotation)
                .To<PlayerSmoothBodyRotation>()
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesAndSelfTo<PlayerMovementManager>()
                .AsSingle()
                .NonLazy();
        }

        private void BindPlayerDash()
        {
            Container.Bind<Dash>()
                .WithId(PlayerIDs.Dash)
                .To<ClassicVelocityDash>()
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesAndSelfTo<PlayerDashManager>()
                .AsSingle()
                .NonLazy();
        }
    }
}