using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_WeaponIndicator : MonoBehaviour
{
    private TextMeshProUGUI m_CurrentWeapon;
    private string m_sWeaponName;


    public void Initialization(string weaponName)
    {
        m_CurrentWeapon = GetComponent<TextMeshProUGUI>();
        UpdateInformation(weaponName);
    }

    public void UpdateInformation(string weaponName)
    {
        m_sWeaponName = weaponName;
        ChangeIndicator();
    }

    private void ChangeIndicator()
    {
        m_CurrentWeapon.SetText("Weapon: " + m_sWeaponName);
    }
}
