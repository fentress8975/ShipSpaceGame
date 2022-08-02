using StageCore.Factory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestBuilder : MonoBehaviour
{
    [SerializeField]
    EnemyFactory m_Factory;
    [SerializeField]
    EnemyPresetSO m_Preset;
    [SerializeField]
    int amount = 0;
    [SerializeField]
    Button m_Button;
    [SerializeField]
    TMP_InputField m_InputField;

    private void Awake()
    {
        m_Button = GetComponentInChildren<Button>();
        m_InputField = GetComponentInChildren<TMP_InputField>();
        m_InputField.text = amount.ToString();
        m_Button.onClick.AddListener(BuildEnemy);
        m_InputField.onSubmit.AddListener(ChangeAmount);
    }

    private void ChangeAmount(string sAmount)
    {
        if(int.TryParse(sAmount, out amount))
        {

        }
    }

    private void BuildEnemy()
    {
        Debug.Log("Pressed");
        m_Factory.CreateEnemy(amount, m_Preset);

    }
}
