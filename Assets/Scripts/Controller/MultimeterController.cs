using System;
using Helpers;
using Model;
using UnityEngine;

namespace Controller
{
    public class MultimeterController : MonoBehaviour
    {
        private IMultimeterModel _multimeterModel;
        private States[] _states;
        private int _currentStateIndex;
        private bool _isAvailable;

        public void Initialize(IMultimeterModel multimeterModel)
        {
            _states = (States[])Enum.GetValues(typeof(States));
            _multimeterModel = multimeterModel;
            _currentStateIndex = 0;
            SetState(_currentStateIndex);
        }

        private void FixedUpdate()
        {
            float scrollValue = Input.GetAxis("Mouse ScrollWheel");
            ProcessInput(scrollValue);
        }

        private void ProcessInput(float scrollValue)
        {
            var stateChangeDelta = Normalizer.Normalize(scrollValue);
            _currentStateIndex = GetIndex(stateChangeDelta);
            SetState(_currentStateIndex);
        }

        private int GetIndex(int stateChangeDelta)
        {
            return _currentStateIndex + stateChangeDelta >= _states.Length
                ? 0
                : _currentStateIndex + stateChangeDelta;
        }

        private void SetState(int stateIndex)
        {
            _multimeterModel.SwitchState(_states[stateIndex]);
        }
    }
}