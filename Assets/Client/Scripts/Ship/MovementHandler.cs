using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    private const float rotationSpeed = 10f;
    private const float speed = 5f;
    private bool m_bIsMoving = false;
    private Vector3 m_MovingDirection = Vector3.zero;
    public void Initialization(Ship ship)
    {
        InputsControl.instance.Event_Movement.AddListener(Movement);
    }
    private void OnDestroy()
    {
        InputsControl.instance.Event_Movement.RemoveListener(Movement);
    }

    public void Movement(Vector2 axis, bool isMoving)
    {
        m_bIsMoving = isMoving;
        m_MovingDirection = new Vector3(0, axis.x, axis.y);
    }

    private void Update()
    {
        Acceleration();
        Rotate();
    }


    private void Acceleration()
    {

        transform.position += transform.forward * m_MovingDirection.z * speed * Time.deltaTime;
    }

    private void Rotate()
    {
        transform.Rotate(0, m_MovingDirection.y * rotationSpeed * 10 * Time.deltaTime, 0, Space.Self);
    }


}


