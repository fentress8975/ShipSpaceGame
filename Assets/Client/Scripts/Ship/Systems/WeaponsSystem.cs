using ShipModule;
using UnityEngine;


namespace ShipSystem
{
    public class WeaponsSystem : MonoBehaviour, IShipSystem, IShipSystemSO<ShipWeaponSO>
    {
        public event IShipSystem.ModuleHealthUpdate Event_HealthUpdate;
        public event IShipSystem.ModuleEfficiencyUpdate Event_EfficiencyUpdate;

        public ShipWeapon m_Weapon;


        public void Initialization(ShipWeaponSO moduleSO)
        {
            m_Weapon = new ShipWeapon(moduleSO);
        }

        public ShipWeaponSO GetModuleSO()
        {
            return m_Weapon.ModuleSO;
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
}