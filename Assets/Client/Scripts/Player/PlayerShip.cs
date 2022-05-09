using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MovementHandler))]
[RequireComponent(typeof(RotationHandler))]

public class PlayerShip : MonoBehaviour, IControllable
{
    public UnityEvent<Vector2> Event_ShipMoving;
    [SerializeField]
    private ShipSystem m_ShipSystem;
    private MovementHandler m_MovementHandler;
    private RotationHandler m_RotationHandler;


    private void Start()
    {
        m_MovementHandler = GetComponent<MovementHandler>();
        m_RotationHandler = GetComponent<RotationHandler>();
        m_ShipSystem.Initialization();
        m_MovementHandler.Initialization(m_ShipSystem);
        m_RotationHandler.Initialization(m_ShipSystem);

    }

    private void OnDestroy()
    {
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
