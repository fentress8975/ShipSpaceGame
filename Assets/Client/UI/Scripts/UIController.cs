using ShipBase.Containers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIController : MonoBehaviour
{
    private UI_EngineIndicator m_EngineIndicator;
    private UI_HealthIndicator m_HealthIndicator;
    private UI_WeaponIndicator m_WeaponIndicator;

    public void Ininitialization(BaseModulesHealth baseShipHealth, CurrentModulesHealth currentShipHealth, bool stabilization, string weaponName)
    {
        m_EngineIndicator = GetComponentInChildren<UI_EngineIndicator>();
        m_HealthIndicator = GetComponentInChildren<UI_HealthIndicator>();
        m_WeaponIndicator = GetComponentInChildren<UI_WeaponIndicator>();

        m_EngineIndicator.Initialization(stabilization);
        m_HealthIndicator.Initialization(baseShipHealth,currentShipHealth);   
        m_WeaponIndicator.Initialization(weaponName);
    }


    public void EngineUpdate(bool stabilazed)
    {
        m_EngineIndicator.UpdateInformation(stabilazed);
    }

    public void CurrentHealthUpdate(CurrentModulesHealth currentShipHealth)
    {
        m_HealthIndicator.UpdateCurrentHealth(currentShipHealth);
    }

    public void BaseHealthUpdate(BaseModulesHealth baseShipHealth)
    {
        m_HealthIndicator.UpdateBaseHealth(baseShipHealth);
    }

    public void WeaponUpdate(string weaponName)
    {
        m_WeaponIndicator.UpdateInformation(weaponName);
    }
}
