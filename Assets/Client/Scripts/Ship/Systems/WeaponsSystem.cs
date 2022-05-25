using ShipModule;
using System.Collections.Generic;
using UnityEngine;


namespace ShipSystem
{
    public class WeaponsSystem : MonoBehaviour, IShipSystem, IShipSystemSO<ShipWeaponSO>
    {
        public event IShipSystem.ModuleHealthUpdate Event_HealthUpdate;
        public event IShipSystem.ModuleEfficiencyUpdate Event_EfficiencyUpdate;

        public ShipWeapon m_Module;


        public void Initialization(ShipWeaponSO moduleSO)
        {
            m_Module = new ShipWeapon(moduleSO);
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
    }
}