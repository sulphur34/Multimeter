using System;
using Helpers;
using TMPro;
using UnityEngine;

namespace View
{
    [Serializable]
    public class StateViewData
    {
        [field: SerializeField] public States State { get; private set; }
        [field: SerializeField] public TextMeshProUGUI ReadingsLabelUI { get; private set; }
        [field: SerializeField] public Transform HandleRotationPoint { get; private set; }
    }
}