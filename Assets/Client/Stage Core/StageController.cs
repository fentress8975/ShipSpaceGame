using AI.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StageCore
{
    public class StageController : SingletonMonoPersistent<MonoBehaviour>
    {
        private EnemyBuilder m_EnemyBuilder;
        private StageBuilder m_StageBuilder;

        [SerializeField]
        private float m_fEnemysDeaths = 0f;
        [SerializeField]
        private float m_fCurrentDifficulty = 0f;
        [SerializeField]
        private List<EnemyController> m_EnemyList;


        public void Initialization(float enemysDeahts = 0f, float difficulty = 0f)
        {
            m_EnemyBuilder = new EnemyBuilder();
            m_EnemyBuilder.Initialization();
            m_StageBuilder = new StageBuilder();
            m_StageBuilder.Initialization();

            m_fEnemysDeaths = enemysDeahts;
            m_fCurrentDifficulty = difficulty;
        }

        public void CreateStage()
        {

        }

        public void UpdateStage()
        {

        }

        public void ChangeDifficulty()
        {

        }
    }
}