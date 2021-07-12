using Scripts.Game.Inputs;
using Scripts.Game.Locomotion;
using UnityEngine;

namespace Scripts.Game.Core
{
    public class Character : MonoBehaviour, ICharacter
    {
        [SerializeField] CharacterInputs characterInputs;

        float playerSpeed = 2.0f;
        float jumpHeight = 1.0f;
        float gravityValue = -9.81f;
        Vector3 playerVelocity;
        bool groundedPlayer;
        public CharacterController characterController { get; private set; }

        public Animator animator { get; private set; }
        IMover mover;
        IRotation rotation;

        private void Start()
        {
            characterInputs.Init();
            mover = GetComponent<IMover>();
            rotation = GetComponent<IRotation>();
            animator = GetComponent<Animator>();
            characterController = GetComponent<CharacterController>();
        }
        private void Update()
        {
            groundedPlayer = characterController.isGrounded;
            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }
            Vector3 input = characterInputs.Inputs();
            mover.Move(characterController, input, characterInputs.speed);
            rotation.RotTo(input, this.transform, characterInputs.turnSpeed);
            characterInputs.CharacterAnimFloat(animator, "speed", input.magnitude);

            playerVelocity.y += gravityValue * Time.deltaTime;
            characterController.Move(playerVelocity * Time.deltaTime);
        }


    }
}
