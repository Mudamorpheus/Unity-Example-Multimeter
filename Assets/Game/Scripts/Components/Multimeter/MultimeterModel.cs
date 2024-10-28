using UnityEngine;

using Zenject;

using MultimeterExample.Scripts.Patterns;

namespace MultimeterExample.Scripts.Components
{
    public enum MultimeterMode
    {
        Neutral,
        Resistance,
        Amperage,
        VoltageDC,
        VoltageAC
    }

    public class MultimeterModel : MonoBehaviour, IModel
    {
        [Inject] private MultimeterView _multimeterView;
        //===
        [SerializeField] private float _multimeterResistance = 1000f;
        [SerializeField] private float _multimeterPower      = 400f;
        //===
        private MultimeterMode _multimeterMode;
        private float          _multimeterAmperage;
        private float          _multimeterVoltageDC;
        private float          _multimeterVoltageAC;

        public void SetMode(MultimeterMode mode)
        {
            _multimeterMode = mode;

            Display();
        }

        public void Calculate()
        {
            _multimeterAmperage = Mathf.Sqrt(_multimeterPower / _multimeterResistance);
            _multimeterVoltageDC = _multimeterAmperage * _multimeterResistance;
            _multimeterVoltageAC = 0.01f;

            Display();
        }

        public void Display()
        {
            //Multimeter screen
            switch (_multimeterMode)
            {                
                case MultimeterMode.Neutral:
                {
                    _multimeterView.DisplayScreen(0);
                    break;
                }
                case MultimeterMode.Resistance:
                {
                    _multimeterView.DisplayScreen(_multimeterResistance);
                    break;
                }
                case MultimeterMode.Amperage:
                {
                    _multimeterView.DisplayScreen(_multimeterAmperage);
                    break;
                }
                case MultimeterMode.VoltageDC:
                {
                    _multimeterView.DisplayScreen(_multimeterVoltageDC);
                    break;
                }
                case MultimeterMode.VoltageAC:
                {
                    _multimeterView.DisplayScreen(_multimeterVoltageAC);
                    break;
                }
            }
            
            //Overlay UI
            _multimeterView.DisplayOverlay(_multimeterResistance, _multimeterAmperage, _multimeterVoltageDC, _multimeterVoltageAC);
        }
    }
}