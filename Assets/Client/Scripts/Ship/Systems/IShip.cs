using ShipBase.Containers;
using System.Collections.Generic;

namespace ShipBase
{
    public interface IShip : IDamageable
    {
        public void Initialization(ShipModules modules);

        public ShipModuleHealth GetShipHealth();

        public Dictionary<string, float> GetSystemInfo(SystemType system);
    }
}
