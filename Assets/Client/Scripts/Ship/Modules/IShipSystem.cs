using UnityEngine.Events;


    public interface IShipSystem
    {
    delegate void ModuleHealthUpdate(ModuleType module,float health);
    event ModuleHealthUpdate Event_HealthUpdate;
    delegate void ModuleEfficiencyUpdate(float percent);
    event ModuleEfficiencyUpdate Event_EfficiencyUpdate;

    public float EfficiencyCalculator();

    }

