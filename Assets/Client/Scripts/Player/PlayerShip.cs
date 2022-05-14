using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MovementHandler))]
[RequireComponent(typeof(RotationHandler))]
[RequireComponent(typeof(Ship))]

public class PlayerShip : MonoBehaviour, IControllable
{
    public UnityEvent<Vector2> Event_ShipMoving;

    [SerializeField]
    private Ship m_Ship;
    private MovementHandler m_MovementHandler;
    private RotationHandler m_RotationHandler;


    private void Start()
    {
        m_MovementHandler = GetComponent<MovementHandler>();
        m_RotationHandler = GetComponent<RotationHandler>();
        m_Ship = GetComponent<Ship>();
        m_Ship.Initialization();
        m_MovementHandler.Initialization(m_Ship);
        m_RotationHandler.Initialization(m_Ship);

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
