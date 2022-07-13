using AI.Enemy;
using ShipBase;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class ChaseState : EnemyBaseState
    {
        public override void Attack(Ship target)
        {
            m_ISwitcher.StateSwitcher<EngageState>();
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
            throw new System.NotImplementedException();
        }

        public override void Sleep()
        {
            m_ISwitcher.StateSwitcher<SleepState>();
        }

        private void Update()
        {
            SendTargetPosition(m_TargetShip.transform.position, true);
            SendRotationPosition(m_TargetShip.transform.position);
        }
    }
}
