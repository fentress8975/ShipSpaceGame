using ShipBase;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace AI
{
    namespace Enemy
    {
        public class EnemyBehavior : MonoBehaviour, IStateSwitcher
        {
            public delegate void RotationHandler(Vector3 rotation);
            public delegate void MovementHandler(Vector3 movement, bool isMoving);
            public delegate void FireHandler(bool isFiring);
            public event RotationHandler Event_RotationChanged;
            public event MovementHandler Event_MovementChanged;
            public event FireHandler Event_FireChanged;

            private Ship m_Target;

            private MovementAIHandler m_MovementHandler;
            private RotationAIHandler m_RotationHandler;
            private WeaponAIHandler m_WeaponHandler;
            private TargetScaner m_TargetScaner;

            private EnemyBaseState m_CurrentState;
            [SerializeField]
            private List<EnemyBaseState> m_AllStates;

            private List<Vector3> m_Route = new List<Vector3>();

            public void Initialization(TargetScaner targetScanner, MovementAIHandler movementHandler, RotationAIHandler rotationHandler, WeaponAIHandler weaponHandler)
            {
                m_MovementHandler = movementHandler;
                m_RotationHandler = rotationHandler;
                m_WeaponHandler = weaponHandler;
                m_TargetScaner = targetScanner;

                m_TargetScaner.Event_TargetChanged += GetTarget;

                m_AllStates = new List<EnemyBaseState>();
                {
                    m_AllStates.Add(gameObject.AddComponent<SleepState>());
                    m_AllStates.Add(gameObject.AddComponent<PatrollingState>());
                    m_AllStates.Add(gameObject.AddComponent<EngageState>());
                    m_AllStates.Add(gameObject.AddComponent<SearchingState>());
                    m_AllStates.Add(gameObject.AddComponent<ChaseState>());
                    m_AllStates.Add(gameObject.AddComponent<RetreatState>());
                    m_AllStates.Add(gameObject.AddComponent<DeathState>());
                }
                foreach (EnemyBaseState state in m_AllStates)
                {
                    state.Initialization(this);
                    state.gameObject.SetActive(false);
                }
                m_CurrentState = m_AllStates[0];
                m_CurrentState.gameObject.SetActive(true);

                m_CurrentState.Begin(m_Target);
                Subscribe(m_CurrentState);
            }

            public void UpdateRoute(List<Vector3> route)
            {
                m_Route = route;
            }

            public void StateSwitcher<T>() where T : EnemyBaseState
            {
                var state = m_AllStates.FirstOrDefault(s => s is T);

                m_CurrentState.Stop();
                UnSubscribe(state);
                state.gameObject.SetActive(false);

                m_CurrentState = state;
                state.gameObject.SetActive(true);
                m_CurrentState.Begin(m_Target);
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
                state.Event_FireChanged += FireShip;
            }

            private void UnSubscribe<T>(T state) where T : EnemyBaseState
            {
                state.Event_MovementChanged -= MoveShip;
                state.Event_RotationChanged -= RotateShip;
                state.Event_FireChanged -= FireShip;
            }

            private void RotateShip(object sender, RotationEventArgs e)
            {
                Event_RotationChanged?.Invoke(e.Rotation);
            }

            private void MoveShip(object sender, MovementEventArgs e)
            {
                Event_MovementChanged?.Invoke(e.Movement, e.isMoving);
            }

            private void FireShip(object sender, FireEventArgs e)
            {
                Event_FireChanged?.Invoke(e.isFiring);
            }

            private void GetTarget(Ship target)
            {
                if (target == null && m_Target != null)
                {
                    m_CurrentState.Search(m_Target.transform.position);
                    m_Target = null;
                }
                else
                {
                    m_Target = target;
                }
            }

            private void Update()
            {
                if(m_Target != null)
                {
                    m_CurrentState.Attack(m_Target);
                }
                else if (m_Route.Count > 1 && m_Route != null)
                {
                    m_CurrentState.Patrol(m_Route);
                }
                
            }

            private void OnDestroy()
            {
                m_TargetScaner.Event_TargetChanged -= GetTarget;
            }
        }
    }
}
