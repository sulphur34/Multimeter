using System;
using System.Collections.Generic;
using System.Linq;
using Helpers;

namespace View
{
    public class ReadingsUIVisualizer
    {
        private readonly string _zeroValueString = "0.00";

        private List<UIReadingData> _readingDatas;

        public ReadingsUIVisualizer(List<UIReadingData> readingDatas)
        {
            _readingDatas = readingDatas;
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