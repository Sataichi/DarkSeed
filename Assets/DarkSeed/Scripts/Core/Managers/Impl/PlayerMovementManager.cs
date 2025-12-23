using DarkSeed.Core.Characters;
using DarkSeed.Core.Controls;
using DarkSeed.Core.GameStates;
using DarkSeed.Utils.Constants;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace DarkSeed.Core.Managers.Impl
{
    public class PlayerMovementManager : IMovementController, IInitializable, IFixedTickable, IGamePausable
    {
        private static readonly int Speed = Animator.StringToHash("Speed");
        private InputAction _moveAction;

        private Rigidbody _playerRigidbody;
        private Movement _movement;
        private BodyRotation _bodyRotation;

        private Animator _animator;

        private int _stateSemaphore;

        public bool IsGamePaused { get; set; }

        public bool IsMovementEnabled => _stateSemaphore == 0;

        public PlayerMovementManager(Player player, [Inject(Id = PlayerIDs.Movement)] Movement movement,
            [Inject(Id = PlayerIDs.BodyRotation)] BodyRotation bodyRotation)
        {
            _playerRigidbody = player.gameObject.GetComponent<Rigidbody>();
            _movement = movement;
            _bodyRotation = bodyRotation;
            _stateSemaphore = 0;

            _animator = player.gameObject.GetComponentInChildren<Animator>();
        }

        public void EnableMovementRequest()
        {
            if (_stateSemaphore == 0)
                return;

            _stateSemaphore--;
        }

        public void DisableMovementRequest()
        {
            _stateSemaphore++;
        }

        public void Initialize()
        {
            _moveAction = InputSystem.actions.FindAction("Move");
            _stateSemaphore = 0;
        }

        public void FixedTick()
        {
            if (IsGamePaused)
                return;

            if (!IsMovementEnabled)
                return;

            var direction = _moveAction.ReadValue<Vector2>();

            _animator.SetFloat(Speed, direction.magnitude);

            if (direction == Vector2.zero)
                return;

            _movement.MovePerTick(_playerRigidbody, direction);
            _bodyRotation.RotateBody(_playerRigidbody, direction);
        }
    }
}