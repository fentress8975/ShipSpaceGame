using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WeaponsSystem))]
[RequireComponent(typeof(EngineSystem))]
[RequireComponent(typeof(StorageSystem))]
[RequireComponent(typeof(HullSystem))]
[RequireComponent(typeof(AISystem))]
[RequireComponent(typeof(ShipSounds))]

public class Ship : MonoBehaviour, IShip
{

    [SerializeField]
    private WeaponsSystem m_WeaponSystem;
    [SerializeField]
    private EngineSystem m_EngineSystem;
    [SerializeField]
    private StorageSystem m_StorageSystem;
    [SerializeField]
    private HullSystem m_HullSystem;
    [SerializeField]
    private AISystem m_AISystem;
    [SerializeField]
    private ShipSounds m_SoundSystem;

    private List<IShipSystem> m_Modules;

    public void Initialization(ShipHullSO shipHullSO, ShipEngineSO shipEngineSO, ShipWeaponSO shipWeaponSO, ShipStorageSO shipStorageSO, ShipAISO shipAISO)
    {
        m_HullSystem = GetComponent<HullSystem>();
        m_HullSystem.Initialization(shipHullSO);
        m_EngineSystem = GetComponent<EngineSystem>();
        m_EngineSystem.Initialization(shipEngineSO);
        m_WeaponSystem = GetComponent<WeaponsSystem>();
        m_WeaponSystem.Initialization(shipWeaponSO);
        m_StorageSystem = GetComponent<StorageSystem>();
        m_StorageSystem.Initialization(shipStorageSO);
        m_AISystem = GetComponent<AISystem>();
        m_AISystem.Initialization(shipAISO);

        m_Modules.Add(m_HullSystem as IShipSystem);
        m_Modules.Add(m_EngineSystem as IShipSystem);
        m_Modules.Add(m_WeaponSystem as IShipSystem);
        m_Modules.Add(m_StorageSystem as IShipSystem);
        m_Modules.Add(m_AISystem as IShipSystem);

        m_SoundSystem = GetComponent<ShipSounds>();
    }

    public ShipModuleHealth GetShipHealth()
    {
        ShipModuleHealth shipModuleHealth = new ShipModuleHealth();
        foreach (var module in m_Modules)
        {

            switch (WhatSystemIsThis(module))
            {
                case ModuleType.Hull:
                    shipModuleHealth.HullHealth = module.GetSystemHealth();
                    break;
                case ModuleType.Engine:
                    shipModuleHealth.EngineHealth = module.GetSystemHealth();
                    break;
                case ModuleType.Weapon:
                    shipModuleHealth.WeaponHealth = module.GetSystemHealth();
                    break;
                case ModuleType.Storage:
                    shipModuleHealth.StorageHealth = module.GetSystemHealth();
                    break;
                case ModuleType.AI:
                    shipModuleHealth.AIHealth = module.GetSystemHealth();
                    break;
                case ModuleType.ERROR:
                    Debug.Log("SYSTEM TYPE ERROR!");
                    break;
                default:
                    break;
            }
        }
        return shipModuleHealth;
    }

    private ModuleType WhatSystemIsThis(IShipSystem module)
    {
        if (module is HullSystem) return ModuleType.Hull;
        if (module is EngineSystem) return ModuleType.Engine;
        if (module is WeaponsSystem) return ModuleType.Weapon;
        if (module is StorageSystem) return ModuleType.Storage;
        if (module is AISystem) return ModuleType.AI;
        Debug.Log("SYSTEM TYPE ERROR!");
        return ModuleType.ERROR;
    }
}

public struct ShipModuleHealth
{
    public float HullHealth;
    public float EngineHealth;
    public float WeaponHealth;
    public float StorageHealth;
    public float AIHealth;
}

public enum ModuleType
{
    Hull,
    Engine,
    Weapon,
    Storage,
    AI,
    ERROR
}
