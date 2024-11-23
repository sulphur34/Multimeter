using System.Collections.Generic;
using Helpers;
using UnityEngine;

namespace View
{
    public class HandleRotator
    {
        private readonly float _defaultRotationX;
        private readonly float _defaultRotationY;
        private readonly Transform _handleTransform;
        private readonly Dictionary<States, float> _rotationStates;

        public HandleRotator(Transform handleTransform)
        {
            _handleTransform = handleTransform;
            var rotationVector = _handleTransform.rotation.eulerAngles;
            _defaultRotationX = rotationVector.x;
            _defaultRotationY = rotationVector.y;
            _rotationStates = new Dictionary<States, float>();
        }

        public void AddRotation(States state, Vector3 rotationPosition)
        {
            _rotationStates.Add(state, GetAngleFromDirection(rotationPosition));
        }

        public void SetRotationFromState(States state)
        {
            var rotationAngle = _rotationStates[state];
            _handleTransform.rotation = Quaternion.Euler(_defaultRotationX, _defaultRotationY, rotationAngle);
        }

        private float GetAngleFromDirection(Vector3 targetPosition)
        {
            var direction = targetPosition - _handleTransform.position;
            direction.z = 0;
            return Mathf.Atan2(direction.y, -direction.x) * Mathf.Rad2Deg;
        }
    }
}