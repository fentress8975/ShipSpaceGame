using AI.Enemy;
using ShipBase;
using ShipBase.Containers;
using ShipModule;
using ShipSystem;
using UnityEngine;
using UnityEngine.Events;


namespace AI
{
    public class MovementAIHandler : MonoBehaviour
    {
        public UnityEvent<bool> Event_StabilazionChanged;

        [SerializeField]
        private float m_fAccelerationPower;
        private bool m_bIsMoving = false;
        private bool m_bStabilization = true;
        EngineSystem engineSystem;
        private Rigidbody m_Rigidbody;
        private Vector3 m_MovingDirection;

        UIController m_UIController;

        public void Initialization(Ship ship, EnemyBehavior behavior)
        {
            Subscribe(behavior);

            m_Rigidbody = ship.m_RigidBody;
            engineSystem = (EngineSystem)ship.GetSystem(SystemType.Engine);
            m_fAccelerationPower = engineSystem.GetEnginePower();
            engineSystem.Event_EnginePowerUpdate += EngineChange;
        }

        public void Subscribe(EnemyBehavior target)
        {
            target.Event_MovementChanged += Movement;
        }

        public void UnSubscribe(EnemyBehavior target)
        {
            target.Event_MovementChanged -= Movement;
        }

        public bool isStabilazed()
        {
            return m_bStabilization;
        }

        public void ChangeStabilazion()
        {
            m_bStabilization = !m_bStabilization;
            Event_StabilazionChanged?.Invoke(m_bStabilization);
        }

        //public void Movement(Vector2 axis, bool isMoving)
        //{
        //    m_bIsMoving = isMoving;
        //    m_MovingDirection = new Vector3(axis.x, 0, axis.y);
        //}

        public void Movement(Vector3 axis, bool isMoving)
        {
            m_bIsMoving = isMoving;
            axis.y = 0;
            m_MovingDirection = axis;
        }


        private void OnDestroy()
        {
            engineSystem.Event_EnginePowerUpdate-=EngineChange;
        }

        private void FixedUpdate()
        {
            Acceleration();

            if (!m_bIsMoving)
            {
                Stabilization();
            }

        }

        private void Stabilization()
        {
            //Change drag to stop ship.
            if (m_bStabilization)
            {
                if (m_Rigidbody.drag != 5) { m_Rigidbody.drag = 5; }
            }
            if (m_Rigidbody.velocity.magnitude < 1) { m_Rigidbody.velocity = Vector3.zero; }
        }

        private void Acceleration()
        {
            if (m_Rigidbody.drag != 0) { m_Rigidbody.drag = 0; }
            m_Rigidbody.AddForce(m_MovingDirection * Time.fixedDeltaTime * m_fAccelerationPower, ForceMode.Acceleration);
        }

        private void EngineChange(float newPower)
        {
            m_fAccelerationPower = newPower;
        }
    }
}

