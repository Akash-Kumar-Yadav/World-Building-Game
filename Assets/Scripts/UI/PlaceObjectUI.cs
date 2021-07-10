using System;
using UnityEngine;

namespace Scripts.UI
{
    public class PlaceObjectUI : MonoBehaviour
    {
        public static Action<bool> OnInstantiated;
        public static Action OnYesClicked;
        public static Action OnNoClicked;

        [SerializeField] GameObject placeObjectPanel;

        private void Awake()
        {
            OnInstantiated += ObjectInstantiate;
           
        }

        public void Yes()
        {
            if (OnYesClicked != null)
            {
                OnYesClicked.Invoke();
                ObjectInstantiate(false);
            }
        } 
        public void No()
        {
            if (OnNoClicked != null)
            {
                OnNoClicked.Invoke();
                ObjectInstantiate(false);
            }
        }

        private void ObjectInstantiate(bool obj)
        {
            placeObjectPanel.SetActive(obj);
        }
    }
}