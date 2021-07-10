using System.Collections;
using UnityEngine;

namespace Scripts.Game.Locomotion
{
    public class Mover : MonoBehaviour, IMover
    {
        public void Move(CharacterController characterController, Vector3 position,float speed)
        {
            if (characterController is null)
            {
                Debug.LogWarning(" character controller null");
                return;
            }
            characterController.Move(position*speed*Time.deltaTime);
           
        }

        public void Move(Transform _transform, Vector3 position, float speed)
        {
            _transform.position += position*speed*Time.deltaTime;
        }
        public void Move(Transform _transform, Vector3 position)
        {
            _transform.position += position;
        }

     

        public void MoveToPoint(Transform _transform, Vector3 position)
        {
            _transform.position = position;
        }
    }
}