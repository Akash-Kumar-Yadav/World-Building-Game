using Scripts.Game.Core;
using Scripts.Game.Locomotion;
using System;
using System.Collections;
using UnityEngine;

namespace Scripts.Game.Inputs
{
    public class MobileInput : MonoBehaviour
    {

        public bool forward { get; private set; }
        public bool back { get; private set; }
        public bool left { get; private set; }
        public bool right { get; private set; }

        public void ForwardDown() => forward = true;
        public void ForwardUp() => forward = false;
        public void BackDown() => back = true;
        public void BackUp() => back = false;
        public void LeftDown() => left = true;
        public void LeftUp() => left = false;
        public void RightDown() => right = true;
        public void Rightup() => right = false;

        
    }
}