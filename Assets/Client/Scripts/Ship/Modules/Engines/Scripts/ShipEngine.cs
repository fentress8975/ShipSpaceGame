using UnityEngine;


public class ShipEngine : BaseModule, IShipResource, IDamageable
{
    private ShipEngineSO m_EngineSO;

    

    public override void Initialization(object module) 
    {
        ShipEngineSO engine = module as ShipEngineSO;
        m_EngineSO = engine;
        m_fHealth = engine.m_fHealth;
    }

    public override float GetBaseHealth()
    {
        return m_EngineSO.m_fHealth;
    }
}
