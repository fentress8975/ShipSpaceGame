using ShipBase;
using System.Collections.Generic;
using UnityEngine;


namespace AI
{
    public class TargetScaner : MonoBehaviour
    {
        public delegate void ScanerHandler(Ship target);
        public event ScanerHandler Event_TargetChanged;

        private Ship m_Target;
        [SerializeField]
        private List<Ship> m_ListTargets;
        [SerializeField]
        private GameObject m_Sphere;
        private SphereDetection m_SphereDetection;

        private Faction m_Faction;


        public void Initialization(Ship ship, Faction.Side side)
        {
            m_ListTargets = new List<Ship>();
            m_Sphere = Instantiate(m_Sphere, ship.transform);
            m_SphereDetection = m_Sphere.GetComponent<SphereDetection>();
            m_SphereDetection.Initialization();
            m_SphereDetection.Event_ColliderEnter.AddListener(AddTarget);
            m_SphereDetection.Event_ColliderExit.AddListener(RemoveTarget);

            m_Faction = new Faction(side);
        }

        //private void Start()
        //{
        //    m_ListTargets = new List<Ship>();
        //    m_Sphere = Instantiate(m_Sphere, gameObject.transform);
        //    m_SphereDetection = m_Sphere.GetComponent<SphereDetection>();
        //    m_SphereDetection.Initialization();
        //    m_SphereDetection.Event_ColliderEnter.AddListener(AddTarget);
        //    m_SphereDetection.Event_ColliderExit.AddListener(RemoveTarget);
        //}

        private void Update()
        {

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
            return ship.GetCurrentShipHealth().HullHealth >= 0 ? true : false;
        }

        private void ChooseNewTarget()
        {
            if (m_ListTargets.Count == 0)
            {
                m_Target = null;
                Event_TargetChanged?.Invoke(m_Target);
            }
            else
            {
                foreach (var ship in m_ListTargets)
                {
                    if (isTargetAlive(ship))
                    {
                        m_Target = ship;
                        Event_TargetChanged?.Invoke(ship);
                        return;
                    }
                }
            }
        }

        private void AddTarget(Collider collider)
        {
            if (collider.gameObject.TryGetComponent<Ship>(out Ship target))
            {
                if (target.m_Faction.m_Side != m_Faction.m_Side && !m_ListTargets.Contains(target))  //почему коллайдер 2 раза прокается?
                {
                    m_ListTargets.Add(target);
                    ChooseNewTarget();
                }
            }
        }

        private void RemoveTarget(Collider collider)
        {
            if (collider.gameObject.TryGetComponent<Ship>(out Ship target))
            {
                if (target.m_Faction != m_Faction)
                {
                    m_ListTargets.Remove(target);
                    ChooseNewTarget();
                }
            }
        }

        private void OnDestroy()
        {
            m_SphereDetection.Event_ColliderEnter.RemoveListener(AddTarget);
            m_SphereDetection.Event_ColliderExit.RemoveListener(RemoveTarget);
        }
    }
}
