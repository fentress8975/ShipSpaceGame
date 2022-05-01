using UnityEngine;

[CreateAssetMenu(fileName = "Weapons", menuName = "Ship/Weapons", order = 0)]
public class ShipWeaponSO : ScriptableObject
{
    public enum WeaponType
    {
        Laser,
        Kinetic,
        HE
    }

    public GameObject m_Projectile;
    public string m_sWeaponName;
    public WeaponType m_Type;
    [Tooltip("In 1 min.")]
    public float m_fRateOfFire;
    public int m_iDamage;
    public int m_fSpeed;
    public AudioClip m_Audio;
}
