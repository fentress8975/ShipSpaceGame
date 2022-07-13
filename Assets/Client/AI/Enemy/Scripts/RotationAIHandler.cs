using AI.Enemy;
using ShipBase;
using ShipBase.Containers;
using ShipSystem;
using UnityEngine;

namespace AI
{
    public class RotationAIHandler : MonoBehaviour
    {
        private Plane m_GamePlane;
        private Vector3 m_LockAt = Vector3.zero;

        private Camera m_MainCamera;

        private Rigidbody m_Rigidbody;
        private EngineSystem engineSystem;

        [SerializeField]
        private float m_fRotationVelocity;
        private float m_fSpeedDamping = 1f;
        private RotationDirection m_RotationDirection;
        private GameObject m_Rotation;



        private enum RotationDirection
        {
            Clockwise,
            ConterClockWise
        }


        public void Initialization(Ship ship, EnemyBehavior behavior)
        {
            m_Rigidbody = ship.m_RigidBody;
            engineSystem = (EngineSystem)ship.GetSystem(SystemType.Engine);
            m_fRotationVelocity = engineSystem.GetEngineRotationSpeed();
            engineSystem.Event_EnginePowerUpdate.AddListener(EngineChange);

            Subscribe(behavior);

            m_GamePlane = new Plane(transform.up, Vector3.zero);
            m_MainCamera = Camera.main;
            m_Rotation = new GameObject("Ship Rotation");
            m_Rotation.transform.parent = ship.transform;
            m_Rotation.transform.localPosition = Vector3.zero;
        }

        public void UnSubscribe(EnemyBehavior target)
        {
            target.Event_RotationChanged -= RotationCalculator;
        }

        public void Subscribe(EnemyBehavior target)
        {
            target.Event_RotationChanged += RotationCalculator;
        }

        private void EngineChange(float rotationVel)
        {
            m_fRotationVelocity = rotationVel;
        }

        private void OnDestroy()
        {

            engineSystem.Event_EnginePowerUpdate.RemoveListener(EngineChange);
        }

        private void RotationCalculator(Vector3 x)
        {
            GetTargetPosition(x);
            m_Rotation.transform.LookAt(m_LockAt);
            m_RotationDirection = GetTurningDirection();
            SpeedDampingCalculation();
        }


        private void GetTargetPosition(Vector3 x)
        {
            m_LockAt = x;
            m_LockAt.y = 0;
        }

        private void Rotate()
        {
            Vector3 dPerSeconds = new Vector3(0, m_fRotationVelocity * m_fSpeedDamping, 0);
            Quaternion deltaRotation;
            switch (m_RotationDirection)
            {
                case RotationDirection.Clockwise:
                    deltaRotation = Quaternion.Euler(dPerSeconds * Time.fixedDeltaTime);
                    m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotation);
                    break;
                case RotationDirection.ConterClockWise:
                    deltaRotation = Quaternion.Euler(-dPerSeconds * Time.fixedDeltaTime);
                    m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotation);
                    break;
            };
        }

        //SLowdown, for better rotation at the end
        private void SpeedDampingCalculation()
        {
            m_fSpeedDamping = Mathf.InverseLerp(0f, m_fRotationVelocity * 0.1f, Quaternion.Angle(m_Rotation.transform.rotation, m_Rigidbody.rotation));
        }

        private RotationDirection GetTurningDirection()
        {
            if (m_Rotation.transform.localEulerAngles.y < 180)
            {
                return RotationDirection.Clockwise;
            }
            else
            {
                return RotationDirection.ConterClockWise;
            }
        }

        private void FixedUpdate()
        {
            RotationCalculator(m_LockAt);
            Rotate();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(m_LockAt, 0.5f);
        }
    }
}