using Scripts.Game.Inputs;
using Scripts.Game.Locomotion;
using UnityEngine;

namespace Scripts.Game.Core
{
    public class Character : MonoBehaviour, ICharacter
    {
        [SerializeField] CharacterInputs characterInputs;
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
            Vector3 input = characterInputs.Inputs();
            mover.Move(characterController, input, characterInputs.speed);
            rotation.RotTo(input, this.transform, characterInputs.turnSpeed);
            characterInputs.CharacterAnimFloat(animator, "speed", input.magnitude);
        }


    }
}
