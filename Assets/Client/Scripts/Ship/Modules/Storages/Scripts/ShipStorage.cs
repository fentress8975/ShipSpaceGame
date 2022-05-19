using UnityEngine;

public class ShipStorage : BaseModule<ShipStorageSO>, IShipResource, IDamageable
{
    public ShipStorage(ShipStorageSO module) : base(module)
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
