using System;
using System.Collections;
using DarkSeed.Core.Data;
using DarkSeed.Core.Data.Control;
using DarkSeed.Utils.Constants;
using UnityEngine;
using Zenject;

namespace DarkSeed.Core.Controls.Dashes
{
    public class ClassicDash : Dash
    {
        private readonly WaitForSeconds _cachedWaitForSeconds;

        public ClassicDash([Inject(Id = PlayerIDs.DashData)] DashScriptable data) : base(data)
        {
            _cachedWaitForSeconds = new WaitForSeconds(_dashDuration);
        }

        public override IEnumerator StartDash(Rigidbody rb, Action<float> callback)
        {
            var direction = rb.transform.forward;

            rb.AddForce(Vector3.Scale(direction.normalized * _dashPower, Vector3.right + Vector3.forward),
                ForceMode.Impulse);

            yield return _cachedWaitForSeconds;

            rb.linearVelocity = Vector3.zero;
            callback.Invoke(_dashCooldown);
        }
    }
}