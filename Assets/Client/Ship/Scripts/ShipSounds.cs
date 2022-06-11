using Hellmade.Sound;
using UnityEngine;

public class ShipSounds : MonoBehaviour
{

    public void Play(AudioClip sound)
    {
        int playSound = EazySoundManager.PlaySound(sound, 0.2f);
    }

}
