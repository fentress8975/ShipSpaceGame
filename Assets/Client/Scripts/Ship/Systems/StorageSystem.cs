using UnityEngine;

public class StorageSystem : MonoBehaviour, IShipSystem
{
    private ShipStorage m_Storage = new ShipStorage();

    public event IShipSystem.ModuleHealthUpdate Event_HealthUpdate;
    public event IShipSystem.ModuleEfficiencyUpdate Event_EfficiencyUpdate;

    public float EfficiencyCalculator()
    {
        throw new System.NotImplementedException();
    }

    public BaseModule GetModuleSO()
    {
        return m_Storage;
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
        m_Storage.Initialization(moduleSO);
    }
}
