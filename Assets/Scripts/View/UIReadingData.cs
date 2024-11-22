using Helpers;
using TMPro;

namespace View
{
    public class UIReadingData
    {
        public readonly States State;
        public readonly TextMeshProUGUI Text;

        public UIReadingData(States state, TextMeshProUGUI text)
        {
            State = state;
            Text = text;
        }

        public void SetText(string text)
        {
            Text.text = text;
        }
    }
}