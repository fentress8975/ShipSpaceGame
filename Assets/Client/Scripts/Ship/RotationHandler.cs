using ShipBase;
using UnityEngine;


public class RotationHandler : MonoBehaviour
{
    private Plane m_GamePlane;
    private Vector3 m_LockAt;
    private Camera m_MainCamera;
    private Rigidbody m_Rigidbody;
    [SerializeField]
    private Vector3 m_EulerAngleVelocity = new Vector3(0, 20, 0);
    private GameObject m_Rotation;


    public void Initialization(Rigidbody shipRB)
    {
        m_Rigidbody = shipRB;

        InputsControl.instance.Event_MousePosition.AddListener(RotationCalculator);
        m_GamePlane = new Plane(transform.up, Vector3.zero);
        m_MainCamera = Camera.main;
        m_Rotation = new GameObject("Ship Rotation");
        m_Rotation.transform.parent = shipRB.transform;
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
            m_LockAt.y = 0f;
        }
    }

    private void Rotate()
    {
        m_Rotation.transform.LookAt(m_LockAt);
        Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.fixedDeltaTime);
        m_Rigidbody.MoveRotation(m_Rotation.transform.rotation * deltaRotation);
    }

    private void FixedUpdate()
    {
        Rotate();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(m_LockAt, 0.5f);
    }
}
