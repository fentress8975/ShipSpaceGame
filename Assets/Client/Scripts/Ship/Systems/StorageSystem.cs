using ShipModule;
using System.Collections.Generic;
using UnityEngine;


namespace ShipSystem
{
    public class StorageSystem : MonoBehaviour, IShipSystem, IShipSystemSO<ShipStorageSO>
    {
        private ShipStorage m_Module;

        public event IShipSystem.ModuleHealthUpdate Event_HealthUpdate;
        public event IShipSystem.ModuleEfficiencyUpdate Event_EfficiencyUpdate;


        public void Initialization(ShipStorageSO moduleSO)
        {
            m_Module = new ShipStorage(moduleSO);
        }

        public ShipStorageSO GetModuleSO()
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