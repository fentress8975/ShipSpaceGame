using UnityEngine;

public class HullSystem : MonoBehaviour, IShipSystem, IShipSystemSO<ShipHullSO>
{
    private ShipHull m_Hull;

    public event IShipSystem.ModuleHealthUpdate Event_HealthUpdate;
    public event IShipSystem.ModuleEfficiencyUpdate Event_EfficiencyUpdate;


    public void Initialization(ShipHullSO moduleSO)
    {
        m_Hull = new ShipHull(moduleSO);

    }

    public ShipHullSO GetModuleSO()
    {
        return m_Hull.m_ModuleSO;
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
