using DarkSeed.Core.Data;
using DarkSeed.Core.Data.Control;
using DarkSeed.Utils.Constants;
using UnityEngine;
using Zenject;

namespace DarkSeed.Core.Controls.Movements
{
    public class PlayerMovement : Movement
    {
        public PlayerMovement([Inject(Id = PlayerIDs.MovementData)] MovementScriptable movementScriptable) : base(
            movementScriptable)
        {
        }

        public override void MovePerTick(Rigidbody rb, Vector2 direction)
        {
            var endPosition = new Vector3(
                rb.position.x + direction.x * _moveSpeed * Time.fixedDeltaTime,
                rb.position.y,
                rb.position.z + direction.y * _moveSpeed * Time.fixedDeltaTime);

            rb.MovePosition(endPosition);
        }
    }
}