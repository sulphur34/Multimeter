using Helpers;

namespace View
{
    public class MultimeterView : IMultimeterView
    {
        private readonly HandleHighlighter _handleHighlighter;
        private readonly HandleRotator _handleRotator;
        private readonly ReadingsScreenVisualizer _readingsScreenVisualizer;
        private readonly ReadingsUIVisualizer _readingsUIVisualizer;

        public MultimeterView(MultimeterViewData viewData)
        {
            _readingsScreenVisualizer = new ReadingsScreenVisualizer(viewData.ScreenLabel);
            _readingsUIVisualizer = new ReadingsUIVisualizer();
            _handleRotator = new HandleRotator(viewData.Handle);
            _handleHighlighter = viewData.HandleHighlighter;

            foreach (var stateView in viewData.StatesViewData)
            {
                if (stateView.State != States.Off)
                {
                    _readingsUIVisualizer.AddReadingData(new UIReadingData(stateView.State, stateView.ReadingsLabelUI));
                }

                _handleRotator.AddRotation(stateView.State, stateView.HandleRotationPoint.position);
            }
        }

        public void Redraw(States state, float value)
        {
            var readingView = state == States.Off ? string.Empty : value.ToString("F2");
            _readingsScreenVisualizer.VisualizeReadings(readingView);
            _handleRotator.SetRotationFromState(state);
            _readingsUIVisualizer.VisualizeReadings(state, readingView);
        }

        public void SetHandleActiveState(bool isActive)
        {
            _handleHighlighter.SetState(isActive);
        }
    }
}