using UnityEngine;

namespace MultimeterExample.Scripts.Triggers
{
    [RequireComponent(typeof(MeshRenderer))]
    public class GlowProperty : MonoBehaviour
    {        
        [SerializeField] private Material _glowMaterial;

        private bool         _glowState;
        private MeshRenderer _originMeshRenderer;
        private Material     _originMaterial;

        private void Start()
        {
            _originMeshRenderer = gameObject.GetComponent<MeshRenderer>();
            _originMaterial = _originMeshRenderer.material;
        }

        public void On()
        {
            _glowState = true;
            _originMeshRenderer.material = _glowMaterial;
        }

        public void Off()
        {
            _glowState = false;
            _originMeshRenderer.material = _originMaterial;
        }
    }
}