using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public abstract class BaseModule<T> : IShipResource, IDamageable
{
    public UnityEvent<float> Event_HealthUpdate;
    public T m_ModuleSO { get; protected set; }

    protected string m_sName;
    protected float m_fHealth;
    protected float m_fWeight;


    public BaseModule(T module)
    {
        Initialization(module);
    }

    public void Initialization(T module)
    {
        m_ModuleSO = module;
        Debug.Log($"Я {this} включаюсь. Мне передали модулить типа {m_ModuleSO.GetType()}. \n Произвожу загрузку значений.");
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

    public string GetModuleName()
    {
        return m_sName;
    }

    public void TakeDamage(float damage)
    {
        m_fHealth -= damage;
    }

    public void TakeDamage(float damage, string damageType)
    {
        m_fHealth -= damage;
    }

    protected Dictionary<string,float> GetBaseInformation()
    {
        Dictionary<string,float> baseInformation = new Dictionary<string,float>();
        baseInformation.Add("Health", m_fHealth);
        baseInformation.Add("Weight", m_fWeight);
        return baseInformation;
    }

    public abstract float GetBaseHealth();

    protected abstract void Setting();
}
