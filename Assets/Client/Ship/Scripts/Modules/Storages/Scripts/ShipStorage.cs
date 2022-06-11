using System.Collections.Generic;

namespace ShipModule
{
    public class ShipStorage : BaseModule<ShipStorageSO>, IShipResource, IDamageable, IShipModule
    {
        public ShipStorage(ShipStorageSO module) : base(module)
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