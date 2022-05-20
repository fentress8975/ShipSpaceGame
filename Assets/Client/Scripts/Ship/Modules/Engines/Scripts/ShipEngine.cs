namespace ShipModule
{
    public class ShipEngine : BaseModule<ShipEngineSO>, IShipResource, IDamageable
    {
        public ShipEngine(ShipEngineSO module) : base(module)
        {
        }

        public override float GetBaseHealth()
        {
            return ModuleSO.m_fHealth;
        }

        protected override void Setting()
        {
            m_fHealth = ModuleSO.m_fHealth;
            m_fWeight = ModuleSO.m_fWeight;
        }
    }
}