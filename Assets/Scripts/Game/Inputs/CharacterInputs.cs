using System.Collections;
using UnityEngine;

namespace Scripts.Game.Inputs
{
    [CreateAssetMenu(fileName = "Character",menuName = "Inputs")]
    public class CharacterInputs : ScriptableObject
    {
        public float speed = 10f;
        public Transform cam;
        public float turnSpeed = 5f;

        [SerializeField] string horizontal;
        [SerializeField] string vertical;

        private void Awake()
        {
            cam = Camera.main.transform;
        }
        public Vector3 Inputs()
        {
            float h = Input.GetAxis(horizontal);
            float v = Input.GetAxis(vertical);

            var right = cam.right;
            var forward = cam.forward;

            right.y = 0;
            forward.y = 0;

            right.Normalize();
            forward.Normalize();

            Vector3 move = forward * v + right * h;
            return move;
        }

        public void CharacterAnimFloat(Animator animator,string animName ,float animValue)
        {
            
            animator.SetFloat(animName, animValue);
        }
    }
}