using System.Collections.Generic;
using Helpers;

namespace View
{
    public class ReadingsUIVisualizer
    {
        private readonly string _zeroValueString = "0.00";

        private List<UIReadingData> _readingDatas = new List<UIReadingData>();

        public void AddReadingData(UIReadingData readingData)
        {
            _readingDatas.Add(readingData);
        }

        public void VisualizeReadings(States state, string value)
        {
            if (state == States.Off)
            {
                _readingDatas.ForEach(data => data.SetText(string.Empty));
                return;
            }

            _readingDatas.ForEach(data => data.SetText(data.State == state ? value : _zeroValueString));
        }
    }
}