using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float m_fSpeed;
    private int m_iDamage;
    private float m_fDelay = 10f;

    public void CreateProjectile(float speed, int damage)
    {
        m_fSpeed = speed;
        m_iDamage = damage;
        StartCoroutine(TestDestroy());

    }
    private void Update()
    {
        gameObject.transform.position = gameObject.transform.position + Vector3.forward * m_fSpeed * Time.deltaTime;
    }

    private IEnumerator TestDestroy()
    {
        yield return new WaitForSeconds(m_fDelay);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
       
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

}
