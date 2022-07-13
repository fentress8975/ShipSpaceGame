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
            if (target != null)
            {
                m_TargetShip = target;
            }          
        }


        public override void Chase(Ship target)
        {
            m_ISwitcher.StateSwitcher<ChaseState>();
        }

        public override void Die()
        {
            throw new System.NotImplementedException();
        }

        public override void Patrol(List<Vector3> route)
        {
            throw new System.NotImplementedException();
        }

        public override void Retreat(Ship danger)
        {
            throw new System.NotImplementedException();
        }

        public override void Search(Vector3 lastKnowPosition)
        {
            m_ISwitcher.StateSwitcher<SearchingState>();
        }

        public override void Sleep()
        {
            m_ISwitcher.StateSwitcher<SleepState>();
        }


        private void Update()
        {
            if (m_TargetShip != null)
            {
                SendTargetPosition(m_TargetShip.transform.position, true);
                SendRotationPosition(m_TargetShip.transform.position);
            }
            
        }
    }
}
