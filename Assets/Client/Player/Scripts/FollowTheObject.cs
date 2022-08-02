using UnityEngine;


public class FollowTheObject : MonoBehaviour
{
    [SerializeField]
    private GameObject m_GOTarget;
    private Vector3 m_Offset;


    public void Initialization(GameObject target, Vector3 offset)
    {
        m_GOTarget = target;
        m_Offset = offset;
    }

    private void FixedUpdate()
    {
        transform.position = m_GOTarget.transform.position + m_Offset;
    }
}
