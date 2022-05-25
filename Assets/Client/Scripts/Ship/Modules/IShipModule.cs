using System.Collections.Generic;

namespace  ShipModule


{
    public interface IShipModule
    {
        public Dictionary<string, float> GetModuleInformation();

        public float GetBaseHealth();

        public float GetModuleHealth();

        public float GetModuleWeight();
    }
}
