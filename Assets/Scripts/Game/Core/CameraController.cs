using Scripts.Enum;
using Scripts.Game.Inputs;
using Scripts.Game.Locomotion;
using System.Collections;
using UnityEngine;

namespace Scripts.Game.Core
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] int Speed = 20;

        Vector3 origin;
        Vector3 current;
        Vector3 dir;

        ICastRay castRay;
        IMover mover;
        private void Start()
        {
            castRay = GetComponent<ICastRay>();
            mover = GetComponent<IMover>();
        }

        private void Update()
        {
            var pos = transform.position;
            pos.x = Mathf.Clamp(transform.position.x, -30, 30);
            pos.z = Mathf.Clamp(transform.position.z, -35, 35);
            transform.position = pos;

            if (Input.GetMouseButtonDown(0))
                origin = castRay.GetWorldPosition();

            if (Input.GetMouseButton(0))
            {
                current = castRay.GetWorldPosition();
                dir = origin - current;
                mover.Move(transform, dir);
            }

        }
    }
}