using System;
using Helpers;
using Model;
using UnityEngine;
using View;

namespace Controller
{
    public class MultimeterController : MonoBehaviour
    {
        private int _arrayLength;
        private int _currentStateIndex;
        private Handle _handle;
        private bool _isAvailable;
        private Camera _mainCamera;
        private IMultimeterModel _multimeterModel;
        private IMultimeterView _multimeterView;
        private States[] _states;

        private Ray MouseRay
        {
            get => _mainCamera.ScreenPointToRay(Input.mousePosition);
        }

        private void Update()
        {
            var isHit = Physics.Raycast(MouseRay, out var hit);
            _multimeterView.SetHandleActiveState(isHit);

            if (!isHit)
            {
                return;
            }

            if (!hit.collider.gameObject == _handle.gameObject)
            {
                return;
            }

            var scrollValue = Input.GetAxis("Mouse ScrollWheel");
            ProcessInput(scrollValue);
        }

        public void Initialize(IMultimeterModel multimeterModel, IMultimeterView multimeterView, Handle handle)
        {
            _states = (States[])Enum.GetValues(typeof(States));
            _arrayLength = _states.Length;
            _multimeterModel = multimeterModel;
            _multimeterView = multimeterView;
            _handle = handle;
            _currentStateIndex = 0;
            SetState(_currentStateIndex);
            _mainCamera = Camera.main;
        }


        private void ProcessInput(float scrollValue)
        {
            if (scrollValue == 0)
            {
                return;
            }

            var stateChangeDelta = Normalizer.Normalize(scrollValue);
            _currentStateIndex = GetIndex(stateChangeDelta);
            SetState(_currentStateIndex);
        }

        private int GetIndex(int stateChangeDelta)
        {
            return (_currentStateIndex + stateChangeDelta + _arrayLength) % _arrayLength;
        }

        private void SetState(int stateIndex)
        {
            _multimeterModel.SwitchState(_states[stateIndex]);
        }
    }
}
