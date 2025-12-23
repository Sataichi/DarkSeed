using UnityEngine;

namespace DarkSeed.Core.Data.Control
{
    [CreateAssetMenu(fileName = "DashData", menuName = "Scriptable Objects/DashData")]
    public class DashScriptable : ScriptableObject
    {
        [SerializeField] private float _dashDuration;
        [SerializeField] private float _dashPower;
        [SerializeField] private float _dashCooldown;
        [SerializeField] private AnimationCurve dashVelocityCurve;

        public float DashDuration => _dashDuration;
        public float DashPower => _dashPower;
        public float DashCooldown => _dashCooldown;
        public AnimationCurve DashVelocityCurve => dashVelocityCurve;
    }
}