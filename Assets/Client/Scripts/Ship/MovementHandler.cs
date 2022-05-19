using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    private const float speed = 5f;
    private bool m_bIsMoving = false;
    private Rigidbody m_Rigidbody;

    private Vector3 m_MovingDirection = Vector3.zero;
    public void Initialization(Ship ship)
    {
        InputsControl.instance.Event_Movement.AddListener(Movement);
        m_Rigidbody = ship.GetComponent<Rigidbody>();
    }
    private void OnDestroy()
    {
        InputsControl.instance.Event_Movement.RemoveListener(Movement);
    }

    public void Movement(Vector2 axis, bool isMoving)
    {
        m_bIsMoving = isMoving;
        m_MovingDirection = new Vector3(axis.x, 0, axis.y);
    }

    private void FixedUpdate()
    {
        Acceleration();
    }


    private void Acceleration()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_MovingDirection * speed * Time.fixedDeltaTime);
    }

}


