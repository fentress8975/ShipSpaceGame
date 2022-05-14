using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class WeaponsSystem : MonoBehaviour,IShipSystem
{

    public ShipWeapon m_Weapon;

    public event IShipSystem.ModuleHealthUpdate Event_HealthUpdate;
    public event IShipSystem.ModuleEfficiencyUpdate Event_EfficiencyUpdate;

    public float EfficiencyCalculator()
    {
        throw new System.NotImplementedException();
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
        throw new System.NotImplementedException();
    }
}
