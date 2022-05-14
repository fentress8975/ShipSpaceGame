using UnityEngine;

public class HullSystem : MonoBehaviour, IShipSystem
{
    private ShipHull m_Hull;

    public event IShipSystem.ModuleHealthUpdate Event_HealthUpdate;
    public event IShipSystem.ModuleEfficiencyUpdate Event_EfficiencyUpdate;

    public float EfficiencyCalculator()
    {
        throw new System.NotImplementedException();
    }

    public float GetSystemWeight()
    {
        throw new System.NotImplementedException();
    }

    public void Initialization(object moduleSO)
    {
        throw new System.NotImplementedException();
    }
}
