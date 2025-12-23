using System;
using System.Collections;
using DarkSeed.Core.Characters;
using DarkSeed.Core.Controls;
using DarkSeed.Core.GameStates;
using DarkSeed.Utils.Constants;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace DarkSeed.Core.Managers
{
    public class PlayerDashManager : IInitializable, IDisposable, IGamePausable
    {
        private static readonly int DashProperty = Animator.StringToHash("Dashing");

        private IMovementController _playerMovementController;
        private CoroutineHolder _coroutineHolder;
        private Rigidbody _playerRigidbody;
        private Animator _playerAnimator;
        private Dash _dash;

        private InputAction _dashAction;

        private bool _isDashing;
        private bool _isDashAvailable;

        public bool IsGamePaused { get; set; }

        public PlayerDashManager(IMovementController playerMovementController,
            [Inject(Id = SceneIDs.CoroutineHolder)] CoroutineHolder coroutineHolder, Player player,
            [Inject(Id = PlayerIDs.Dash)] Dash dash)
        {
            _playerMovementController = playerMovementController;
            _coroutineHolder = coroutineHolder;
            _playerRigidbody = player.GetComponent<Rigidbody>();
            _playerAnimator = player.GetComponentInChildren<Animator>();
            _dash = dash;

            _isDashAvailable = true;
        }

        public void Initialize()
        {
            _dashAction = InputSystem.actions.FindAction("Dash");
            _dashAction.performed += DoDash;
        }

        private void DoDash(InputAction.CallbackContext ctx)
        {
            if (!_isDashAvailable || !_playerMovementController.IsMovementEnabled)
                return;

            _isDashAvailable = false;
            _isDashing = true;
            _playerAnimator.SetBool(DashProperty, _isDashing);

            _playerMovementController.DisableMovementRequest();

            _coroutineHolder.StartCoroutine(_dash.StartDash(_playerRigidbody, DoDashCallback));
        }

        private void DoDashCallback(float dashCooldown)
        {
            _isDashing = false;
            _playerAnimator.SetBool(DashProperty, _isDashing);

            _playerMovementController.EnableMovementRequest();

            _coroutineHolder.StartCoroutine(DashCooldown(dashCooldown));
        }

        private IEnumerator DashCooldown(float cooldown)
        {
            while (cooldown > 0.001f)
            {
                cooldown = Mathf.Clamp(cooldown - Time.deltaTime, 0, cooldown);
                yield return null;
            }

            _isDashAvailable = true;
        }

        public void Dispose()
        {
            _dashAction.performed -= DoDash;
        }
    }
}