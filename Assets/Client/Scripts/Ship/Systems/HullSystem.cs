using ShipModule;
using UnityEngine;


namespace ShipSystem
{
    public class HullSystem : MonoBehaviour, IShipSystem, IShipSystemSO<ShipHullSO>
    {
        public event IShipSystem.ModuleHealthUpdate Event_HealthUpdate;
        public event IShipSystem.ModuleEfficiencyUpdate Event_EfficiencyUpdate;

        private ShipHull m_Hull;


        public void Initialization(ShipHullSO moduleSO)
        {
            m_Hull = new ShipHull(moduleSO);

        }

        public ShipHullSO GetModuleSO()
        {
            return m_Hull.ModuleSO;
        }

        public float GetSystemWeight()
        {
            return GetModuleSO().m_fWeight;
        }

        public float GetSystemHealth()
        {
            return GetModuleSO().m_fHealth;
        }


    }
}