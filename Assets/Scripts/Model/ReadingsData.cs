using Helpers;

namespace Model
{
    public struct ReadingsData
    {
        public readonly float Value;
        public readonly States State;

        public ReadingsData(float value, States state)
        {
            Value = value;
            State = state;
        }
    }
}