using System;
using System.Collections;
using DarkSeed.Core.Data.Control;
using UnityEngine;

namespace DarkSeed.Core.Controls
{
    public abstract class Dash
    {
        protected float _dashDuration;
        protected float _dashPower;
        protected float _dashCooldown;
        protected AnimationCurve _dashVelocityCurve;

        public Dash(DashScriptable data)
        {
            _dashDuration = data.DashDuration;
            _dashPower = data.DashPower;
            _dashCooldown = data.DashCooldown;
            _dashVelocityCurve = data.DashVelocityCurve;
        }

        public abstract IEnumerator StartDash(Rigidbody rb, Action<float> callback);
    }
}