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

        
        public override void Chase(Ship target)
        {
            base.Chase(target);
            m_TargetShip = target;
        }


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
