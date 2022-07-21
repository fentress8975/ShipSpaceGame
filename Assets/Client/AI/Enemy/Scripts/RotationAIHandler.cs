﻿using AI.Enemy;
using ShipBase;
using ShipBase.Containers;
using ShipSystem;
using UnityEngine;

namespace AI
{
    public class RotationAIHandler : MonoBehaviour
    {
        private Plane m_GamePlane;
        [SerializeField]
        private Vector3 m_LockAt = Vector3.zero;

        private Camera m_MainCamera;

        private Rigidbody m_Rigidbody;
        private EngineSystem engineSystem;

        [SerializeField]
        private float m_fRotationVelocity;
        [SerializeField]
        private bool m_bisError;
        private float m_fTimeError;

        private RotationDirection m_RotationDirection;
        private GameObject m_Rotation;
        private GameObject m_ErrorRotation;
        private float m_fAngle;




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

            m_ErrorRotation = new GameObject("Ship Error Rotation");
            m_ErrorRotation.transform.parent = ship.transform;
            m_ErrorRotation.transform.localPosition = Vector3.zero;
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
        }


        private void GetTargetPosition(Vector3 x)
        {
            m_LockAt = x;
            m_LockAt.y = 0;
        }

        private void Rotation(float speed)
        {
            Vector3 dPerSeconds = new Vector3(0, speed, 0);
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

        private void Rotate()
        {
            m_fAngle = Quaternion.Angle(m_Rotation.transform.rotation, m_Rigidbody.rotation);
            if (m_bisError)
            {
                Rotate(CalculateErrorSpeed());
                m_bisError = false;
            }
            else if (m_fAngle == 0)
            {
                Rotation(m_fRotationVelocity);
            }
            else
            {
                m_Rigidbody.rotation = m_Rotation.transform.rotation;
            }
            ErrorCleaning();
        }

        private void Rotate(float speed)
        {
            m_fAngle = Quaternion.Angle(m_Rotation.transform.rotation, m_Rigidbody.rotation);
            Rotation(speed);
        }

        private void ErrorCleaning()
        {
            if (m_fAngle != 0)
            {
                if (m_fAngle <= 1)
                {
                    m_Rigidbody.rotation = m_Rotation.transform.rotation;
                    return;
                }

                Quaternion rotation = FakeRotation();
                m_ErrorRotation.transform.rotation = rotation;

                RotationDirection rotationDirection = CheckTurningDirection();
                //Direction change?
                if (rotationDirection != m_RotationDirection)
                {
                    m_fTimeError = Time.time;
                    m_bisError = true;
                }
            }
        }

        private Quaternion FakeRotation()
        {
            Quaternion futureRBRotation = m_Rigidbody.rotation;

            Vector3 dPerSeconds = new Vector3(0, m_fRotationVelocity, 0);
            Quaternion deltaRotation;
            switch (m_RotationDirection)
            {
                case RotationDirection.Clockwise:
                    deltaRotation = Quaternion.Euler(dPerSeconds * Time.fixedDeltaTime);
                    futureRBRotation *= deltaRotation;
                    break;
                case RotationDirection.ConterClockWise:
                    deltaRotation = Quaternion.Euler(-dPerSeconds * Time.fixedDeltaTime);
                    futureRBRotation *= deltaRotation;
                    break;
            };
            return futureRBRotation;
        }
        private float CalculateErrorSpeed()
        {
            float time = Time.time - m_fTimeError;
            return time;
        }

        private void GetTurningDirection()
        {

            if (m_Rotation.transform.localEulerAngles.y < 180)
            {
                m_RotationDirection = RotationDirection.Clockwise;
            }
            else
            {
                m_RotationDirection = RotationDirection.ConterClockWise;
            }
        }

        private RotationDirection CheckTurningDirection()
        {
            if (m_ErrorRotation.transform.localEulerAngles.y < 180)
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
            GetTurningDirection();
            Rotate();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(m_LockAt, 0.5f);
        }
    }
}