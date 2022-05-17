using UnityEngine;


public class RotationHandler : MonoBehaviour
{
    private Plane m_GamePlane;
    private Vector3 m_LockAt;
    private Camera m_MainCamera;
    public void Initialization(Ship ship)
    {
        InputsControl.instance.Event_MousePosition.AddListener(RotationCalculator);
        m_GamePlane = new Plane(transform.up, transform.position);
        m_MainCamera = Camera.main;
    }

    private void OnDestroy()
    {
        InputsControl.instance.Event_MousePosition.RemoveListener(RotationCalculator);
    }

    private void RotationCalculator(Vector2 x)
    {
        GetTargetDirection(x);

    }
    private void GetTargetDirection(Vector2 x)
    {
        Vector3 position = m_MainCamera.ScreenToWorldPoint(x);
        Vector3 direction = m_MainCamera.transform.forward;
        Ray ray = new Ray(position, direction);
        if (m_GamePlane.Raycast(ray, out float distance))
        {
            position += (direction * distance);
            m_LockAt = position;
        }
    }

    private void Rotate()
    {
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(m_LockAt), Time.time * 2f);
        transform.LookAt(m_LockAt);
    }

    private void FixedUpdate()
    {
        Rotate();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(m_LockAt, 0.8f);
    }
}
