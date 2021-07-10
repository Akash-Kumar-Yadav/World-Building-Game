using Scripts.Game.Inputs;
using Scripts.Game.Locomotion;
using UnityEngine;

namespace Scripts.Game.Core
{    
    public class Character : MonoBehaviour
    {
        [SerializeField] CharacterInputs characterInputs;
        [SerializeField] CharacterController characterController;
        [SerializeField] Animator animator;
        IMover mover;
        IRotation rotation;

        private void Start()
        {
            characterInputs.Init();
            mover = GetComponent<IMover>();
            rotation = GetComponent<IRotation>();
        }
        private void Update()
        {
            Vector3 input = characterInputs.Inputs();
            mover.Move(characterController, input,characterInputs.speed);
            rotation.RotTo(input, this.transform, characterInputs.turnSpeed);
            characterInputs.CharacterAnimFloat(animator,"speed", input.magnitude);
        }

       
    }
}
