using System;
using System.Collections;
using DarkSeed.Core.Data.Control;
using DarkSeed.Utils.Constants;
using UnityEngine;
using Zenject;

namespace DarkSeed.Core.Controls.Dashes
{
    public class ClassicVelocityDash : Dash
    {
        private WaitForFixedUpdate _waitForFixedUpdate;

        public ClassicVelocityDash([Inject(Id = PlayerIDs.DashData)] DashScriptable data) : base(data)
        {
            _waitForFixedUpdate = new WaitForFixedUpdate();
            IsInterrupted = false;
        }

        public override IEnumerator StartDash(Rigidbody rb, Action<float> callback)
        {
            var direction = rb.transform.forward;
            var movementSpace = Vector3.right + Vector3.forward;

            for (var currentDuration = 0f; currentDuration < _dashDuration; currentDuration += Time.fixedDeltaTime)
            {
                if (IsInterrupted)
                    break;

                var dashResultPower =
                    _dashPower * _dashVelocityCurve.Evaluate(Mathf.InverseLerp(0, _dashDuration, currentDuration));

                rb.linearVelocity = Vector3.Scale(direction.normalized * dashResultPower, movementSpace);

                yield return _waitForFixedUpdate;
            }

            callback.Invoke(_dashCooldown);
            ResetInterruption();
        }
    }
}