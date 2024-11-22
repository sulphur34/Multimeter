using System;
using TMPro;
using UnityEngine;

namespace View
{
    [Serializable]
    public class MultimeterViewData
    {
        [field: SerializeField] public StateViewData[] StatesViewData { get; private set; }
        [field: SerializeField] public Transform Handle { get; private set; }
        [field: SerializeField] public HandleHighlighter HandleHighlighter { get; private set; }
        [field: SerializeField] public TextMeshProUGUI ScreenLabel { get; private set; }
    }
}