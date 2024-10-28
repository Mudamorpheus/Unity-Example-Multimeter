using UnityEngine;
using UnityEngine.Events;

namespace MultimeterExample.Scripts.Triggers
{
    [RequireComponent(typeof(MeshCollider))]
    public class HoverTrigger : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onMouseOverEvent;
        [SerializeField] private UnityEvent _onMouseExitEvent;

        private void OnMouseOver()
        {
            _onMouseOverEvent?.Invoke();
        }

        private void OnMouseExit()
        {
            _onMouseExitEvent?.Invoke();
        }
    }
}