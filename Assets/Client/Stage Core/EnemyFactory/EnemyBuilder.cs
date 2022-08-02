using AI.Enemy;
using ShipBase;
using ShipBase.Containers;
using System;
using UnityEngine;

namespace StageCore
{
    namespace Factory
    {
        public class EnemyBuilder
        {

            [SerializeField]
            private ShipEngineSO[] m_ListEnginesSO;
            [SerializeField]
            private ShipHullSO[] m_ListHullsSO;
            [SerializeField]
            private ShipStorageSO[] m_ListStoragesSO;
            [SerializeField]
            private ShipWeaponSO[] m_ListWeaponsSO;


            public void Initialization()
            {
                m_ListEnginesSO = Resources.LoadAll<ShipEngineSO>("Ship/Scriptable Object/Modules/Engines");
                m_ListHullsSO = Resources.LoadAll<ShipHullSO>("Ship/Scriptable Object/Modules/Hulls");
                m_ListStoragesSO = Resources.LoadAll<ShipStorageSO>("Ship/Scriptable Object/Modules/Storages");
                m_ListWeaponsSO = Resources.LoadAll<ShipWeaponSO>("Ship/Scriptable Object/Modules/weapons");
            }


            public EnemyController BuildEnemyShip(EnemyPresetSO enemyPresetSO, GameObject model)
            {
                ShipModules shipModules = BuildShipModules(enemyPresetSO);
                Ship ship = BuildShip(shipModules,model);
                EnemyController enemyController = CreateController(ship);
                ship.transform.parent = enemyController.transform;

                return enemyController;
            }

            private ShipModules BuildShipModules(EnemyPresetSO enemyPresetSO)
            {
                ShipHullSO hullSO = enemyPresetSO.Hull;
                ShipStorageSO storageSO = enemyPresetSO.Storage;
                ShipWeaponSO weaponSO = enemyPresetSO.Weapon;
                ShipEngineSO engineSO = enemyPresetSO.Engine;
                ShipAISO aISO = enemyPresetSO.AI;
                ShipModules modules = new(hullSO,engineSO,weaponSO,storageSO,aISO);
                return modules;
            }

            private Ship BuildShip(ShipModules modules, GameObject model)
            {
                Ship ship = model.AddComponent<Ship>();
                ship.Initialization(modules);
                return ship;
            }

            private EnemyController CreateController(Ship ship)
            {
                GameObject go = new GameObject("EnemyShip");
                EnemyController enemyController = go.AddComponent<EnemyController>();
                enemyController.Initialization(ship);
                return enemyController;

            }
        }
    }
}
