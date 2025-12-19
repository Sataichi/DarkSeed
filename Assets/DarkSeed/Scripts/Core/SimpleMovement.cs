using UnityEngine;
using UnityEngine.InputSystem;

namespace DarkSeed.Core
{
    public class SimpleMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _speed;

        private InputAction _moveAction;

        private void Awake()
        {
            _moveAction = InputSystem.actions.FindAction("Move");
        }

        private void FixedUpdate()
        {
            var direction = _moveAction.ReadValue<Vector2>();

            var endPosition = new Vector3(
                _rigidbody.position.x + direction.x * _speed * Time.fixedDeltaTime,
                _rigidbody.position.y,
                _rigidbody.position.z + direction.y * _speed * Time.fixedDeltaTime);

            _rigidbody.MovePosition(endPosition);

            var endRotation = Quaternion.LookRotation(new Vector3(direction.normalized.x, 0, direction.normalized.y),
                Vector3.up);
            
            _rigidbody.MoveRotation(endRotation);
        }
    }
}