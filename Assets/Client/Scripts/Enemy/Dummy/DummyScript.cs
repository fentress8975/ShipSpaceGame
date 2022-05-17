using UnityEngine;

public class DummyScript : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Damage_Text;


    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        ShowText();

    }

    private void ShowText()
    {
        Instantiate(m_Damage_Text, transform.position + Vector3.up * 2, Quaternion.identity, transform);
    }
}
