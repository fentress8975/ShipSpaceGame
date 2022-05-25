using System.Collections.Generic;

namespace ShipModule
{
    public class ShipHull : BaseModule<ShipHullSO>, IShipResource, IDamageable, IShipModule
    {
        public ShipHull(ShipHullSO module) : base(module)
        {
        }

        public override float GetBaseHealth()
        {
            return m_ModuleSO.m_fHealth;
        }

        public Dictionary<string, float> GetModuleInformation()
        {
            throw new System.NotImplementedException();
        }

        protected override void Setting()
        {
            m_sName = m_ModuleSO.m_sName;
            m_fHealth = m_ModuleSO.m_fHealth;
            m_fWeight = m_ModuleSO.m_fWeight;
        }
    }
}