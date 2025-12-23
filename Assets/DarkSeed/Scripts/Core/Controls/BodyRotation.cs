using DarkSeed.Core.Data;
using DarkSeed.Core.Data.Control;
using UnityEngine;

namespace DarkSeed.Core.Controls
{
    public abstract class BodyRotation
    {
        protected float _rotationSpeed;
        
        public BodyRotation(BodyRotationScriptable bodyRotationScriptable)
        {
            _rotationSpeed = bodyRotationScriptable.RotationSpeed;
        }
        
        public abstract void RotateBody(Rigidbody rb, Vector2 direction);
    }
}