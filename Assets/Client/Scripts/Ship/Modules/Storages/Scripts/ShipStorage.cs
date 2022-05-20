namespace ShipModule
{
    public class ShipStorage : BaseModule<ShipStorageSO>, IShipResource, IDamageable
    {
        public ShipStorage(ShipStorageSO module) : base(module)
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