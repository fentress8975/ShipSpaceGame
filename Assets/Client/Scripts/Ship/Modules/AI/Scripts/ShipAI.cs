using System.Collections.Generic;

namespace ShipModule
{
    public class ShipAI : BaseModule<ShipAISO>, IShipResource, IDamageable, IShipModule
    {
        public ShipAI(ShipAISO module) : base(module)
        {
        }

        public override float GetBaseHealth()
        {
            throw new System.NotImplementedException();
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