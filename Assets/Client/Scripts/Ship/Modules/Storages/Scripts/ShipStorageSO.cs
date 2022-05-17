using UnityEngine;
[CreateAssetMenu(fileName = "Storage", menuName = "ShipModules/Storage", order = 0)]

public class ShipStorageSO : ScriptableObject
{
    public string m_sName;
    public float m_fHealth;
    public float m_fWeight;
    public int m_iCapacity;
}
