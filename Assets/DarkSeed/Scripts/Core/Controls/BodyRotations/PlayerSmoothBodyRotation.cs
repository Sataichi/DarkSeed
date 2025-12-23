using DarkSeed.Core.Data;
using DarkSeed.Core.Data.Control;
using DarkSeed.Utils.Constants;
using UnityEngine;
using Zenject;

namespace DarkSeed.Core.Controls.BodyRotations
{
    public class PlayerSmoothBodyRotation : BodyRotation
    {
        public PlayerSmoothBodyRotation(
            [Inject(Id = PlayerIDs.BodyRotationData)] BodyRotationScriptable bodyRotationScriptable) : base(
            bodyRotationScriptable)
        {
        }

        public override void RotateBody(Rigidbody rb, Vector2 direction)
        {
            var endRotation = Quaternion.LookRotation(new Vector3(direction.normalized.x, 0, direction.normalized.y),
                Vector3.up);

            rb.MoveRotation(Quaternion.Lerp(rb.rotation, endRotation, Time.fixedDeltaTime * _rotationSpeed));
        }
    }
}