using System;
using UnityEngine;

public class EngineSystem : MonoBehaviour, IShipSystem
{
    public event IShipSystem.ModuleHealthUpdate Event_HealthUpdate;
    public event IShipSystem.ModuleEfficiencyUpdate Event_EfficiencyUpdate;

    private ShipEngine m_Engine;

    

    public void Initialization(object engineSO)
    {
        m_Engine = new ShipEngine();
        m_Engine.Initialization(engineSO);
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
        float percent = (float)Math.Round(Math.Pow(m_Engine.GetModuleHealth() / m_Engine.GetBaseHealth(), 2), 1); //x^2, округляя до 1 числа после запятой
        //Дальше идет посчет всех возможных усилителей и бонусов... Когда их добавлю
        return percent;
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

