﻿using System.Collections;
using UnityEngine;

namespace Scripts.Rays
{
    public class CastRay : MonoBehaviour, ICastRay
    {
        [SerializeField] Camera cam;
        public Ray ScreenToRay => cam.ScreenPointToRay(Input.mousePosition);
        public Vector3 ScreenToWorldPoint => cam.ScreenToWorldPoint(Input.mousePosition);

        public bool CastingRay(string tagName)
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
    }


}