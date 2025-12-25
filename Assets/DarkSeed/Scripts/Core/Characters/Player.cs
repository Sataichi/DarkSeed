using System;
using UnityEngine;

namespace DarkSeed.Core.Characters
{
    public class Player : MonoBehaviour
    {
        public Action CollisionWithObstacleOccured;

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Obstacle"))
                CollisionWithObstacleOccured?.Invoke();
        }

        private void OnCollisionStay(Collision other)
        {
            if (other.gameObject.CompareTag("Obstacle"))
                CollisionWithObstacleOccured?.Invoke();
        }
    }
}