using ShipBase.Containers;
using ShipSystem;
using System.Collections.Generic;
using UnityEngine;


namespace ShipBase
{
    [RequireComponent(typeof(WeaponsSystem))]
    [RequireComponent(typeof(EngineSystem))]
    [RequireComponent(typeof(StorageSystem))]
    [RequireComponent(typeof(HullSystem))]
    [RequireComponent(typeof(AISystem))]
    [RequireComponent(typeof(ShipSounds))]
    [RequireComponent(typeof(Rigidbody))]


    public class Ship : MonoBehaviour, IShip
    {
        [SerializeField]
        private HullSystem m_HullSystem;
        [SerializeField]
        private EngineSystem m_EngineSystem;
        [SerializeField]
        private WeaponsSystem m_WeaponSystem;
        [SerializeField]
        private StorageSystem m_StorageSystem;
        [SerializeField]
        private AISystem m_AISystem;

        private ShipSounds m_SoundSystem;

        private List<IShipSystem> m_Modules = new List<IShipSystem>();


        public void Initialization(ShipModules modules)
        {
            m_HullSystem = GetComponent<HullSystem>();
            m_EngineSystem = GetComponent<EngineSystem>();
            m_WeaponSystem = GetComponent<WeaponsSystem>();
            m_StorageSystem = GetComponent<StorageSystem>();
            m_AISystem = GetComponent<AISystem>();

            m_SoundSystem = GetComponent<ShipSounds>();

            SystemsInitialization(modules);

            m_Modules.Add(m_HullSystem);
            m_Modules.Add(m_EngineSystem);
            m_Modules.Add(m_WeaponSystem);
            m_Modules.Add(m_StorageSystem);
            m_Modules.Add(m_AISystem);
        }

        public ShipModuleHealth GetShipHealth()
        {
            ShipModuleHealth shipModuleHealth = new ShipModuleHealth();
            foreach (var module in m_Modules)
            {

                switch (WhatSystemIsThis(module))
                {
                    case SystemType.Hull:
                        shipModuleHealth.HullHealth = module.GetSystemHealth();
                        break;
                    case SystemType.Engine:
                        shipModuleHealth.EngineHealth = module.GetSystemHealth();
                        break;
                    case SystemType.Weapon:
                        shipModuleHealth.WeaponHealth = module.GetSystemHealth();
                        break;
                    case SystemType.Storage:
                        shipModuleHealth.StorageHealth = module.GetSystemHealth();
                        break;
                    case SystemType.AI:
                        shipModuleHealth.AIHealth = module.GetSystemHealth();
                        break;
                    case SystemType.ERROR:
                        Debug.Log("SYSTEM TYPE ERROR!");
                        break;
                    default:
                        break;
                }
            }
            return shipModuleHealth;
        }

        private void SystemsInitialization(ShipModules modules)
        {
            m_HullSystem.Initialization(modules.m_ShipHullSO);
            m_EngineSystem.Initialization(modules.m_EngineSO);
            m_WeaponSystem.Initialization(modules.m_WeaponSO);
            m_StorageSystem.Initialization(modules.m_StorageSO);
            m_AISystem.Initialization(modules.m_AISO);
        }

        private SystemType WhatSystemIsThis(IShipSystem module)
        {
            if (module is ShipHullSO) return SystemType.Hull;
            if (module is ShipEngineSO) return SystemType.Engine;
            if (module is ShipWeaponSO) return SystemType.Weapon;
            if (module is ShipStorageSO) return SystemType.Storage;
            if (module is ShipAISO) return SystemType.AI;
            Debug.Log("SYSTEM TYPE ERROR!");
            return SystemType.ERROR;
        }
    }


    namespace Containers
    {
        public struct ShipModuleHealth
        {
            public float HullHealth;
            public float EngineHealth;
            public float WeaponHealth;
            public float StorageHealth;
            public float AIHealth;
        }

        public class ShipModules
        {
            public ShipHullSO m_ShipHullSO;
            public ShipEngineSO m_EngineSO;
            public ShipWeaponSO m_WeaponSO;
            public ShipStorageSO m_StorageSO;
            public ShipAISO m_AISO;

            public ShipModules(ShipHullSO shipHullSO, ShipEngineSO engineSO, ShipWeaponSO weaponSO, ShipStorageSO storageSO, ShipAISO aISO)
            {
                m_ShipHullSO = shipHullSO;
                m_EngineSO = engineSO;
                m_WeaponSO = weaponSO;
                m_StorageSO = storageSO;
                m_AISO = aISO;
            }

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

        public enum SystemType
        {
            Hull,
            Engine,
            Weapon,
            Storage,
            AI,
            ERROR
        }
    }
}