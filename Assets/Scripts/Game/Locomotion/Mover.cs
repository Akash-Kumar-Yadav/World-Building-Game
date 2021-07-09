using System.Collections;
using UnityEngine;

namespace Scripts.Game.Locomotion
{
    public class Mover : MonoBehaviour, IMover
    {
        public void CharacterMove(CharacterController characterController, Vector3 position,float speed)
        {
            if (characterController is null)
            {
                Debug.LogWarning(" character controller null");
            }
            characterController.Move(position*speed*Time.deltaTime);
           
        }
    }
}