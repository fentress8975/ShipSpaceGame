using AI.Enemy;
using ShipBase;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class RetreatState : EnemyBaseState
    {
        public override void Retreat(Ship danger)
        {
            base.Retreat(danger);
            Debug.Log("Oh no, escape, QUICK!");
        }
    }
}
