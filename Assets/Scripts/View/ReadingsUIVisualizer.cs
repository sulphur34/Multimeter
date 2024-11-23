using System.Collections.Generic;
using Helpers;

namespace View
{
    public class ReadingsUIVisualizer
    {
        private const string ZeroValueString = "0.00";

        private readonly List<UIReadingData> _readingsData = new ();

        public void AddReadingData(UIReadingData readingData)
        {
            _readingsData.Add(readingData);
        }

        public void VisualizeReadings(States state, string value)
        {
            if (state == States.Off)
            {
                _readingsData.ForEach(data => data.SetText(string.Empty));
                return;
            }

            _readingsData.ForEach(data => data.SetText(data.State == state ? value : ZeroValueString));
        }
    }
}
