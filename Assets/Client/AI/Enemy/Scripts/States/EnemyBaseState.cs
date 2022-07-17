using ShipBase;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class RotationEventArgs : EventArgs
    {

        public RotationEventArgs(Vector3 rotation)
        {
            targetRotation = rotation;
        }

        public Vector3 targetRotation { get; }
    }

    public class MovementEventArgs : EventArgs
    {
        public MovementEventArgs(Vector3 movement, float speedScale)
        {
            _targetPosition = movement;
            _speedScale = speedScale;
        }

        public Vector3 _targetPosition { get; }
        public float _speedScale { get; }
    }

    public class FireEventArgs : EventArgs
    {
        public FireEventArgs(bool firing)
        {
            isFiring = firing;
        }

        public bool isFiring { get; }
    }

    public abstract class EnemyBaseState : MonoBehaviour
    {
        public event EventHandler<RotationEventArgs> Event_RotationChanged;
        public event EventHandler<MovementEventArgs> Event_MovementChanged;
        public event EventHandler<FireEventArgs> Event_FireChanged;

        protected Ship m_TargetShip;
        protected IStateSwitcher m_ISwitcher;
        protected IShipInformation m_IShipInformation;

        protected const int m_iFULLSPEED = 1;
        protected const int m_iFULLSTOP = 0;

        public void Initialization(IStateSwitcher switcher, IShipInformation shipInfo)
        {
            m_ISwitcher = switcher;
            m_IShipInformation = shipInfo;
        }

        public virtual void Stop()
        {
            Debug.Log("Stop State");
            m_TargetShip = null;
            StopMovement();
        }

        public virtual void Begin(Ship target)
        {
            if (target != null)
            {
                m_TargetShip = target;
            }
        }

        public abstract void Attack(Ship target);

        public abstract void Chase(Ship target);

        public abstract void Retreat(Ship danger);

        public abstract void Search(Vector3 lastKnowPosition);

        public abstract void Patrol(List<Vector3> route);

        public abstract void Sleep();

        public abstract void Die();

        protected virtual void OnRotationChanged(RotationEventArgs e)
        {
            // Safely raise the event for all subscribers
            Event_RotationChanged?.Invoke(this, e);
        }

        protected virtual void OnMovementChanged(MovementEventArgs e)
        {
            // Safely raise the event for all subscribers
            Event_MovementChanged?.Invoke(this, e);
        }

        protected virtual void SendMovingCommand(bool isMoving)
        {
            if (isMoving)
            {
                Event_MovementChanged?.Invoke(this, new MovementEventArgs(m_TargetShip.transform.position, m_iFULLSPEED));
            }
            else
            {
                Event_MovementChanged?.Invoke(this, new MovementEventArgs(Vector3.zero, m_iFULLSTOP));
            }
        }

        protected virtual void SendMovingCommand(Vector3 positionTarget, bool isMoving)
        {
            if (isMoving)
            {
                Event_MovementChanged?.Invoke(this, new MovementEventArgs(positionTarget, m_iFULLSPEED));
            }
            else
            {
                Event_MovementChanged?.Invoke(this, new MovementEventArgs(Vector3.zero, m_iFULLSTOP));
            }
        }

        protected virtual void SendMovingCommand(Vector3 positionTarget, float speed, bool isMoving)
        {
            if (isMoving)
            {
                Event_MovementChanged?.Invoke(this, new MovementEventArgs(positionTarget, speed));
            }
            else
            {
                Event_MovementChanged?.Invoke(this, new MovementEventArgs(Vector3.zero, m_iFULLSTOP));
            }
        }

        protected virtual void SendRotationCommand()
        {
            Event_RotationChanged?.Invoke(this, new RotationEventArgs(m_TargetShip.transform.position));
        }

        protected virtual void SendRotationCommand(Vector3 position)
        {
            Event_RotationChanged?.Invoke(this, new RotationEventArgs(position));
        }

        private void StopMovement()
        {
            Event_MovementChanged?.Invoke(this, new MovementEventArgs(Vector3.zero, m_iFULLSTOP));
        }

        protected virtual void Fire(bool isFiring)
        {
            Event_FireChanged?.Invoke(this, new FireEventArgs(isFiring));
        }

        protected virtual bool isLookingOnTarget()
        {
            float angle = Quaternion.Angle(GetDirectionToTarget(m_TargetShip.transform.position), m_IShipInformation.m_ShipTransform.rotation);
            if (MathF.Abs(angle) < 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected Quaternion GetDirectionToTarget(Vector3 target)
        {
            Vector3 relativePos = target - m_IShipInformation.m_ShipTransform.position;
            return Quaternion.LookRotation(relativePos);
        }
    }
}
