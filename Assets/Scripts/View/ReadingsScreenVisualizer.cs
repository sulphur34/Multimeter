using Helpers;
using TMPro;

namespace View
{
    public class ReadingsScreenVisualizer
    {
        private TextMeshProUGUI _readingsLabel;

        public ReadingsScreenVisualizer(TextMeshProUGUI readingsLabel)
        {
            _readingsLabel = readingsLabel;
        }

        public void VisualizeReadings(string value)
        {
            _readingsLabel.text = value;
        }
    }
}