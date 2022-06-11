using ShipModule;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ShipSystem
{
    public class WeaponsSystem : MonoBehaviour, IShipSystem, IShipSystemSO<ShipWeaponSO>
    {
        public event IShipSystem.ModuleHealthUpdate Event_HealthUpdate;
        public event IShipSystem.ModuleEfficiencyUpdate Event_EfficiencyUpdate;
        public UnityEvent<AudioClip> Event_PlayAudio;
        private ObjectPooling m_ProjectilePool;
        private int m_iProjectilesLifeTime = 5;

        private enum WeaponsState
        {
            Idle,
            Firing
        }

        private ShipWeapon m_Module;
        private GameObject m_Projectiles;
        private float m_fNextTimeFire = 0;
        private WeaponsState m_sWeaponState = WeaponsState.Idle;


        public void Initialization(ShipWeaponSO moduleSO)
        {
            m_Module = new ShipWeapon(moduleSO);

            m_Projectiles = new GameObject("Projectiles");
            m_ProjectilePool = gameObject.AddComponent<ObjectPooling>();
            m_ProjectilePool.Initialization(m_Module.m_ModuleSO.m_Projectile,
                                            m_iProjectilesLifeTime * Mathf.RoundToInt(m_Module.m_ModuleSO.m_fFireRate / 60) + 1,
                                            m_Projectiles.transform);
        }

        public ShipWeaponSO GetModuleSO()
        {
            return m_Module.m_ModuleSO;
        }

        public float GetSystemWeight()
        {
            return m_Module.GetModuleWeight();
        }

        public float GetSystemHealth()
        {
            return m_Module.GetModuleHealth();
        }

        public IShipModule GetModule()
        {
            return m_Module;
        }

        public Dictionary<string, float> GetModuleInfo()
        {
            return m_Module.GetModuleInformation();
        }

        public void EnableWeapon()
        {
            m_sWeaponState = WeaponsState.Firing;
        }
        public void DisableWeapon()
        {
            m_sWeaponState = WeaponsState.Idle;
        }

        public void TakeDamage(float damage)
        {
            m_Module.TakeDamage(damage);
        }

        public void TakeDamage(float damage, string damageType)
        {
            throw new System.NotImplementedException();
        }


        private void Fire()
        {
            if (Time.time > m_fNextTimeFire + (60 / m_Module.m_ModuleSO.m_fFireRate))
            {
                m_fNextTimeFire = Time.time;
                Projectile projectile = PrepareProjectile();
                projectile.Initialization(m_Module.m_ModuleSO.m_fSpeed, m_Module.m_ModuleSO.m_iDamage, m_iProjectilesLifeTime);
                Event_PlayAudio?.Invoke(m_Module.m_ModuleSO.m_Audio);
            }
        }

        private Projectile PrepareProjectile()
        {

            GameObject prefab = m_ProjectilePool.GetPooledObject();
            if (prefab != null)
            {
                prefab.transform.position = transform.position + transform.forward * 2f;
                prefab.transform.rotation = transform.rotation;
                Projectile projectile = prefab.GetComponent<Projectile>();
                return projectile;
            }

            Debug.LogException(new System.Exception("Null pooled Projectile"));
            return null;
        }


        private void Update()
        {
            if (m_sWeaponState == WeaponsState.Idle)
            {

            }
            if (m_sWeaponState == WeaponsState.Firing)
            {
                Fire();
            }

        }


    }
}