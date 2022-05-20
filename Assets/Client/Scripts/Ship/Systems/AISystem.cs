using ShipModule;
using UnityEngine;


namespace ShipSystem
{

    public class AISystem : MonoBehaviour, IShipSystem, IShipSystemSO<ShipAISO>
    {
        private ShipAI m_AI;

        public event IShipSystem.ModuleHealthUpdate Event_HealthUpdate;
        public event IShipSystem.ModuleEfficiencyUpdate Event_EfficiencyUpdate;


        public void Initialization(ShipAISO moduleSO)
        {
            m_AI = new ShipAI(moduleSO);
        }

        public ShipAISO GetModuleSO()
        {
            return m_AI.ModuleSO;
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