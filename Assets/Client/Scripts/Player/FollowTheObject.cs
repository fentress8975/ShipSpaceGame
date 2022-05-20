using UnityEngine;


public class FollowTheObject : MonoBehaviour
{
    private GameObject m_GOTarget;
    private Vector3 m_V3Offset;


    public void Initialization(GameObject target, Vector3 offset)
    {
        m_GOTarget = target;
        m_V3Offset = offset;

    }

    private void FixedUpdate()
    {
        transform.position = m_GOTarget.transform.position + m_V3Offset;
    }
}
