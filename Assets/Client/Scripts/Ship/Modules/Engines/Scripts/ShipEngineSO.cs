using UnityEngine;

[CreateAssetMenu(fileName = "Engine", menuName = "ShipModules/Engine", order = 0)]
public class ShipEngineSO : ScriptableObject
{
    public string m_sName;
    public float m_fHealth;
    public float m_fWeight;
    [Tooltip("Power/weight")]
    public float m_fAccelerationPower;
    [Tooltip("Degrees per second")]
    public float m_fRotationSpeed;
}
