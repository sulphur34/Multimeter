using Helpers;
using TMPro;

namespace View
{
    public class UIReadingData
    {
        private readonly TextMeshProUGUI _text;

        public UIReadingData(States state, TextMeshProUGUI text)
        {
            State = state;
            _text = text;
        }

        public States State { get; private set; }

        public void SetText(string text)
        {
            _text.text = text;
        }
    }
}