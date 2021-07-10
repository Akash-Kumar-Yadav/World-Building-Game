using Scripts.Enum;
using Scripts.Game.Inputs;
using Scripts.Game.Locomotion;
using System;
using System.Collections;
using UnityEngine;
using Scripts.UI;

namespace Scripts.Game.Inventory
{
    public class PlaceObject : MonoBehaviour
    {
       
        [SerializeField] Material originalMaterial;
        [SerializeField] Material highlightMaterial;

        bool canMove;
        Vector3 origin;
        Vector3 current;
        Vector3 dir;

        ICastRay castRay;
        IMover mover;

        private void Awake()
        {
            canMove = true;
           
            castRay = GetComponent<ICastRay>();
            mover = GetComponent<IMover>();

            if (PlaceObjectUI.OnInstantiated != null)
            {
                PlaceObjectUI.OnInstantiated.Invoke(true);
            }

            if (GetComponent<Renderer>() == null)
            {
                GetComponentInChildren<Renderer>().sharedMaterial = highlightMaterial;
            }
            else
            {
                GetComponent<Renderer>().sharedMaterial = highlightMaterial;
            }

            PlaceObjectUI.OnYesClicked += Place;
            PlaceObjectUI.OnNoClicked += Cancel;
        }

        public void Cancel()
        {
            Destroy(this.gameObject);
        }

        private void OnMouseDrag()
        {
            if (!canMove) { return; }

            if (Input.GetMouseButtonDown(0))
                castRay.GetHitPoint(Tags.Ground.ToString(), ref origin);

            if (Input.GetMouseButton(0))
            {
                castRay.GetHitPoint(Tags.Ground.ToString(), ref current);
                dir = current - origin;
                dir.y = 0;
                mover.MoveToPoint(transform, new Vector3(dir.x, transform.position.y, dir.z));
            }


        }
        public void Place()
        {
            canMove = false;
            if (GetComponent<Renderer>() == null)
            {
                GetComponentInChildren<Renderer>().sharedMaterial = originalMaterial;
            }
            else
            {
                GetComponent<Renderer>().sharedMaterial = originalMaterial;
            }
            PlaceObjectUI.OnYesClicked -= Place;
            PlaceObjectUI.OnNoClicked -= Cancel;
        }

        private void OnDisable()
        {
            PlaceObjectUI.OnYesClicked -= Place;
            PlaceObjectUI.OnNoClicked -= Cancel;
        }
    }
}