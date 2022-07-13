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
        public MovementEventArgs(Vector3 movement, bool moving)
        {
            targetPosition = movement;
            isMoving = moving;
        }

        public Vector3 targetPosition { get; }
        public bool isMoving { get; }
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


        public void Initialization(IStateSwitcher switcher)
        {
            m_ISwitcher = switcher;
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

        protected virtual void SendTargetPosition(Vector3 positionTarget, bool isMoving)
        {
            if (isMoving)
            {
                Event_MovementChanged?.Invoke(this, new MovementEventArgs(positionTarget, isMoving));
            }
            else
            {
                Event_MovementChanged?.Invoke(this, new MovementEventArgs(Vector3.zero, isMoving));
            }
        }

        protected virtual void SendRotationPosition(Vector3 position)
        {
            Event_RotationChanged?.Invoke(this, new RotationEventArgs(position));
        }

        private void StopMovement()
        {
            Event_MovementChanged?.Invoke(this, new MovementEventArgs(Vector3.zero, false));
        }

        protected virtual void Fire(bool isFiring)
        {
            Event_FireChanged?.Invoke(this, new FireEventArgs(isFiring));
        }
    }
}
