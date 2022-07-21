using ShipBase;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace AI
{
    namespace Enemy
    {
        public class EnemyBehavior : MonoBehaviour, IStateSwitcher, IShipInformation
        {
            public delegate void RotationHandler(Vector3 rotation);
            public delegate void MovementHandler(Vector3 movement, bool isMoving);
            public delegate void FireHandler(bool isFiring);
            public event RotationHandler Event_RotationChanged;
            public event MovementHandler Event_MovementChanged;
            public event FireHandler Event_FireChanged;

            private Ship m_Target;

            private Ship m_Ship;
            private Vector3? m_LastPosition;
            public Transform m_ShipTransform
            {
                get { return m_Ship.transform; }
            }
            private MovementAIHandler m_MovementHandler;
            private RotationAIHandler m_RotationHandler;
            private WeaponAIHandler m_WeaponHandler;
            private TargetScaner m_TargetScaner;

            private EnemyBaseState m_CurrentState;
            [SerializeField]
            private List<EnemyBaseState> m_AllStates;

            private List<Vector3> m_Route = new List<Vector3>();

            public void Initialization(Ship ship, TargetScaner targetScanner, MovementAIHandler movementHandler, RotationAIHandler rotationHandler, WeaponAIHandler weaponHandler)
            {
                m_Ship = ship;
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
                    state.Initialization(this,this);
                    state.enabled = false;
                }

                StateSwitcher<SleepState>();
            }

            public void UpdateRoute(List<Vector3> route)
            {
                m_Route = route;
            }

            public void StateSwitcher<T>() where T : EnemyBaseState
            {
                var state = m_AllStates.FirstOrDefault(s => s is T);
                if (m_CurrentState != null)
                {
                    m_CurrentState.Stop();
                    UnSubscribe(state);
                    m_CurrentState.enabled = false;
                }

                m_CurrentState = state;
                state.enabled = true;
                m_CurrentState.Begin(m_Target);
                Subscribe(state);
            }

            public void Sleep()
            {
                if (m_CurrentState != m_AllStates[0])
                {
                    m_CurrentState.Sleep();
                    StateSwitcher<SleepState>();
                    m_CurrentState.Sleep();
                }
            }

            public void Patrol(List<Vector3> route)
            {
                if (m_CurrentState != m_AllStates[1])
                {
                    m_CurrentState.Patrol(route);
                    StateSwitcher<PatrollingState>();
                    m_CurrentState.Patrol(route);
                }
            }

            public void AttackTarget(Ship target)
            {
                if (m_CurrentState != m_AllStates[2])
                {
                    m_CurrentState.Attack(m_Target);
                    StateSwitcher<EngageState>();
                    m_CurrentState.Attack(m_Target);
                }
            }

            public void SearchTarget(Vector3 lastKnowPosition)
            {
                if (m_CurrentState != m_AllStates[3])
                {
                    m_CurrentState.Search(lastKnowPosition);
                    StateSwitcher<SearchingState>();
                    m_CurrentState.Search(lastKnowPosition);
                }
            }

            public void ChaseTarget(Ship target)
            {
                if (m_CurrentState != m_AllStates[4])
                {
                    m_CurrentState.Chase(m_Target);
                    StateSwitcher<ChaseState>();
                    m_CurrentState.Chase(m_Target);
                }
            }

            public void Retreat()
            {
                if (m_CurrentState != m_AllStates[5])
                {
                    m_CurrentState.Retreat(m_Target);
                    StateSwitcher<RetreatState>();
                    m_CurrentState.Retreat(m_Target);
                }
            }

            public void Die()
            {
                if (m_CurrentState != m_AllStates[6])
                {
                    m_CurrentState.Die();
                    StateSwitcher<DeathState>();
                    m_CurrentState.Die();
                }
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
                Event_RotationChanged?.Invoke(e.targetRotation);
            }

            private void MoveShip(object sender, MovementEventArgs e)
            {
                if (e._speedScale == 0)
                {
                    Event_MovementChanged?.Invoke(Vector3.zero, false);
                    return;
                }
                else
                {
                    Vector3 direction = (e._targetPosition - m_Ship.transform.position) * e._speedScale;
                    Event_MovementChanged?.Invoke(direction, true);
                }
            }

            private void FireShip(object sender, FireEventArgs e)
            {
                if (e.isFiring)
                {
                    Debug.Log("tratratratratra");
                }
                
                //Event_FireChanged?.Invoke(e.isFiring);
            }

            private void GetTarget(Ship target)
            {
                //≈сли приходит пустой таргет, то сн€ть текущий таргет и записать его последнюю позицию дл€ поиска
                if (target == null && m_Target != null)
                {
                    m_LastPosition = m_Target.transform.position;
                    m_Target = null;
                    SearchTarget((Vector3)m_LastPosition);
                }
                else
                {
                    m_Target = target;
                    m_LastPosition = null;
                }
            }

            private void Update()
            {
                if (m_Target != null)
                {
                    //Check Distance
                    if (Mathf.Abs((m_Target.transform.position - m_Ship.transform.position).magnitude) <= 10)
                    {
                        AttackTarget(m_Target);
                    }
                    else if (Mathf.Abs((m_Target.transform.position - m_Ship.transform.position).magnitude) >= 10)
                    {
                        ChaseTarget(m_Target);
                    }
                }

                if (m_Target == null)
                {
                    if(m_LastPosition != null)
                    {
                        SearchTarget((Vector3)m_LastPosition);
                    }
                    else
                    {
                        if (m_Route.Count > 1 && m_Route != null)
                        {
                            Patrol(m_Route);
                        }
                        else
                        {
                            Sleep();
                        }
                    }
                }
            }

            private void OnDestroy()
            {
                m_TargetScaner.Event_TargetChanged -= GetTarget;
            }
        }
    }
}
