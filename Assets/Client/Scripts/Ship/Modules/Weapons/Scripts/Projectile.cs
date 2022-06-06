using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float m_fSpeed;
    [SerializeField]
    private int m_iDamage;
    private float m_fDelay = 10f;
    private Rigidbody m_Rigidbody;

    public void Initialization(float speed, int damage)
    {
        m_fSpeed = speed;
        m_iDamage = damage;
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
        if (collision.gameObject.TryGetComponent<DummyScript>(out DummyScript target))
        {
            target.TakeDamage(m_iDamage);
            Destroy(gameObject);
        }
        else if(collision.gameObject.TryGetComponent(out IDamageable targetShip))
        {
            targetShip.TakeDamage(m_iDamage);
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        StopAllCoroutines();
    }

}
