using Controller;
using Model;
using UnityEngine;
using View;

namespace CompositionRoot
{
    public class SceneBuilder : MonoBehaviour
    {
        [SerializeField] private MultimeterViewData _multimeterViewData;
        [SerializeField] private MultimeterController _multimeterController;
        [SerializeField] private float _powerValue = 400f;
        [SerializeField] private float _resistanceValue = 1000f;

        private void Start()
        {
            var multimeterView = new MultimeterView(_multimeterViewData);
            var multimeterModel = new MultimeterModel(_powerValue, _resistanceValue, multimeterView);
            _multimeterController.Initialize(multimeterModel, multimeterView);
        }
    }
}