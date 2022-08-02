using UnityEngine;
using ShipBase.Containers;
using AI.Enemy;

namespace StageCore
{
    namespace Factory
    {
        public class EnemyFactory : MonoBehaviour
        {
            private EnemyBuilder m_Builder;
            private Vector3 m_DemploymentPosition;

            private void Awake()
            {
                m_Builder = new EnemyBuilder();
                m_Builder.Initialization();
                m_DemploymentPosition = new Vector3(transform.position.x + 5, 0, transform.position.z + 5);
            }

            public void Initialization(Vector3 deploymentPosition)
            {
                m_DemploymentPosition = deploymentPosition;
            }

            public void CreateEnemy(int amount, ShipModules modules)
            {

            }

            public void CreateEnemy(int amount, EnemyPresetSO enemySO)
            {
                for (int i = 0; i < amount; i++)    
                {
                    GameObject model = (GameObject)Instantiate(Resources.Load("Ship/Models/Ship"));
                    MeshCollider collider = model.GetComponentInChildren<MeshCollider>();
                    collider.convex = true;
                    model.name = enemySO.Name;

                    EnemyController enemyController = m_Builder.BuildEnemyShip(enemySO,model);
                    enemyController.transform.position = m_DemploymentPosition;
                }
                
            }
        }
    }
}
