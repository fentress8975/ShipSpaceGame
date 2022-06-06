using ShipBase;
using ShipBase.Containers;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(MovementHandler))]
[RequireComponent(typeof(RotationHandler))]
[RequireComponent(typeof(WeaponHandler))]


public class PlayerShip : MonoBehaviour
{
    public UnityEvent<Vector2> Event_ShipMovementUpdate;
    [SerializeField]
    private Ship m_Ship;
    private MovementHandler m_MovementHandler;
    private RotationHandler m_RotationHandler;
    private WeaponHandler m_WeaponHandler;
    [SerializeField]
    private UIController m_UIController;

    [SerializeField]
    public ShipModules test;
    public TestInitModules TestInitModules;

    private void Start()
    {
        TestInitModules = GetComponent<TestInitModules>();
        //Only for test
        test = new ShipModules(TestInitModules.m_ShipHullSO,
                               TestInitModules.m_EngineSO,
                               TestInitModules.m_WeaponSO,
                               TestInitModules.m_StorageSO,
                               TestInitModules.m_AISO);

        m_MovementHandler = GetComponent<MovementHandler>();
        m_RotationHandler = GetComponent<RotationHandler>();
        m_WeaponHandler=GetComponent<WeaponHandler>();

        m_Ship = GetComponentInChildren<Ship>();
        m_Ship.Initialization(test);
        m_Ship.Event_HealthUpdate.AddListener(UIHealthUpdater);
        m_MovementHandler.Event_StabilazionChanged.AddListener(UIEngineUpdater);

        m_MovementHandler.Initialization(m_Ship);
        m_RotationHandler.Initialization(m_Ship);
        m_WeaponHandler.Initialization(m_Ship);

        m_UIController.Ininitialization(m_Ship.GetShipHealth(), m_MovementHandler.isStabilazed(), m_Ship.GetSystem(SystemType.Weapon).GetModule().GetName());

        FollowTheObject followTheObject = Camera.main.GetComponent<FollowTheObject>();
        followTheObject.Initialization(m_Ship.gameObject, new Vector3(0, 6, -3));
    }

    private void UIHealthUpdater(ShipModuleHealth shipHealth)
    {
        m_UIController.HealthUpdate(shipHealth);
    }
    private void UIWeaponUpdater(string weaponName)
    {
        m_UIController.WeaponUpdate(weaponName);
    }

    private void UIEngineUpdater(bool stabilazed)
    {
        m_UIController.EngineUpdate(stabilazed);
    }

    private void OnDestroy()
    {
        m_Ship.Event_HealthUpdate.RemoveListener(UIHealthUpdater);
        m_MovementHandler.Event_StabilazionChanged.RemoveListener(UIEngineUpdater);
    }
}
