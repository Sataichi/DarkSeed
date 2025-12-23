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
        public ClassicVelocityDash([Inject(Id = PlayerIDs.DashData)] DashScriptable data) : base(data)
        {
        }

        public override IEnumerator StartDash(Rigidbody rb, Action<float> callback)
        {
            var direction = rb.transform.forward;
            var movementSpace = Vector3.right + Vector3.forward;

            for (var currentDuration = 0f; currentDuration < _dashDuration; currentDuration += Time.deltaTime)
            {
                var dashResultPower =
                    _dashPower * _dashVelocityCurve.Evaluate(Mathf.InverseLerp(0, _dashDuration, currentDuration));

                rb.linearVelocity = Vector3.Scale(
                    direction.normalized * dashResultPower,
                    movementSpace);

                yield return null;
            }

            callback.Invoke(_dashCooldown);
        }
    }
}