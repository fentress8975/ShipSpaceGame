using UnityEngine;

public class EngineSystem : MonoBehaviour, IShipSystem, IShipSystemSO<ShipEngineSO>
{
    public event IShipSystem.ModuleHealthUpdate Event_HealthUpdate;
    public event IShipSystem.ModuleEfficiencyUpdate Event_EfficiencyUpdate;

    private ShipEngine m_Engine;


    public void Initialization(ShipEngineSO engineSO)
    {
        m_Engine = new ShipEngine(engineSO);
    }

    public ShipEngineSO GetModuleSO()
    {
        return m_Engine.m_ModuleSO;
    }

    public float GetSystemWeight()
    {
        return GetModuleSO().m_fWeight;
    }

    public float GetSystemHealth()
    {
        return GetModuleSO().m_fHealth;
    }

    public void TakeDamage(float damage)
    {

        Event_HealthUpdate?.Invoke(ModuleType.Engine, m_Engine.GetModuleHealth());
    }

    public void TakeDamage(float damage, string damageType)
    {

        Event_HealthUpdate?.Invoke(ModuleType.Engine, m_Engine.GetModuleHealth());
    }
}


