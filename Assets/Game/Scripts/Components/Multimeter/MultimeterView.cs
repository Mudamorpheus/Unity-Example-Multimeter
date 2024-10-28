using UnityEngine;

using TMPro;

using MultimeterExample.Scripts.Patterns;

namespace MultimeterExample.Scripts.Components
{
    public class MultimeterView : MonoBehaviour, IView
    {
        [SerializeField] private TMP_Text _uiScreenText;
        [SerializeField] private TMP_Text _uiResistanceValueText;
        [SerializeField] private TMP_Text _uiAmperageValueText;
        [SerializeField] private TMP_Text _uiVoltageDCValueText;
        [SerializeField] private TMP_Text _uiVoltageACValueText;

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