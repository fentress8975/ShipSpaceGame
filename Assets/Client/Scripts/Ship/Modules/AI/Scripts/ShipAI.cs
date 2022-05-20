namespace ShipModule
{
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
            m_fHealth = ModuleSO.m_fHealth;
            m_fWeight = ModuleSO.m_fWeight;
        }
    }
}