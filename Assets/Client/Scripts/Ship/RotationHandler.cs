using UnityEngine;


public class RotationHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject m_GamePlane;
    private Plane m_Plane;
    private Vector3 m_LockAt;
    private Camera m_MainCamera;
    public void Initialization(ShipSystem ship)
    {
        InputsControl.instance.Event_MousePosition.AddListener(Rotation);
        m_Plane = new Plane(m_GamePlane.transform.up, m_GamePlane.transform.position);
        m_MainCamera = Camera.main;
    }

    private void OnDestroy()
    {
        InputsControl.instance.Event_MousePosition.RemoveListener(Rotation);
    }

    private void Rotation(Vector2 x)
    {
        GetPositionOnGamePlane(x);
        transform.LookAt(m_LockAt);
        
    }
    private void GetPositionOnGamePlane(Vector2 x)
    {
        Vector3 position = m_MainCamera.ScreenToWorldPoint(x);
        Vector3 direction = m_MainCamera.transform.forward;
        Ray ray = new Ray(position, direction);
        if (m_Plane.Raycast(ray, out float distance))
        {
            position += (direction*distance);
            m_LockAt = position;

        }
    }

    private void Start()
    {
        
    }

    private void Update()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(m_LockAt, 0.8f);
    }
}
