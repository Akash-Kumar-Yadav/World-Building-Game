using System.Collections;
using UnityEngine;

namespace Scripts.Game.Inputs
{
    public class CastRay : MonoBehaviour, ICastRay
    {
        [SerializeField] Camera cam;

        private void Start()
        {
            if (cam == null)
            {
                cam = Camera.main;
            }
        }
        public Ray ScreenToRay => cam.ScreenPointToRay(Input.mousePosition);
        public Vector3 ScreenToWorldPoint => cam.ScreenToWorldPoint(Input.mousePosition);

        public bool GetRayCast(string tagName)
        {
            if (Physics.Raycast(ScreenToRay,out RaycastHit hit ,100))
            {
                if (hit.collider.CompareTag(tagName))
                {
                    return true;
                }
            }
            return false;
        }

        public bool GetHitPoint(string tagName, ref Vector3 pos)
        {
            if (Physics.Raycast(ScreenToRay, out RaycastHit hit, 100))
            {
                if (hit.collider.CompareTag(tagName))
                {
                    pos = hit.point;
                    return true;
                }
            }
            return false;
        }

        public Vector3 GetWorldPosition()
        {
            Plane ground = new Plane(Vector3.up, Vector3.zero);
            float distance;
            ground.Raycast(ScreenToRay, out distance);
            return ScreenToRay.GetPoint(distance);
        }
    }


}