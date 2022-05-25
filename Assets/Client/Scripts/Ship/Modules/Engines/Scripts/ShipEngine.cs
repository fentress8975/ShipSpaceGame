using System.Collections.Generic;

namespace ShipModule
{
    public class ShipEngine : BaseModule<ShipEngineSO>, IShipResource, IDamageable, IShipModule
    {
        public float m_fPower { get; private set; }
        public float m_fRotationSpeed { get; private set; }

        public ShipEngine(ShipEngineSO module) : base(module)
        {
        }

        public override float GetBaseHealth()
        {
            return m_ModuleSO.m_fHealth;
        }

        public Dictionary<string, float> GetModuleInformation()
        {
            Dictionary<string, float> info = GetBaseInformation();
            info.Add("Acceleration Power", m_ModuleSO.m_fAccelerationPower);
            info.Add("Rotation Speed", m_ModuleSO.m_fRotationSpeed);
            return info;
        }

        protected override void Setting()
        {
            m_sName = m_ModuleSO.m_sName;
            m_fHealth = m_ModuleSO.m_fHealth;
            m_fWeight = m_ModuleSO.m_fWeight;
            m_fPower = m_ModuleSO.m_fAccelerationPower;
            m_fRotationSpeed = m_ModuleSO.m_fRotationSpeed;
        }
    }
}