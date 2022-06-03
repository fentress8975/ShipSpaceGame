using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class UI_EngineIndicator : MonoBehaviour
{
    private TextMeshProUGUI m_CurrentStabilization;
    private bool m_bIsStabilized;

    private const string isOn = "Stabilization ON";
    private const string isOff = "Stabilization OFF";


    public void Initialization(bool stabilization)
    {
        m_CurrentStabilization = GetComponent<TextMeshProUGUI>();
        UpdateInformation(stabilization);
    }

    public void UpdateInformation(bool stabilization)
    {
        m_bIsStabilized = stabilization;
        ChangeIndicator();
    }
    private void ChangeIndicator()
    {
        m_CurrentStabilization.SetText(m_bIsStabilized ? isOn : isOff);
    }
}
