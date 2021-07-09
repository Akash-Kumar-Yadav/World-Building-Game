using Scripts.Enum;
using Scripts.Rays;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Inventory
{
    public class InventoryElement : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private Material highlight;

        private Material currentMaterial;
        private Button currentButton;

        private ICastRay castRay;
       
        private void Awake()
        {
            currentButton = GetComponent<Button>();
            currentButton.onClick.AddListener(OnClick);
           

            castRay = Camera.main.GetComponent<ICastRay>();
        }
        private void OnClick()
        {
            Vector3 pos = new Vector3();
            if (castRay.GetHitPoint(Tags.Ground.ToString(),ref pos))
            {
               GameObject obj = Instantiate(prefab, pos, Quaternion.identity);
                obj.GetComponent<Renderer>().material = highlight;

            }
        }

       
    }
}