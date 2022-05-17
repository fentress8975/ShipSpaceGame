using UnityEngine;

public class EngineSystem : MonoBehaviour, IShipSystem
{
    public event IShipSystem.ModuleHealthUpdate Event_HealthUpdate;
    public event IShipSystem.ModuleEfficiencyUpdate Event_EfficiencyUpdate;

    private ShipEngine m_Engine = new ShipEngine();


    public void Initialization(object engineSO)
    {
        m_Engine.Initialization(engineSO);
    }

    public void TakeDamage(float damage)
    {

        Event_HealthUpdate?.Invoke(ModuleType.Engine, m_Engine.GetModuleHealth());
    }

    public void TakeDamage(float damage, string damageType)
    {

        Event_HealthUpdate?.Invoke(ModuleType.Engine, m_Engine.GetModuleHealth());
    }

    public BaseModule GetModuleSO()
    {
        return m_Engine;
    }

    public float GetSystemWeight()
    {
        return m_Engine.GetModuleWeight();
    }

    public float GetSystemHealth()
    {
        return m_Engine.GetModuleHealth();
    }
}


