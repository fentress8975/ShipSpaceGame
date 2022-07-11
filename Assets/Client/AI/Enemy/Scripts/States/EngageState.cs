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
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }


        private void Update()
        {
            if (m_TargetShip != null)
            {
                GetSpeedVector(m_TargetShip.transform.position, true);
                GetRotationVector(m_TargetShip.transform.position);
            }
            
        }
    }
}
