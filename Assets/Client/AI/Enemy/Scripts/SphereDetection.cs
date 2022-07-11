using UnityEngine;
using UnityEngine.Events;

namespace AI
{
    public class SphereDetection : MonoBehaviour
    {
        public UnityEvent<Collider> Event_ColliderEnter;
        public UnityEvent<Collider> Event_ColliderExit
            ;
        [SerializeField]

        public void Initialization()
        {
            transform.localPosition = Vector3.zero;

        }




        private void OnTriggerEnter(Collider other)
        {
            Event_ColliderEnter?.Invoke(other);
        }

        private void OnTriggerExit(Collider other)
        {
            Event_ColliderExit?.Invoke(other);
        }

    }
}