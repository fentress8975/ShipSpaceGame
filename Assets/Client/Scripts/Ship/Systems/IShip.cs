using ShipBase.Containers;


namespace ShipBase
{
    public interface IShip
    {
        public void Initialization(ShipModules modules);
        public ShipModuleHealth GetShipHealth();


    }
}
