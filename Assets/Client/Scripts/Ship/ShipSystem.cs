using UnityEngine;

[RequireComponent(typeof(WeaponsSystem))]
[RequireComponent(typeof(EngineSystem))]
[RequireComponent(typeof(ShipSounds))]

public class ShipSystem : MonoBehaviour, IShipResource
{

    [SerializeField]
    private WeaponsSystem m_WeaponSystem;
    [SerializeField]
    private EngineSystem m_EngineSystem;
    [SerializeField]
    private ShipSounds m_SoundsSystem;

    

    public void Initialization()
    {
        m_WeaponSystem.Shoot.AddListener(PlaySound);
    }

    private void PlaySound(AudioClip sound)
    {
        m_SoundsSystem.Play(sound);
    }

    private void OnDisable()
    {
        m_WeaponSystem.Shoot.RemoveListener(PlaySound);
    }

    public ShipSystemHealth ShipSystemsHealth()
    {

        throw new System.NotImplementedException();
    }
}

public struct ShipSystemHealth
{
    public float EngineHealth;
    public float WeaponsHealth;
    public float HullHealth;
}
