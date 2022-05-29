using UnityEngine;

public class DummyScript : MonoBehaviour, IDamageable
{
    [SerializeField]
    private GameObject m_Damage_Text;

    public void TakeDamage(float damage)
    {
        ShowText();
    }

    public void TakeDamage(float damage, string damageType)
    {
        ShowText();
    }

    private void ShowText()
    {
        Instantiate(m_Damage_Text, transform.position + Vector3.up * 2, Quaternion.identity, transform);
    }
}
