using AI.Enemy;
using ShipBase;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class EngageState : EnemyBaseState
    {
        public override void Attack(Ship target)
        {
            base.Attack(target);
            if (target != null)
            {
                m_TargetShip = target;
            }          
        }


        private void Update()
        {
            if (m_TargetShip != null)
            {
                SendMovingCommand(m_TargetShip.transform.position, true);
                SendRotationCommand(m_TargetShip.transform.position);
            }
            
        }
    }
}
