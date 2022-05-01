using UnityEngine;

[RequireComponent(typeof(WeaponsSystem))]
[RequireComponent(typeof(EngineSystem))]
[RequireComponent(typeof(ShipSounds))]
[RequireComponent(typeof(MovementHandler))]

public class ShipSystem : MonoBehaviour
{
    [SerializeField]
    private WeaponsSystem m_WeaponSystem;
    [SerializeField]
    private EngineSystem m_EngineSystem;
    [SerializeField]
    private ShipSounds m_SoundsSystem;
    [SerializeField]
    private MovementHandler m_MovementHandler;


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
}
