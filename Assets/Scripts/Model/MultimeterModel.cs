using System;
using Helpers;
using View;

namespace Model
{
    public class MultimeterModel : IMultimeterModel
    {
        private readonly float _power;
        private readonly float _resistance;
        private readonly IMultimeterView _view;
        private readonly float _voltageDC = 0.01f;

        private States _state;

        public MultimeterModel(float resistance, float power, IMultimeterView view)
        {
            _resistance = resistance;
            _power = power;
            _view = view;
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

            _view.Redraw(_state, readings);
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