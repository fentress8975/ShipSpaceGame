using AI.Enemy;
using ShipBase;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class SearchingState : EnemyBaseState
    {
        private Vector3 m_LastPosition;
        [SerializeField]
        private float m_SearchingSpeed = 0.5f;
        [SerializeField]
        private float m_SearchingDistance = 5f;


        public override void Search(Vector3 lastKnowPosition)
        {
            base.Search(lastKnowPosition);
            Debug.Log("Start Searching!");
            m_LastPosition = lastKnowPosition;
        }


        private float CheckDistanceToLastPosition()
        {
            float distance = Vector3.Distance(m_IShipInformation.m_ShipTransform.position, m_LastPosition);
            return distance;
        }

        private void Update()
        {
            if(m_LastPosition == null)
            {
                m_ISwitcher.StateSwitcher<SleepState>();
            }
            else if (CheckDistanceToLastPosition() > m_SearchingDistance)
            {
                SendMovingCommand(m_LastPosition, m_SearchingSpeed, true);
                SendRotationCommand(m_LastPosition);
            }
            else
            {
                m_ISwitcher.StateSwitcher<SleepState>();
            }
            
        }
    }
}
