using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Mover
{
    public class CharacterMover : MonoBehaviour
    {
        [SerializeField] CharacterController characterController;
        [SerializeField] Animator animator;
        [SerializeField] float speed = 10f;
        [SerializeField] Transform cam;
        [SerializeField] float turnSpeed = 5f;

        private void Update()
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            var right = cam.right;
            var forward = cam.forward;

            right.y = 0;
            forward.y = 0;

            right.Normalize();
            forward.Normalize();

            Vector3 move = forward * v + right * h;
            Quaternion rot = Quaternion.LookRotation(move);

            characterController.Move(move * speed * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, turnSpeed * Time.deltaTime);

            animator.SetFloat("speed", move.magnitude);
        }
    }
}
