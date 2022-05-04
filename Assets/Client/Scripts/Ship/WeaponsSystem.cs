using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class WeaponsSystem : MonoBehaviour
{
    public UnityEvent<AudioClip> Shoot;

    public ShipWeaponSO m_Weapon;
    
    
    public void Initialization(ShipWeaponSO shipWeapon)
    {
        m_Weapon = shipWeapon;
    }

    private void Start()
    {
        //StartCoroutine(FireWeapon());
    }

    public IEnumerator FireWeapon()
    {
        GameObject projectiles = new GameObject("Projectile");
        while (true)
        {
            GameObject temp = Instantiate(m_Weapon.m_Projectile,gameObject.transform.position,m_Weapon.m_Projectile.transform.rotation);
            temp.name = m_Weapon.m_sWeaponName + " projectile";
            Projectile projectile = temp.GetComponent<Projectile>();
            projectile.CreateProjectile(m_Weapon.m_fSpeed, m_Weapon.m_iDamage);
            Shoot.Invoke(m_Weapon.m_Audio);
            yield return new WaitForSeconds(60 / m_Weapon.m_fRateOfFire);
        }
    }
}
