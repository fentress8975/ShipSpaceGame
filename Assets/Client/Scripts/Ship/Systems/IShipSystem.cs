using System;


public interface IShipSystem
{
    delegate void ModuleHealthUpdate(ModuleType module, float health);
    event ModuleHealthUpdate Event_HealthUpdate;
    delegate void ModuleEfficiencyUpdate(float percent);
    event ModuleEfficiencyUpdate Event_EfficiencyUpdate;


    
    public float EfficiencyCalculator(float baseHealth, float currentHealth)
    {
        float percent = (float)Math.Round(Math.Pow(currentHealth / baseHealth, 2), 1); //x^2, округляя до 1 числа после запятой
        //Дальше идет посчет всех возможных усилителей и бонусов... Когда их добавлю
        return percent;
    }
    
    public float GetSystemWeight();
    public float GetSystemHealth();
}

