using UnityEngine;

namespace DarkSeed.Core.Data.Control
{
    [CreateAssetMenu(fileName = "MovementData", menuName = "Scriptable Objects/MovementData")]
    public class MovementScriptable : ScriptableObject
    {
        [SerializeField] private float _movementSpeed;

        public float MovementSpeed => _movementSpeed;
    }
}