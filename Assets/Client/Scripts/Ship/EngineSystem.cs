using UnityEngine;

[RequireComponent(typeof(ShipEngine))]

public class EngineSystem : MonoBehaviour, IShipSystem
{
    public event IShipSystem.ModuleHealthUpdate Event_HealthUpdate;
    public event IShipSystem.ModuleEfficiencyUpdate Event_EfficiencyUpdate;

    private ShipEngine m_Engine;

    

    public void Initialization(ShipEngineSO engineSO)
    {
        m_Engine = GetComponent<ShipEngine>();
        m_Engine.Initialization(engineSO);

    }

    public ShipModuleHealth GetModuleHealth()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(float damage)
    {

        Event_HealthUpdate?.Invoke(ModuleType.Engine,m_Engine.GetModuleHealth());
    }

    public void TakeDamage(float damage, string damageType)
    {

        Event_HealthUpdate?.Invoke(ModuleType.Engine, m_Engine.GetModuleHealth());
    }

    public float EfficiencyCalculator()
    {
        float percent = (m_Engine.GetBaseHealth() - m_Engine.GetModuleHealth()) / 100;
        return percent;
    }
}

