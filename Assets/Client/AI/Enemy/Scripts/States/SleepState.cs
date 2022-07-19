using AI.Enemy;
using ShipBase;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class SleepState : EnemyBaseState
    {
        public override void Sleep()
        {
            base.Sleep();
            Debug.Log("Do nothing");
        }
    }
}
