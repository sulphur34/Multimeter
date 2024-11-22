using Helpers;

namespace View
{
    public interface IMultimeterView
    {
        void Redraw(States state, float value);

        void SetHandleActiveState(bool isActive);
    }
}