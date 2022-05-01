using UnityEngine;
using UnityEngine.Events;

public class PlayerShip : MonoBehaviour, IControllable
{
    public UnityEvent<Vector2> Event_ShipMoving;
    [SerializeField]
    private ShipSystem m_ShipSystem;


    public void Initialization()
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

    private void Start()
    {
        InputsControl.instance.Event_Movement.AddListener(Movement);
        m_ShipSystem.Initialization(this);

    }

    private void OnDestroy()
    {
        InputsControl.instance.Event_Movement.RemoveListener(Movement);
    }
}
