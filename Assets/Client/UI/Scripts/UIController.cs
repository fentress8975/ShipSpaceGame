using ShipBase.Containers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private UI_EngineIndicator m_EngineIndicator;
    private UI_HealthIndicator m_HealthIndicator;
    private UI_WeaponIndicator m_WeaponIndicator;

    public void Ininitialization(ShipModuleHealth shipHealth, bool stabilization, string weaponName)
    {
        m_EngineIndicator = GetComponentInChildren<UI_EngineIndicator>();
        m_HealthIndicator = GetComponentInChildren<UI_HealthIndicator>();
        m_WeaponIndicator = GetComponentInChildren<UI_WeaponIndicator>();

        m_HealthIndicator.Initialization(shipHealth);   
        m_WeaponIndicator.Initialization(weaponName);
        m_EngineIndicator.Initialization(stabilization);

    }
}
