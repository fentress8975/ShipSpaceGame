using UnityEngine;

[CreateAssetMenu(fileName = "AI", menuName = "ShipModules/AI", order = 0)]
public class ShipAISO : ScriptableObject
{
    public string m_sName;
    public float m_fHealth;
    public int m_iWeaponsBonus;
    public int m_iEnginesBonus;
}
