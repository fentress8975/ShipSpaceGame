using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ShipModules/Weapon", order = 0)]
public class ShipWeaponSO : ScriptableObject
{
    public string m_sName;
    public float m_fHealth;
    public float m_fWeight;

    public enum WeaponType
    {
        Laser,
        Kinetic,
        HE
    }
    public GameObject m_Projectile;
    public WeaponType m_Type;
    [Tooltip("In 1 min.")]
    public float m_fRateOfFire;
    public int m_iDamage;
    public int m_fSpeed;
    public AudioClip m_Audio;
}
