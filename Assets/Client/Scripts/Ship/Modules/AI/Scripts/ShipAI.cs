using UnityEngine;

public class ShipAI : BaseModule<ShipAISO>, IShipResource, IDamageable
{
    public ShipAI(ShipAISO module) : base(module)
    {
    }

    public override float GetBaseHealth()
    {
        throw new System.NotImplementedException();
    }

    protected override void Setting()
    {
        m_fHealth = m_ModuleSO.m_fHealth;
        m_fWeight = m_ModuleSO.m_fWeight;
    }
}
