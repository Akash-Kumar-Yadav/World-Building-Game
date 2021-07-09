using Scripts.Enum;
using Scripts.Game.Inputs;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Inventory
{
    public class InventoryElement : MonoBehaviour, IInventoryElement
    {
        [SerializeField] private GameObject prefab;

        private ICastRay castRay;

        private void Awake()
        {
            castRay = Camera.main.GetComponent<ICastRay>();
        }
        public void InstantiateObject()
        {
            Vector3 pos = new Vector3();
            if (castRay.GetHitPoint(Tags.Ground.ToString(), ref pos))
            {
                Instantiate(prefab, pos, Quaternion.identity);
            }
        }


    }
}