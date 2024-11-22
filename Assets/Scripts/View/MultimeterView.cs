using Helpers;

namespace View
{
    public class MultimeterView : IMultimeterView
    {
        private ReadingsScreenVisualizer _readingsScreenVisualizer;
        private HandleHighlighter _handleHighlighter;
        private ReadingsUIVisualizer _readingsUIVisualizer;
        private HandleRotator _handleRotator;

        public MultimeterView(MultimeterViewData viewData)
        {
            _readingsScreenVisualizer = new ReadingsScreenVisualizer(viewData.ScreenLabel);
            _readingsUIVisualizer = new ReadingsUIVisualizer();
            _handleRotator = new HandleRotator(viewData.Handle);
            _handleHighlighter = viewData.HandleHighlighter;

            foreach (var stateView in viewData.StatesViewData)
            {
                if (stateView.State != States.Off)
                    _readingsUIVisualizer.AddReadingData(new UIReadingData(stateView.State, stateView.ReadingsLabelUI));

                _handleRotator.AddRotation(stateView.State, stateView.HandleRotationPoint.position);
            }
        }

        public void Redraw(States state, float value)
        {
            string readingView = state == States.Off ? string.Empty : value.ToTwoDecimalString();
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