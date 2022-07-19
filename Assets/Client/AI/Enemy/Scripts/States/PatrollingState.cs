using AI.Enemy;
using ShipBase;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class PatrollingState : EnemyBaseState
    {
        public override void Patrol(List<Vector3> route)
        {
            base.Patrol(route);
            Debug.Log("Doing my Patrol Job");
        }
    }
}
