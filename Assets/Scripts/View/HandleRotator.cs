using System.Collections.Generic;
using System.Linq;
using Helpers;
using UnityEngine;

namespace View
{
    public class HandleRotator
    {
        private Transform _handleTransform;
        private Dictionary<States, float> _rotationAngles;
        private float _defaultRotationX;
        private float _defaultRotationY;

        public HandleRotator(Transform handleTransform, Dictionary<States, Vector3> rotationPositions)
        {
            _handleTransform = handleTransform;
            var rotationVector = _handleTransform.rotation.eulerAngles;
            _defaultRotationX = rotationVector.x;
            _defaultRotationY = rotationVector.y;
            _rotationAngles = GetRotationAngles(rotationPositions);
        }

        public void SetRotationFromState(States state)
        {
            float rotationAngle = _rotationAngles[state];
            _handleTransform.rotation = Quaternion.Euler(_defaultRotationX, _defaultRotationY, rotationAngle);
        }

        private Dictionary<States, float> GetRotationAngles(Dictionary<States, Vector3> rotationPositions)
        {
            return rotationPositions
                .ToDictionary(
                    rotationPosition => rotationPosition.Key,
                    rotationPosition => GetAngleFromDirection(rotationPosition.Value));
        }

        private float GetAngleFromDirection(Vector3 targetPosition)
        {
            Vector3 direction = targetPosition - _handleTransform.position;
            direction.z = 0;
            return Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        }
    }
}