using UnityEngine;

namespace DarkSeed.Core.Data.Control
{
    [CreateAssetMenu(fileName = "BodyRotationData", menuName = "Scriptable Objects/BodyRotationData")]
    public class BodyRotationScriptable : ScriptableObject
    {
        [SerializeField] private float _rotationSpeed;

        public float RotationSpeed => _rotationSpeed;
    }
}