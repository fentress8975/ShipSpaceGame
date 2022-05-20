using UnityEngine;
using UnityEngine.Events;


public abstract class BaseModule<T> : IShipResource, IDamageable
{
    public UnityEvent<float> Event_HealthUpdate;
    public T ModuleSO { get; protected set; }

    protected float m_fHealth;
    protected float m_fWeight;


    public BaseModule(T module)
    {
        Initialization(module);
    }

    public void Initialization(T module)
    {
        ModuleSO = module;
        Debug.Log($"Я {this} включаюсь. Мне передали модулить типа {ModuleSO.GetType()}. \n Произвожу загрузку значений.");
        Setting();
        Debug.Log($"{this} Готов.");
    }

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

    protected abstract void Setting();
}
