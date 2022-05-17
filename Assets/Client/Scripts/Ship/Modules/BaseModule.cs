using UnityEngine.Events;

public abstract class BaseModule : IShipResource, IDamageable
{
    public UnityEvent<ModuleType, float> Event_HealthUpdate;


    protected float m_fHealth;
    protected float m_fWeight;

    public abstract void Initialization(object module); //Опасный момент

    public float GetModuleWeight()
    {
        return m_fWeight;
    }
    public float GetModuleHealth()
    {
        return m_fHealth;
    }

    public void TakeDamage(float damage)
    {
        m_fHealth -= damage;
    }

    public void TakeDamage(float damage, string damageType)
    {
        m_fHealth -= damage;
    }

    public abstract float GetBaseHealth();
}