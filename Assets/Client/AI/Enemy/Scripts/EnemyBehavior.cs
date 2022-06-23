using ShipBase;
using System.Collections.Generic;
using UnityEngine;


namespace AI
{
    namespace Enemy
    {
        public class EnemyBehavior : MonoBehaviour
        {
            private EnemyShip m_Ship;
            private Ship m_Target;

            private EnemyBaseState m_CurrentState;
            private List<EnemyBaseState> m_AllStates;


            public void SwitchState<T>(T state) where T : EnemyBaseState
            {
                m_CurrentState.Stop();

                m_CurrentState = state;
                m_CurrentState.Start();
            }


            private void Initialization()
            {
                m_AllStates = new List<EnemyBaseState>();
                {
                    new SleepState(m_Ship);
                    new PatrollingState(m_Ship);
                    new EngageState(m_Ship);
                    new SearchingState(m_Ship);
                    new ChaseState(m_Ship);
                    new RetreatState(m_Ship);
                    new DeathState(m_Ship);
                }
                m_CurrentState = m_AllStates[0];

                m_CurrentState.Start();
            }
        }
    }
}
