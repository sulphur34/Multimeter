using System;
using Helpers;

namespace Model
{
    public class MultimeterMultimeterModel : IMultimeterModel, IMultimeterModelInfo
    {
        private readonly float _voltageDC = 0.01f;

        private float _resistance;
        private float _power;
        private States _state;

        public event Action<ReadingsData> StateChanged;

        public MultimeterMultimeterModel(float resistance, float power)
        {
            _resistance = resistance;
            _power = power;
        }

        public void SwitchState(States state)
        {
            float readings = 0;
            _state = state;

            switch (_state)
            {
                case States.Off:
                    break;

                case States.VoltageAC:
                    readings = GetVoltageAC();
                    break;

                case States.Resistance:
                    readings = _resistance;
                    break;

                case States.Current:
                    readings = GetCurrent();
                    break;

                case States.VoltageDC:
                    readings = _voltageDC;
                    break;

                default:
                    throw new ArgumentException();
            }

            var readingsData = new ReadingsData(readings, _state);
            StateChanged?.Invoke(readingsData);
        }

        private float GetCurrent()
        {
            return MathF.Sqrt(_power / _resistance);
        }

        private float GetVoltageAC()
        {
            return MathF.Sqrt(_power * _resistance);
        }
    }
}