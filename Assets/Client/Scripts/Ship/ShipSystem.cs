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


    public void Initialization(PlayerShip playerShip)
    {
        playerShip.Event_ShipMoving.AddListener(MovementCommands);
        m_WeaponSystem.Shoot.AddListener(PlaySound);
        m_MovementHandler = GetComponent<MovementHandler>();
        m_MovementHandler.Initialization();
    }

    private void PlaySound(AudioClip sound)
    {
        m_SoundsSystem.Play(sound);
    }

    private void MovementCommands(Vector2 axis)
    {
        m_MovementHandler.Movement(axis);
    }

    private void OnDisable()
    {
        m_WeaponSystem.Shoot.RemoveListener(PlaySound);
    }
}
