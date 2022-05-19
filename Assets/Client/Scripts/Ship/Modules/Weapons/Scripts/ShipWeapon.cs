using UnityEngine;

public class ShipWeapon : BaseModule<ShipWeaponSO>, IShipResource, IDamageable
{



    public ShipWeapon(ShipWeaponSO module) : base(module)
    {

    }

    public override float GetBaseHealth()
    {
        return m_ModuleSO.m_fHealth;
    }

    protected override void Setting()
    {
        m_fHealth = m_ModuleSO.m_fHealth;
        m_fWeight = m_ModuleSO.m_fWeight;
    }
}
