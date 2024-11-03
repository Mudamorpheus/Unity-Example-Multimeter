using UnityEngine;

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
        [SerializeField] private MultimeterView _multimeterView;
        //===
        [SerializeField] private float _multimeterResistance = 1000f;
        [SerializeField] private float _multimeterPower      = 400f;
        //===
        private MultimeterMode _multimeterMode;
        private float          _multimeterAmperage;
        private float          _multimeterVoltageDC;
        private float          _multimeterVoltageAC;
        //===
        public MultimeterMode Mode       { get { return _multimeterMode; } }
        public float          Resistance { get { return _multimeterResistance; } }
        public float          Power      { get { return _multimeterPower; } }
        public float          Amperage   { get { return _multimeterAmperage; } }
        public float          VoltageDC  { get { return _multimeterVoltageDC; } }
        public float          VoltageAC  { get { return _multimeterVoltageAC; } }

        public void SetMode(MultimeterMode mode)
        {
            _multimeterMode = mode;
        }

        public void Calculate()
        {
            _multimeterAmperage = Mathf.Sqrt(_multimeterPower / _multimeterResistance);
            _multimeterVoltageDC = _multimeterAmperage * _multimeterResistance;
            _multimeterVoltageAC = 0.01f;
        }
    }
}