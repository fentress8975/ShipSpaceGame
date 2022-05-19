using UnityEngine;

public class WeaponsSystem : MonoBehaviour, IShipSystem, IShipSystemSO<ShipWeaponSO>
{

    public ShipWeapon m_Weapon;

    public event IShipSystem.ModuleHealthUpdate Event_HealthUpdate;
    public event IShipSystem.ModuleEfficiencyUpdate Event_EfficiencyUpdate;


    public void Initialization(ShipWeaponSO moduleSO)
    {
        m_Weapon = new ShipWeapon(moduleSO);
    }

    public ShipWeaponSO GetModuleSO()
    {
        return m_Weapon.m_ModuleSO;
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
