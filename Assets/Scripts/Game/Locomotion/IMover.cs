using UnityEngine;

namespace Scripts.Game.Locomotion
{
    public interface IMover
    {
        void Move(CharacterController characterController, Vector3 position,float speed);
        void Move(Transform _transform, Vector3 position,float speed);
        void Move(Transform _transform, Vector3 position);
    }
}