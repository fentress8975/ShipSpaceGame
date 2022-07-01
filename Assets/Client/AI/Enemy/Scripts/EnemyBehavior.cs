using ShipBase;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace AI
{
    namespace Enemy
    {
        public class EnemyBehavior : MonoBehaviour
        {
            public delegate void RotationHandler(Vector3 rotation);
            public delegate void MovementHandler(Vector2 movement, bool isMoving);
            public event RotationHandler Event_RotationChanged;
            public event MovementHandler Event_MovementChanged;

            private EnemyController m_Ship;
            private Ship m_Target;

            private MovementAIHandler m_Movement;
            private RotationAIHandler m_Rotation;
            private EnemyBaseState m_CurrentState;
            private List<EnemyBaseState> m_AllStates;


            private void Initialization(EnemyController ship, Ship target, MovementAIHandler movementHandler, RotationAIHandler rotationHandler)
            {
                m_Movement = movementHandler;
                m_Rotation = rotationHandler;
                m_Ship = ship;
                m_Target = target;

                m_AllStates = new List<EnemyBaseState>();
                {
                    gameObject.AddComponent<SleepState>();
                    gameObject.AddComponent<PatrollingState>();
                    gameObject.AddComponent<EngageState>();
                    gameObject.AddComponent<SearchingState>();
                    gameObject.AddComponent<ChaseState>();
                    gameObject.AddComponent<RetreatState>();
                    gameObject.AddComponent<DeathState>();
                }
                foreach (EnemyBaseState state in m_AllStates)
                {
                    state.Initialization(ship);
                }
                m_CurrentState = m_AllStates[0];

                m_CurrentState.Begin();
                Subscribe(m_CurrentState);
            }


            public void SwitchState<T>(T state) where T : EnemyBaseState
            {
                m_CurrentState.Stop();
                UnSubscribe(state);

                m_CurrentState = state;
                m_CurrentState.Begin();
                Subscribe(state);
            }

            public void Sleep()
            {
                m_CurrentState.Sleep();
            }

            public void Patrol(List<Vector3> route)
            {
                m_CurrentState.Patrol(route);
            }

            public void AttackTarget()
            {
                m_CurrentState.Attack(m_Target);
            }

            public void SearchTarget(Vector3 lastKnowPosition)
            {
                m_CurrentState.Search(lastKnowPosition);
            }

            public void ChaseTarget()
            {
                m_CurrentState.Chase(m_Target);
            }

            public void Retreat()
            {
                m_CurrentState.Retreat(m_Target);
            }

            public void Die()
            {
                m_CurrentState.Die();
            }

            private void Subscribe<T>(T state) where T : EnemyBaseState
            {
                state.Event_MovementChanged += MoveShip;
                state.Event_RotationChanged += RotateShip;
            }

            private void UnSubscribe<T>(T state) where T : EnemyBaseState
            {
                state.Event_MovementChanged -= MoveShip;
                state.Event_RotationChanged -= RotateShip;
            }

            private void RotateShip(object sender, RotationEventArgs e)
            {
                Event_RotationChanged?.Invoke(e.Rotation);
            }

            private void MoveShip(object sender, MovementEventArgs e)
            {
                Event_MovementChanged?.Invoke(e.Movement, e.isMoving);
            }
        }
    }
}
