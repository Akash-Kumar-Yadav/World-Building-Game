using System.Collections;
using UnityEngine;

namespace Scripts.Game.Locomotion
{
    public class Rotation : MonoBehaviour, IRotation
    {
        public void RotTo(Vector3 rot, Transform _transform, float turnSpeed)
        {
            Quaternion lookRot = Quaternion.LookRotation(rot);
            _transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, turnSpeed * Time.deltaTime);
        }

    }
}