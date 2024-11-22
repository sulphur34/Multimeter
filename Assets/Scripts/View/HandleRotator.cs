using System.Collections.Generic;
using System.Linq;
using Helpers;
using UnityEngine;

namespace View
{
    public class HandleRotator
    {
        private Transform _handleTransform;
        private Dictionary<States, float> _rotationStates;
        private float _defaultRotationX;
        private float _defaultRotationY;

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
            float rotationAngle = _rotationStates[state];
            _handleTransform.rotation = Quaternion.Euler(_defaultRotationX, _defaultRotationY, rotationAngle);
        }

        private float GetAngleFromDirection(Vector3 targetPosition)
        {
            Vector3 direction = targetPosition - _handleTransform.position;
            direction.z = 0;
            return Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        }
    }
}