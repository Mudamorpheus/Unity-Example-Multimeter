using UnityEngine;

using TMPro;

using MultimeterExample.Scripts.Patterns;

namespace MultimeterExample.Scripts.Components
{
    public class MultimeterView : MonoBehaviour, IView
    {
        [SerializeField] private MultimeterModel _multimeterModel;
        //
        [SerializeField] private TMP_Text _uiScreenText;
        [SerializeField] private TMP_Text _uiResistanceValueText;
        [SerializeField] private TMP_Text _uiAmperageValueText;
        [SerializeField] private TMP_Text _uiVoltageDCValueText;
        [SerializeField] private TMP_Text _uiVoltageACValueText;

        public void Display()
        {
            //Multimeter screen
            switch (_multimeterModel.Mode)
            {
                case MultimeterMode.Neutral:
                    {
                        DisplayScreen(0);
                        break;
                    }
                case MultimeterMode.Resistance:
                    {
                        DisplayScreen(_multimeterModel.Resistance);
                        break;
                    }
                case MultimeterMode.Amperage:
                    {
                        DisplayScreen(_multimeterModel.Amperage);
                        break;
                    }
                case MultimeterMode.VoltageDC:
                    {
                        DisplayScreen(_multimeterModel.VoltageDC);
                        break;
                    }
                case MultimeterMode.VoltageAC:
                    {
                        DisplayScreen(_multimeterModel.VoltageAC);
                        break;
                    }
            }

            //Overlay UI
            DisplayOverlay(_multimeterModel.Resistance, _multimeterModel.Amperage, _multimeterModel.VoltageDC, _multimeterModel.VoltageAC);
        }

        public void DisplayScreen(float value)
        {
            _uiScreenText.text = value.ToString("0.##");
        }

        public void DisplayOverlay(float resistance, float amperage, float voltageDC, float voltageAC)
        {
            _uiResistanceValueText.text = resistance.ToString("0.##");
            _uiAmperageValueText.text   = amperage.ToString("0.##");
            _uiVoltageDCValueText.text  = voltageDC.ToString("0.##");
            _uiVoltageACValueText.text  = voltageAC.ToString("0.##");
        }
    }
}