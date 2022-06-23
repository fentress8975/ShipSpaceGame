using AI.Enemy;
using System.Collections;
using System.Collections.Generic;


namespace AI
{
    public abstract class EnemyBaseState
    {
        protected readonly EnemyShip m_Ship;

        protected EnemyBaseState(EnemyShip enemyShip)
        {
            m_Ship = enemyShip;
        }

        public abstract void Stop();

        public abstract void Start();


        public abstract void Attack();

        public abstract void Chase();

        public abstract void Retreat();

        public abstract void Search();

        public abstract void Patrol();

        public abstract void Sleep();

        public abstract void Die();
    }
}
