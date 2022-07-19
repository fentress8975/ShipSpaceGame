using AI.Enemy;
using ShipBase;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class DeathState : EnemyBaseState
    { 
        public override void Die()
        {
            base.Die();
            Debug.Log("Oh no, im dead...");
        }
    }
}