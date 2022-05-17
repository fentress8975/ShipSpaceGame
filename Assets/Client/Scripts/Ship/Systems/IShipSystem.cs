using System;


public interface IShipSystem
{
    delegate void ModuleHealthUpdate(ModuleType module, float health);
    event ModuleHealthUpdate Event_HealthUpdate;
    delegate void ModuleEfficiencyUpdate(float percent);
    event ModuleEfficiencyUpdate Event_EfficiencyUpdate;


    public void Initialization(object moduleSO);
    public float EfficiencyCalculator()
    {
        BaseModule module = GetModuleSO();
        float percent = (float)Math.Round(Math.Pow(module.GetModuleHealth() / module.GetBaseHealth(), 2), 1); //x^2, округляя до 1 числа после запятой
        //Дальше идет посчет всех возможных усилителей и бонусов... Когда их добавлю
        return percent;
    }
    public BaseModule GetModuleSO();
    public float GetSystemWeight();
    public float GetSystemHealth();
}

