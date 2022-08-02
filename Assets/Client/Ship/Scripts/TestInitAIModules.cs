using AI.Enemy;
using ShipBase;
using ShipBase.Containers;
using UnityEngine;

public class TestInitAIModules : MonoBehaviour
{
    [SerializeField]
    EnemyController controller;
    [SerializeField]
    Ship ship;
    ShipModules test;

    private void Awake()
    {
        test = new ShipModules(m_ShipHullSO,
                                 m_EngineSO,
                                 m_WeaponSO,
                                 m_StorageSO,
                                 m_AISO);
        controller.Initialization(ship, test);
    }

    public ShipHullSO m_ShipHullSO;
    public ShipEngineSO m_EngineSO;
    public ShipWeaponSO m_WeaponSO;
    public ShipStorageSO m_StorageSO;
    public ShipAISO m_AISO;


}
