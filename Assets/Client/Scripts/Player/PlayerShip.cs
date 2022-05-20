using ShipBase;
using ShipBase.Containers;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(MovementHandler))]
[RequireComponent(typeof(RotationHandler))]


public class PlayerShip : MonoBehaviour, IControllable
{
    public UnityEvent<Vector2> Event_ShipMoving;
    [SerializeField]
    private Ship m_Ship;
    private MovementHandler m_MovementHandler;
    private RotationHandler m_RotationHandler;

    [SerializeField]
    public ShipModules test;
    public TestInitModules TestInitModules;

    private void Start()
    {
        TestInitModules = GetComponent<TestInitModules>();
        //тест
        test = new ShipModules(TestInitModules.m_ShipHullSO,
                               TestInitModules.m_EngineSO,
                               TestInitModules.m_WeaponSO,
                               TestInitModules.m_StorageSO,
                               TestInitModules.m_AISO);

        m_MovementHandler = GetComponent<MovementHandler>();
        m_RotationHandler = GetComponent<RotationHandler>();
        m_Ship = GetComponentInChildren<Ship>();
        m_Ship.Initialization(test);
        m_MovementHandler.Initialization(m_Ship);
        m_RotationHandler.Initialization(m_Ship);

        FollowTheObject followTheObject = Camera.main.GetComponent<FollowTheObject>();
        followTheObject.Initialization(m_Ship.gameObject, new Vector3(0, 6, -3));
    }

    public void FireWeapon()
    {
        Debug.Log("PEW PEW");
    }

    public void Movement(Vector2 axis)
    {
        Event_ShipMoving?.Invoke(axis);
    }
}
