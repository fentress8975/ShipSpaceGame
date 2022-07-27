using AI.Enemy;
using ShipBase;
using ShipBase.Containers;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace StageCore
{
    public class EnemyBuilder : MonoBehaviour
    {

        [SerializeField]
        private ShipEngineSO[] m_ListEnginesSO;
        [SerializeField]
        private ShipHullSO[] m_ListHullsSO;
        [SerializeField]
        private ShipStorageSO[] m_ListStoragesSO;
        [SerializeField]
        private ShipWeaponSO[] m_ListWeaponsSO;


        private void Start()
        {
            Initialization();
        }

        public void Initialization()
        {
            m_ListEnginesSO = Resources.LoadAll<ShipEngineSO>("Ship/Scriptable Object/Modules/Engines");
            m_ListHullsSO = Resources.LoadAll<ShipHullSO>("Ship/Scriptable Object/Modules/Hulls");
            m_ListStoragesSO = Resources.LoadAll<ShipStorageSO>("Ship/Scriptable Object/Modules/Storages");
            m_ListWeaponsSO = Resources.LoadAll<ShipWeaponSO>("Ship/Scriptable Object/Modules/weapons");
        }


        public EnemyController BuildEnemyShip(float difficulty)
        {
            ShipModules shipModule = BuildShipModules();
            Ship ship = BuildShip();

            EnemyController enemyController = new();
            enemyController.Initialization(ship, shipModule);

            return enemyController;
        }

        private ShipModules BuildShipModules()
        {
            throw new NotImplementedException();
        }

        private Ship BuildShip()
        {
            throw new NotImplementedException();
        }
    }
}
