using ShipBase;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class ChaseState : EnemyBaseState
    {
        [SerializeField]
        private float m_ChaseDistance = 20f;
        [SerializeField]
        private float m_PenaltySpeed = 0.3f;

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

        //private bool CheckTargetDistance()
        //{
        //    float distance = Vector3.Distance(m_IShipInformation.m_ShipPosition, m_TargetShip.transform.position);
        //    return distance >= m_ChaseDistance ? true : false;
        //}



        private void Update()
        {
            if (isLookingOnTarget())
            {
                SendMovingCommand(m_TargetShip.transform.position, true);
            }
            else
            {
                SendMovingCommand(m_TargetShip.transform.position, m_PenaltySpeed, true);
            }

            SendRotationCommand(m_TargetShip.transform.position);
        }
    }
}
