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
        public MovementEventArgs(Vector2 movement, bool Moving)
        {
            Movement = movement;
            isMoving = Moving;
        }

        public Vector3 Movement { get; }
        public bool isMoving { get; }
    }

    public abstract class EnemyBaseState : MonoBehaviour
    {
        public event EventHandler<RotationEventArgs> Event_RotationChanged;
        public event EventHandler<MovementEventArgs> Event_MovementChanged;

        protected EnemyController m_Ship;
        protected Ship m_TargetShip;


        public void Initialization(EnemyController Ship)
        {
            m_Ship = Ship;

        }

        public abstract void Stop();

        public abstract void Begin();



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

       
    }
}
