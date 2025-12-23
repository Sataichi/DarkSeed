using DarkSeed.Core.Data;
using DarkSeed.Core.Data.Control;
using UnityEngine;
using Zenject;

namespace DarkSeed.Core.Controls
{
    public abstract class Movement
    {
        protected float _moveSpeed;

        [Inject]
        public Movement(MovementScriptable movementScriptable)
        {
            _moveSpeed = movementScriptable.MovementSpeed;
        }
        
        public abstract void MovePerTick(Rigidbody rb, Vector2 direction);
    }
}