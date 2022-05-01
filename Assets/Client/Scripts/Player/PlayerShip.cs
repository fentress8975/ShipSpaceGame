using UnityEngine;

public class PlayerShip : MonoBehaviour, IControllable
{

    [SerializeField]
    private ShipSystem m_ShipSystem;

    public void FireWeapon()
    {
        Debug.Log("PEW PEW");
    }

    public void Movement(Vector2 axis)
    {
        
    }

    private void Start()
    {
        m_ShipSystem.Initialization();

    }
}
