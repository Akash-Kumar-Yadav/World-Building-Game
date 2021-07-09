using Scripts.Inventory;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Scripts.UI
{
    public class DragAndDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler,IDropHandler
    {
        [SerializeField] GameObject obj;
        [SerializeField] Vector3 origin;
        private void Start()
        {
            obj = this.gameObject;
        }
        public void OnBeginDrag(PointerEventData eventData)
        {
            origin = obj.transform.position;
        }

        public void OnDrag(PointerEventData eventData)
        {
            obj.transform.position = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            obj.transform.position = origin;
        }

        public void OnDrop(PointerEventData eventData)
        {
          var inv = obj.GetComponent<IInventoryElement>();
            inv.InstantiateObject();
        }
    }
}
