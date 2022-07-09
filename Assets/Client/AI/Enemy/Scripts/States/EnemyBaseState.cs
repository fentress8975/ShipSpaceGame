using AI.Enemy;
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
            Rotation = rotation;
        }

        public Vector3 Rotation { get; }
    }

    public class MovementEventArgs : EventArgs
    {
        public MovementEventArgs(Vector2 movement, bool moving)
        {
            Movement = movement;
            isMoving = moving;
        }

        public Vector3 Movement { get; }
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
            m_TargetShip = null;
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

        protected virtual void GetSpeedVector()
        {
            Vector3 direction = m_TargetShip.transform.position - gameObject.transform.position;
            direction.Normalize();
            Event_MovementChanged?.Invoke(this, new MovementEventArgs(direction, true));
        }

        protected virtual void GetRotationVector()
        {
            Event_RotationChanged?.Invoke(this, new RotationEventArgs(m_TargetShip.transform.position));
        }

        protected virtual void Fire(bool isFiring)
        {
            Event_FireChanged?.Invoke(this, new FireEventArgs(isFiring));
        }
    }
}
