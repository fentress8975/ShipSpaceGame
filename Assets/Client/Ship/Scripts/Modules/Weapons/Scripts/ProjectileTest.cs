using ShipBase;
using UnityEngine;

public class ProjectileTest : MonoBehaviour
{
    [SerializeField]
    private float m_fSpeed;
    [SerializeField]
    private int m_iDamage;
    private float m_fDelay = 10f;
    private Rigidbody m_Rigidbody;


    private void Start()
    {
        if (gameObject.TryGetComponent(out m_Rigidbody))
        {
        }
        else
        {
            m_Rigidbody = gameObject.AddComponent<Rigidbody>();
        }
        Destroy(gameObject, m_fDelay);
    }

    private void FixedUpdate()
    {
        m_Rigidbody.velocity = transform.forward * m_fSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Ship target))
        {
            target.TakeDamage(m_iDamage);
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        StopAllCoroutines();
    }

}
