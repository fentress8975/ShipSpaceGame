using ShipBase.Containers;
using System.Collections.Generic;

namespace ShipBase
{
    public interface IShip : IDamageable
    {
        public void Initialization(ShipModules modules, Faction.Side side);

        public BaseModulesHealth GetBaseShipHealth();

        public Dictionary<string, float> GetSystemInfo(SystemType system);
    }
}
