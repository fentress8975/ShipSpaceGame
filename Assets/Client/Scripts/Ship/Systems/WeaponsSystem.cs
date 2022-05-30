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

        private void Fire()
        {
            if (Time.time > m_fNextTimeFire + (60 / m_Module.m_ModuleSO.m_fFireRate))
            {
                m_fNextTimeFire = Time.time;
                Projectile projectile = PrepareProjectile();
                projectile.Initialization(m_Module.m_ModuleSO.m_fSpeed, m_Module.m_ModuleSO.m_iDamage);
                Event_PlayAudio?.Invoke(m_Module.m_ModuleSO.m_Audio);
            }
        }

        private Projectile PrepareProjectile()
        {
            GameObject prefab = Instantiate(m_Module.m_ModuleSO.m_Projectile, m_Projectiles.transform);
            prefab.transform.position = transform.position + transform.forward * 2f;
            prefab.transform.rotation = transform.rotation;
            Projectile projectile = prefab.GetComponent<Projectile>();
            return projectile;
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