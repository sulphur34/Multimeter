using System;
using Helpers;
using Model;
using UnityEngine;
using View;

namespace Controller
{
    public class MultimeterController : MonoBehaviour
    {
        private IMultimeterModel _multimeterModel;
        private States[] _states;
        private int _arrayLength;
        private int _currentStateIndex;
        private bool _isAvailable;
        private Camera _mainCamera;
        private IMultimeterView _multimeterView;

        public void Initialize(IMultimeterModel multimeterModel, IMultimeterView multimeterView)
        {
            _states = (States[])Enum.GetValues(typeof(States));
            _arrayLength = _states.Length;
            _multimeterModel = multimeterModel;
            _multimeterView = multimeterView;
            _currentStateIndex = 0;
            SetState(_currentStateIndex);
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            bool isHit = Physics.Raycast(ray, out RaycastHit hit);
            _multimeterView.SetHandleActiveState(isHit);

            if (!isHit)
                return;

            if (hit.collider.gameObject.GetComponent<Handle>())
            {
                float scrollValue = Input.GetAxis("Mouse ScrollWheel");
                ProcessInput(scrollValue);
            }
        }

        private void ProcessInput(float scrollValue)
        {
            if (scrollValue == 0)
                return;

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