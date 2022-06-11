using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float m_fSpeed;
    [SerializeField]
    private int m_iDamage;
    private int m_fDelay;
    private Rigidbody m_Rigidbody;


    public void Initialization(float speed, int damage, int delay)
    {
        m_fDelay = delay;
        m_fSpeed = speed;
        m_iDamage = damage;
        if (gameObject.TryGetComponent(out m_Rigidbody))
        {
        }
        else
        {
            m_Rigidbody = gameObject.AddComponent<Rigidbody>();
        }
        gameObject.SetActive(true);
        StartCoroutine(DeactivateWithDelay());
        
    }


    private void Deactivate()
    {
        StopAllCoroutines();
        gameObject.SetActive(false);
    }

    private IEnumerator DeactivateWithDelay()
    {
        yield return new WaitForSeconds(m_fDelay);
        StopAllCoroutines();
        gameObject.SetActive(false);
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
            Deactivate();
        }
        else if (collision.gameObject.TryGetComponent(out IDamageable targetShip))
        {
            targetShip.TakeDamage(m_iDamage);
            Deactivate();
        }
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

}
