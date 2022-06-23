using ShipBase;
using System.Collections.Generic;
using UnityEngine;


namespace AI
{
    public class TargetScaner : MonoBehaviour
    {
        private Ship m_Target;
        [SerializeField]
        private List<Ship> m_ListTargets;
        [SerializeField]
        private GameObject m_Sphere;
        private SphereDetection m_SphereDetection;


        public void Initialization()
        {
            m_ListTargets = new List<Ship>();
            m_Sphere = Instantiate(m_Sphere);
            m_SphereDetection = m_Sphere.GetComponent<SphereDetection>();
            m_SphereDetection.Initialization();
        }

        private void Start()
        {
            m_ListTargets = new List<Ship>();
            m_Sphere = Instantiate(m_Sphere, gameObject.transform);
            m_SphereDetection = m_Sphere.GetComponent<SphereDetection>();
            m_SphereDetection.Initialization();
            m_SphereDetection.Event_ColliderEnter.AddListener(AddTarget);
            m_SphereDetection.Event_ColliderExit.AddListener(RemoveTarget);
        }

        private void Update()
        {
            // CheckTargetStatus();
        }

        private void CheckTargetStatus()
        {
            if (isTargetAlive(m_Target))
            {

            }
            else
            {
                ChooseNewTarget();
            }
        }

        private bool isTargetAlive(Ship ship)
        {
            return m_Target.GetCurrentShipHealth().HullHealth >= 0 ? true : false;
        }

        private void ChooseNewTarget()
        {
            foreach (var ship in m_ListTargets)
            {
                if (isTargetAlive(ship))
                {
                    m_Target = ship;
                    return;
                }
            }
        }

        private void AddTarget(Collider collider)
        {
            if (collider.gameObject.TryGetComponent<Ship>(out Ship target))
            {
                m_ListTargets.Add(target);
            }
        }

        private void RemoveTarget(Collider collider)
        {
            if (collider.gameObject.TryGetComponent<Ship>(out Ship target))
            {
                m_ListTargets.Remove(target);
            }
        }

        private void OnDestroy()
        {
            m_SphereDetection.Event_ColliderEnter.RemoveListener(AddTarget);
            m_SphereDetection.Event_ColliderExit.RemoveListener(RemoveTarget);
        }
    }
}
