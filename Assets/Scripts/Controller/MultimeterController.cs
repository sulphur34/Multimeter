using System;
using System.Collections;
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
        private int _currentStateIndex;
        private bool _isAvailable;
        private Camera _mainCamera;
        private IMultimeterView _multimeterView;
        private Coroutine _coroutine;

        public void Initialize(IMultimeterModel multimeterModel, IMultimeterView multimeterView)
        {
            _states = (States[])Enum.GetValues(typeof(States));
            _multimeterModel = multimeterModel;
            _multimeterView = multimeterView;
            _currentStateIndex = 0;
            SetState(_currentStateIndex);
            _mainCamera = Camera.main;
            _coroutine = StartCoroutine(InputRoutine());
        }

        private void OnDestroy()
        {
            if(_coroutine != null)
                StopCoroutine(_coroutine);
        }

        private IEnumerator InputRoutine()
        {
            while (enabled)
            {
                Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

                bool isHit = Physics.Raycast(ray, out RaycastHit hit);
                _multimeterView.SetHandleActiveState(isHit);

                if (!isHit)
                    continue;

                if (hit.collider.gameObject.GetComponent<Handle>())
                {
                    float scrollValue = Input.GetAxis("Mouse ScrollWheel");
                    ProcessInput(scrollValue);
                }

                yield return null;
            }
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