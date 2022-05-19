using UnityEngine;

public class StorageSystem : MonoBehaviour, IShipSystem, IShipSystemSO<ShipStorageSO>
{
    private ShipStorage m_Storage;

    public event IShipSystem.ModuleHealthUpdate Event_HealthUpdate;
    public event IShipSystem.ModuleEfficiencyUpdate Event_EfficiencyUpdate;


    public void Initialization(ShipStorageSO moduleSO)
    {
        m_Storage = new ShipStorage(moduleSO);
    }

    public ShipStorageSO GetModuleSO()
    {
        return m_Storage.m_ModuleSO;
    }

    public float GetSystemHealth()
    {
        throw new System.NotImplementedException();
    }

    public float GetSystemWeight()
    {
        throw new System.NotImplementedException();
    }
}
