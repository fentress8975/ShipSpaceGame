using UnityEngine;

public class AISystem : MonoBehaviour, IShipSystem
{
    private ShipAI m_AI = new ShipAI();

    public event IShipSystem.ModuleHealthUpdate Event_HealthUpdate;
    public event IShipSystem.ModuleEfficiencyUpdate Event_EfficiencyUpdate;

    public float EfficiencyCalculator()
    {
        throw new System.NotImplementedException();
    }

    public BaseModule GetModuleSO()
    {
        return m_AI;
    }

    public float GetSystemHealth()
    {
        throw new System.NotImplementedException();
    }

    public float GetSystemWeight()
    {
        throw new System.NotImplementedException();
    }

    public void Initialization(object moduleSO)
    {
        m_AI.Initialization(moduleSO);
    }
}
