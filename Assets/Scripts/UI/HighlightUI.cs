
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

namespace Scripts.UI
{
    public class HighlightUI : MonoBehaviour, IPointerDownHandler, IPointerUpHandler,IPointerEnterHandler,IPointerExitHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            transform.DOScale(new Vector3(.9f, .9f, .9f), .3f);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), .3f);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            transform.DOScale(new Vector3(1, 1, 1), .3f);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            transform.DOScale(new Vector3(1, 1, 1), .3f);
        }

    }
}

