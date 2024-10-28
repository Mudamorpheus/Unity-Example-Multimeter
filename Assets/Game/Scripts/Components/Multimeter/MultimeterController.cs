using UnityEngine;

using Zenject;

using MultimeterExample.Scripts.Patterns;
using UnityEditor.Experimental.GraphView;

namespace MultimeterExample.Scripts.Components
{
    public class MultimeterController : MonoBehaviour, IController
    {
        [Inject] private MultimeterModel _multimeterModel;
        //
        [SerializeField] private GameObject _multimeterWheel;
        [SerializeField] private float      _multimeterStartingAngle = 90f;
        [SerializeField] private float      _multimeterRotationSpeed = 1000f;
        //
        private bool  _multimeterAccessable;
        private float _multimeterRotation;

        public void Awake()
        {
            //Vars
            _multimeterRotation = _multimeterStartingAngle;

            //Model
            _multimeterModel.Calculate();
        }

        public void Update()
        {
            UpdateInput();
        }

        public void UpdateInput()
        {
            if (_multimeterAccessable)
            {
                //Mouse
                float scroll = Input.GetAxis("Mouse ScrollWheel");

                //Value
                if (scroll > 0f) //Forward
                {
                    _multimeterRotation += Time.deltaTime * _multimeterRotationSpeed;
                    _multimeterWheel.transform.Rotate(0, 0, Time.deltaTime * -_multimeterRotationSpeed);
                }
                else if (scroll < 0f) //Backward
                {
                    _multimeterRotation -= Time.deltaTime * _multimeterRotationSpeed;
                    _multimeterWheel.transform.Rotate(0, 0, Time.deltaTime * _multimeterRotationSpeed);
                }

                //Borders
                if(_multimeterRotation < 0f)
                {
                    _multimeterRotation = 360f + _multimeterRotation;
                }
                else if(_multimeterRotation > 360f)
                {
                    _multimeterRotation = _multimeterRotation - 360f;
                }

                //Wheel
                if (scroll != 0)
                {
                    RotateWheel();
                }
            }
        }

        public void RotateWheel()
        {
            Debug.Log(_multimeterRotation);

            //Modes
            if (_multimeterRotation > 120f && _multimeterRotation < 150f)
            {
                _multimeterModel.SetMode(MultimeterMode.Resistance);
            }
            else if (_multimeterRotation > 210f && _multimeterRotation < 240f)
            {
                _multimeterModel.SetMode(MultimeterMode.Amperage);
            }
            else if (_multimeterRotation > 30f && _multimeterRotation < 60f)
            {
                _multimeterModel.SetMode(MultimeterMode.VoltageDC);
            }
            else if (_multimeterRotation > 300f && _multimeterRotation < 330f)
            {
                _multimeterModel.SetMode(MultimeterMode.VoltageAC);
            }
            else
            {
                _multimeterModel.SetMode(MultimeterMode.Neutral);
            }
        }

        public void On()
        {
            _multimeterAccessable = true;
        }

        public void Off()
        {
            _multimeterAccessable = false;
        }
    }
}