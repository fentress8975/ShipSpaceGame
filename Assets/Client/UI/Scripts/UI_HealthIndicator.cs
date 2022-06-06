using ShipBase.Containers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HealthIndicator : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> m_HealthBlocks = new List<GameObject>(4);
    [SerializeField]
    private float m_fBaseHealth;
    [SerializeField]
    private float m_fHealth;
    private float m_fPercent;
    private HealthState m_HealthState;

    private enum HealthState
    {
        Full,
        ThreeQuarters,
        Half,
        Quarter,
        Dying,
        Empty
    }

    public void Initialization(ShipModuleHealth shipHealth)
    {
        m_fBaseHealth = shipHealth.FullHealth;
        m_fHealth = shipHealth.WeaponHealth + shipHealth.AIHealth + shipHealth.HullHealth + shipHealth.StorageHealth + shipHealth.EngineHealth;
    }

    public void UpdateInformation(ShipModuleHealth shipHealth)
    {
        m_fBaseHealth = shipHealth.FullHealth;
        m_fHealth = shipHealth.WeaponHealth + shipHealth.AIHealth + shipHealth.HullHealth + shipHealth.StorageHealth + shipHealth.EngineHealth;
    }


    private void UpdateHealth(ShipModuleHealth shipHealth)
    {
        m_fBaseHealth = shipHealth.FullHealth;
        m_fHealth = shipHealth.WeaponHealth + shipHealth.AIHealth + shipHealth.HullHealth + shipHealth.StorageHealth + shipHealth.EngineHealth;
        StateCalculation();
    }

    private void StateCalculation()
    {
        HealthState oldState = m_HealthState;
        if (m_fHealth <= 0)
        {
            m_HealthState = HealthState.Empty;
            m_fPercent = 0;
        }
        if (m_fBaseHealth == 0)
        {
            Debug.LogError("Базовое здоровье не может быть равно 0");
            return;
        }
        m_fPercent = m_fHealth / m_fBaseHealth;
        if (m_fPercent >= 0.8f)
        {
            m_HealthState = HealthState.Full;
        }
        if (0.8f > m_fPercent && m_fPercent >= 0.6f)
        {
            m_HealthState = HealthState.ThreeQuarters;
        }
        if (0.6f > m_fPercent && m_fPercent >= 0.4f)
        {
            m_HealthState = HealthState.Half;
        }
        if (0.4f > m_fPercent && m_fPercent >= 0.2f)
        {
            m_HealthState = HealthState.Quarter;
        }
        if (0.2f > m_fPercent && m_fPercent >= 0)
        {
            m_HealthState = HealthState.Dying;
        }

        if (oldState != m_HealthState)
        {
            UpdateIndicator();
        }
    }

    private void UpdateIndicator()
    {
        switch (m_HealthState)
        {
            case HealthState.Full:
                ActivateAllBlock();
                break;
            case HealthState.ThreeQuarters:
                FromZeroToActivateBlocks(3);
                break;
            case HealthState.Half:
                FromZeroToActivateBlocks(2);
                break;
            case HealthState.Quarter:
                FromZeroToActivateBlocks(1);
                break;
            case HealthState.Dying:
                DeactivateAllBlock();
                StartCoroutine(SimpleBlinkigEffect());
                break;
            case HealthState.Empty:
                RevertDyingState();
                DeactivateAllBlock();
                break;
        }
    }

    private void RevertDyingState()
    {
        StopAllCoroutines();
        Image color = m_HealthBlocks[0].GetComponent<Image>();
        color.color = Color.white;
        m_HealthBlocks[0].SetActive(false);
    }

    private void FromZeroToActivateBlocks(int end)
    {
        if (end > m_HealthBlocks.Count)
        {
            return;
        }
        RevertDyingState();
        DeactivateAllBlock();
        for (int i = 0; i < end; i++)
        {
            m_HealthBlocks[i].SetActive(true);
        }
    }

    private void DeactivateAllBlock()
    {
        foreach (GameObject go in m_HealthBlocks)
        {
            go.SetActive(false);
        }
    }

    private void ActivateAllBlock()
    {
        foreach (GameObject go in m_HealthBlocks)
        {
            go.SetActive(true);
        }
    }

    private IEnumerator SimpleBlinkigEffect()
    {
        Debug.Log("Check");
        Image color = m_HealthBlocks[0].GetComponent<Image>();
        color.color = Color.red;
        while (true)
        {
            m_HealthBlocks[0].SetActive(m_HealthBlocks[0].activeSelf ? false : true);
            yield return new WaitForSeconds(Mathf.InverseLerp(0, 0.2f, m_fPercent));
        }
    }
    private void Update()
    {
        StateCalculation();
    }
}