using AI.Enemy;
using ShipBase;
using ShipSystem;
using System;
using UnityEngine;


namespace AI
{
    public class WeaponAIHandler : MonoBehaviour
    {
        private WeaponsSystem m_WeaponSystem;
        private bool m_bIsFiring = false;


        public void Initialization(Ship ship, EnemyBehavior behavior)
        {
            Subscribe(behavior);

            m_WeaponSystem = ship.GetComponent<WeaponsSystem>();
        }

        private void FireWeapon(bool isFiring)
        {
            m_bIsFiring = isFiring; // Пусть будет
            if (isFiring)
            {
                m_WeaponSystem.EnableWeapon();
            }
            else
            {
                m_WeaponSystem.DisableWeapon();
            }
        }

        public void Subscribe(EnemyBehavior target)
        {
            target.Event_FireChanged += FireWeapon;
        }

        public void UnSubscribe(EnemyBehavior target)
        {
            target.Event_FireChanged -= FireWeapon;
        }

        private void OnDestroy()
        {
            
        }
    }
}