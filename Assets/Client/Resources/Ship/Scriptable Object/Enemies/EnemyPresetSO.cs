using UnityEngine;
using ShipBase;


namespace StageCore
{
    namespace Factory
    {
        [CreateAssetMenu(fileName = "Enemy", menuName = "Enemy", order = 0)]
        public class EnemyPresetSO : ScriptableObject
        {
            public string Name;
            public ShipHullSO Hull;
            public ShipEngineSO Engine;
            public ShipWeaponSO Weapon;
            public ShipStorageSO Storage;
            public ShipAISO AI;
        }
    }
}