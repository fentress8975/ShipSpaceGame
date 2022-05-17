using UnityEngine;

public class WeaponsSystem : MonoBehaviour, IShipSystem
{

    public ShipWeapon m_Weapon = new ShipWeapon();

    public event IShipSystem.ModuleHealthUpdate Event_HealthUpdate;
    public event IShipSystem.ModuleEfficiencyUpdate Event_EfficiencyUpdate;

    public float EfficiencyCalculator()
    {
        throw new System.NotImplementedException();
    }

    public BaseModule GetModuleSO()
    {
        return m_Weapon;
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
        m_Weapon.Initialization(moduleSO);
    }
}
