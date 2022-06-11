using ShipModule;
using System.Collections.Generic;
using UnityEngine;


namespace ShipSystem
{

    public class AISystem : MonoBehaviour, IShipSystem, IShipSystemSO<ShipAISO>
    {
        private ShipAI m_Module;

        public event IShipSystem.ModuleHealthUpdate Event_HealthUpdate;
        public event IShipSystem.ModuleEfficiencyUpdate Event_EfficiencyUpdate;


        public void Initialization(ShipAISO moduleSO)
        {
            m_Module = new ShipAI(moduleSO);
        }

        public ShipAISO GetModuleSO()
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

        public void TakeDamage(float damage)
        {
            m_Module.TakeDamage(damage);
        }

        public void TakeDamage(float damage, string damageType)
        {
            throw new System.NotImplementedException();
        }
    }
}