using UnityEngine;

namespace Scripts.Game.Locomotion
{
    public interface IMover
    {
        void CharacterMove(CharacterController characterController, Vector3 position,float speed);
    }
}