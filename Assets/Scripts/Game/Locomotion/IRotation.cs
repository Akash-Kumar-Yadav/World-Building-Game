using UnityEngine;

namespace Scripts.Game.Locomotion
{
    public interface IRotation
    {
        void RotTo(Vector3 rot, Transform _transform, float turnSpeed);
    }
}