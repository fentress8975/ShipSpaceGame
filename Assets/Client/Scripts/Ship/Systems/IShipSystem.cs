using ShipBase.Containers;
using ShipModule;
using System;
using System.Collections.Generic;


namespace ShipSystem
{
    public interface IShipSystem : IDamageable
    {
        delegate void ModuleHealthUpdate(ModuleType module, float health);
        delegate void ModuleEfficiencyUpdate(float percent);
        event ModuleHealthUpdate Event_HealthUpdate;
        event ModuleEfficiencyUpdate Event_EfficiencyUpdate;


        public float EfficiencyCalculator(float baseHealth, float currentHealth)
        {
            //x^2, округляя до 1 числа после запятой
            float percent = (float)Math.Round(Math.Pow(currentHealth / baseHealth, 2), 1); 
            //Дальше идет посчет всех возможных усилителей и бонусов... Когда их добавлю
            return percent;
        }

        public IShipModule GetModule();

        public float GetSystemWeight();

        public float GetSystemHealth();

        public Dictionary<string,float> GetModuleInfo();
    }
}
