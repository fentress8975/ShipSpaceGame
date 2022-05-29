using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float m_fSpeed;
    private int m_iDamage;
    private float m_fDelay = 10f;
    private Rigidbody m_Rigidbody;

    public void Initialization(float speed, int damage)
    {
        m_fSpeed = speed;
        m_iDamage = damage;
        m_Rigidbody = gameObject.AddComponent<Rigidbody>();
        StartCoroutine(TestDestroy());

    }
    private void FixedUpdate()
    {
        m_Rigidbody.velocity = transform.forward * m_fSpeed;
    }

    private IEnumerator TestDestroy()
    {
        yield return new WaitForSeconds(m_fDelay);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<DummyScript>(out DummyScript target))
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
