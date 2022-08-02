using GameSystems.Scene;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SceneDropDown : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown m_DropDown;
    private ISceneChanger m_SceneChanger;
    [SerializeField]
    private Button m_Button;

    // Start is called before the first frame update
    private void Start()
    {
        m_SceneChanger = (ISceneChanger)SceneChanger.Instance;

        m_Button = GetComponentInChildren<Button>();
        m_Button.onClick.AddListener(OnPointerClick);

        m_DropDown = GetComponentInChildren<TMP_Dropdown>();
        m_DropDown.ClearOptions();
        m_DropDown.AddOptions(PrepareListOfScenes());
    }

    private List<String> PrepareListOfScenes()
    {
        return m_SceneChanger.GetSceneList();
    }

    private void OnPointerClick()
    {
        Debug.Log("Button");

        if (m_DropDown.IsExpanded){
            m_DropDown.Hide();
        }
        m_SceneChanger.ChangeScene(m_DropDown.captionText.text);

    }
}
