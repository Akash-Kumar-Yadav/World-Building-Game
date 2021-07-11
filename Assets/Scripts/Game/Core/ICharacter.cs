using UnityEngine;

namespace Scripts.Game.Core
{
    public interface ICharacter
    {
        Animator animator { get; }
        CharacterController characterController { get; }
    }
}