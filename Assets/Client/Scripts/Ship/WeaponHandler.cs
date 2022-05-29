using ShipBase;
using ShipSystem;
using System;
using UnityEngine;


public class WeaponHandler : MonoBehaviour
{
    private WeaponsSystem m_WeaponSystem;
    private bool m_bIsFiring = false;


    public void Initialization(Ship ship)
    {
        InputsControl.instance.Event_WeaponUse.AddListener(FireWeapon);
        m_WeaponSystem = ship.GetComponent<WeaponsSystem>();
    }

    private void FireWeapon(bool isFiring)
    {
        //m_bIsFiring = isFiring;
        if (isFiring)
        {
            m_WeaponSystem.EnableWeapon();
        }
        else
        {
            m_WeaponSystem.DisableWeapon();
        }
    }

    private void OnDestroy()
    {
        InputsControl.instance.Event_WeaponUse.RemoveListener(FireWeapon);
    }
}
