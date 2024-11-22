using Helpers;

namespace Model
{
    public interface IMultimeterModel
    {
        void SwitchState(States state);
    }
}