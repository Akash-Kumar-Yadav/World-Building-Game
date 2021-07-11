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
        [SerializeField] MobileInput mobileInput;

        public void Init()
        {
            mobileInput = FindObjectOfType<MobileInput>();
            cam = Camera.main.transform;
        }
        public Vector3 Inputs()
        {
            float h = 0;
            float v = 0;
            if (!CheckPlatform.isAndroid)
            {
                h = Input.GetAxis(horizontal);
                v = Input.GetAxis(vertical);

            }
            else
            {
                if (mobileInput.forward)
                {
                    v = 1;
                }
                else if (mobileInput.back)
                {
                    v = -1;
                } 
                else if (mobileInput.left)
                {
                    h = -1;
                } 
                else if (mobileInput.right)
                {
                    h = 1;
                }
                else
                {
                    h = 0;
                    v = 0;
                }
            }
           

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