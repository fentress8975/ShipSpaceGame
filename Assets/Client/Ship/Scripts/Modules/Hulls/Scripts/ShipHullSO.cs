using UnityEngine;
[CreateAssetMenu(fileName = "Hull", menuName = "ShipModules/Hull", order = 0)]

public class ShipHullSO : ScriptableObject
{
    public string m_sName;
    public float m_fHealth;
    public float m_fWeight;
    public float m_fCapacity;
    [Space(10)]
    public int m_iWeaponsMountsPositions;
    public int m_iEnginesMountsPositions;
    public int m_iShieldsMountsPositions;
    public int m_iStoragesMountsPositions;
    public int m_iAIMountsPositions;
}
