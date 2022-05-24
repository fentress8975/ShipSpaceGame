using UnityEngine;


public class RotationHandler : MonoBehaviour
{
    private Plane m_GamePlane;
    private Vector3 m_LockAt;
    private Camera m_MainCamera;
    private Rigidbody m_Rigidbody;
    [SerializeField]
    private float m_fRotationVelocity = 100f;
    private float m_fSpeedDamping = 1f;
    private RotationDirection m_RotationDirection;
    private GameObject m_Rotation;

    private enum RotationDirection
    {
        Clockwise,
        ConterClockWise
    }

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
        m_Rotation.transform.LookAt(m_LockAt);
        m_RotationDirection = GetTurningDirection();
        SpeedDampingCalculation();
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
        Vector3 dPerSeconds = new Vector3(0, m_fRotationVelocity * m_fSpeedDamping, 0);
        Quaternion deltaRotation;
        switch (m_RotationDirection)
        {
            case RotationDirection.Clockwise:
                deltaRotation = Quaternion.Euler(dPerSeconds * Time.fixedDeltaTime);
                m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotation);
                break;
            case RotationDirection.ConterClockWise:
                deltaRotation = Quaternion.Euler(-dPerSeconds * Time.fixedDeltaTime);
                m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotation);
                break;
        };
    }

    private void SpeedDampingCalculation()
    {
        m_fSpeedDamping = Mathf.InverseLerp(0f, m_fRotationVelocity*0.1f, Quaternion.Angle(m_Rotation.transform.rotation, m_Rigidbody.rotation));
        Debug.Log(m_fSpeedDamping);
    }

    //SLowdown, for better rotation at the end
    private RotationDirection GetTurningDirection()
    {
        if (m_Rotation.transform.localEulerAngles.y < 180)
        {
            return RotationDirection.Clockwise;
        }
        else
        {
            return RotationDirection.ConterClockWise;
        }
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
