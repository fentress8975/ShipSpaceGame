using ShipBase;
using UnityEngine;

namespace AI
{
    public class EngageState : EnemyBaseState
    {
        [SerializeField]
        private float m_fSpeedPenalty = 0.4f;
        [SerializeField]
        private float m_fAttackDistance = 10f;
        [SerializeField]
        private float m_fStopDistance = 5f;


        public override void Attack(Ship target)
        {
            base.Attack(target);
            if (target != null)
            {
                m_TargetShip = target;
            }
        }


        private bool isAttackDistance()
        {
            float distance = Vector3.Distance(m_TargetShip.transform.position, m_IShipInformation.m_ShipTransform.position);
            if (distance < m_fAttackDistance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool isStopDistance()
        {
            float distance = Vector3.Distance(m_TargetShip.transform.position, m_IShipInformation.m_ShipTransform.position);
            if (distance < m_fStopDistance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void tryFireWeapon()
        {
            if (isLookingOnTarget())
            {
                Fire(true);
            }
            else
            {
                Fire(false);
            }
        }

        private void GetInFireRange()
        {
            if (isAttackDistance())
            {
                if (isStopDistance())
                {
                    SendMovingCommand(false);
                    SendRotationCommand(m_TargetShip.transform.position);
                    tryFireWeapon();
                }
                else
                {
                    SendMovingCommand(m_TargetShip.transform.position, m_fSpeedPenalty, false);
                    SendRotationCommand(m_TargetShip.transform.position);
                    tryFireWeapon();
                }
            }
            else
            {
                SendMovingCommand(m_TargetShip.transform.position, true);
                SendRotationCommand(m_TargetShip.transform.position);
            }
        }


        private void Update()
        {
            if (m_TargetShip != null)
            {
                GetInFireRange();
            }
        }
    }
}
