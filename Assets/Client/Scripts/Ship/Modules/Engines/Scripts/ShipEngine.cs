using UnityEngine;


public class ShipEngine : BaseModule, IShipResource, IDamageable
{
    private ShipEngineSO m_EngineSO;


    public override void Initialization(object module)
    {
        if (module is ShipEngineSO shipEngine)
        {
            Debug.Log($"Я {this} включился. Мне передали модулить типа {shipEngine.GetType()}");
            m_EngineSO = shipEngine;
            m_fHealth = shipEngine.m_fHealth;
            m_fWeight = shipEngine.m_fWeight;
        }
    }

    public override float GetBaseHealth()
    {
        return m_EngineSO.m_fHealth;
    }
}
