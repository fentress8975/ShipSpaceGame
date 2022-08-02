using ShipModule;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace ShipSystem
{
    public class EngineSystem : MonoBehaviour, IShipSystem, IShipSystemSO<ShipEngineSO>
    {
        public event IShipSystem.ModuleHealthUpdate Event_HealthUpdate;
        public event IShipSystem.ModuleEfficiencyUpdate Event_EfficiencyUpdate;
        public delegate void EnginePowerHandler(float power);
        public delegate void EngineRotationHandler(float rotation);
        public event EnginePowerHandler Event_EnginePowerUpdate;
        public event EngineRotationHandler Event_EngineRotationSpeedUpdate;

        private ShipEngine m_Module;


        public void Initialization(ShipEngineSO engineSO)
        {
            m_Module = new ShipEngine(engineSO);
        }

        public ShipEngineSO GetModuleSO()
        {
            return m_Module.m_ModuleSO;
        }

        public float GetSystemWeight()
        {
            return m_Module.GetModuleWeight();
        }

        public float GetSystemHealth()
        {
            return m_Module.GetModuleHealth();
        }

        public Dictionary<string, float> GetModuleInfo()
        {
            return m_Module.GetModuleInformation();
        }

        public float GetEnginePower()
        {
            return m_Module.m_fPower;
        }

        public float GetEngineRotationSpeed()
        {
            return m_Module.m_fRotationSpeed;
        }

        public IShipModule GetModule()
        {
            return m_Module;
        }

        public void TakeDamage(float damage)
        {
            m_Module.TakeDamage(damage);
        }

        public void TakeDamage(float damage, string damageType)
        {
            throw new System.NotImplementedException();
        }


        private void EnginePowerUpdate()
        {
            Event_EnginePowerUpdate?.Invoke(m_Module.m_fPower);
        }

        private void EngineRotationSpeedUpdate()
        {
            Event_EnginePowerUpdate?.Invoke(m_Module.m_fRotationSpeed);
        }
    }
}

