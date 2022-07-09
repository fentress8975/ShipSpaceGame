using ShipBase;
using ShipBase.Containers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AI
{
    namespace Enemy
    {
        [RequireComponent(typeof(MovementAIHandler))]
        [RequireComponent(typeof(RotationAIHandler))]
        [RequireComponent(typeof(WeaponAIHandler))]
        [RequireComponent(typeof(TargetScaner))]
        [RequireComponent(typeof(EnemyBehavior))]


        public class EnemyController : MonoBehaviour
        {
            [SerializeField]
            private Ship m_Ship;
            private EnemyBehavior m_Behavior;
            private TargetScaner m_TargetScaner;
            private MovementAIHandler m_MovementHandler;
            private RotationAIHandler m_RotationHandler;
            private WeaponAIHandler m_WeaponHandler;

            public ShipModules test;
            [SerializeField]
            public TestInitModules TestInitModules;

            private void Start()
            {
                m_Ship = gameObject.GetComponentInChildren<Ship>();
                m_Behavior = gameObject.GetComponentInChildren<EnemyBehavior>();
                m_TargetScaner = gameObject.GetComponentInChildren<TargetScaner>();
                m_MovementHandler = gameObject.GetComponent<MovementAIHandler>();
                m_RotationHandler = gameObject.GetComponent<RotationAIHandler>();
                m_WeaponHandler = gameObject.GetComponent<WeaponAIHandler>();

                TestInitModules = GetComponent<TestInitModules>();
                //Only for test
                test = new ShipModules(TestInitModules.m_ShipHullSO,
                                       TestInitModules.m_EngineSO,
                                       TestInitModules.m_WeaponSO,
                                       TestInitModules.m_StorageSO,
                                       TestInitModules.m_AISO);

                m_Ship.Initialization(test);
                m_MovementHandler.Initialization(m_Ship, m_Behavior);
                m_RotationHandler.Initialization(m_Ship, m_Behavior);
                m_WeaponHandler.Initialization(m_Ship, m_Behavior);
                m_TargetScaner.Initialization();
                m_Behavior.Initialization(m_TargetScaner, m_MovementHandler, m_RotationHandler, m_WeaponHandler);
            }
        }
    }
}
