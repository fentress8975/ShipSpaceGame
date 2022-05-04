using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MovementHandler))]

public class PlayerShip : MonoBehaviour, IControllable
{
    public UnityEvent<Vector2> Event_ShipMoving;
    [SerializeField]
    private ShipSystem m_ShipSystem;
    private MovementHandler m_MovementHandler;


    private void Start()
    {
        m_MovementHandler = GetComponent<MovementHandler>();
        InputsControl.instance.Event_Movement.AddListener(Movement);
        m_ShipSystem.Initialization();
        m_MovementHandler.Initialization(m_ShipSystem);

    }

    private void OnDestroy()
    {
        InputsControl.instance.Event_Movement.RemoveListener(Movement);
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
