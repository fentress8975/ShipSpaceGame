using ShipModule;
using System.Collections.Generic;
using UnityEngine;


namespace ShipSystem
{
    public class HullSystem : MonoBehaviour, IShipSystem, IShipSystemSO<ShipHullSO>
    {
        public event IShipSystem.ModuleHealthUpdate Event_HealthUpdate;
        public event IShipSystem.ModuleEfficiencyUpdate Event_EfficiencyUpdate;

        private ShipHull m_Module;


        public void Initialization(ShipHullSO moduleSO)
        {
            m_Module = new ShipHull(moduleSO);
        }

        public ShipHullSO GetModuleSO()
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