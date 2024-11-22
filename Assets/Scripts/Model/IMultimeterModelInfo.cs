using System;

namespace Model
{
    public interface IMultimeterModelInfo
    {
        event Action<ReadingsData> StateChanged;
    }
}