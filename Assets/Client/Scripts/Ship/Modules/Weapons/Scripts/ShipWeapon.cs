namespace ShipModule
{
    public class ShipWeapon : BaseModule<ShipWeaponSO>, IShipResource, IDamageable
    {
        public ShipWeapon(ShipWeaponSO module) : base(module)
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