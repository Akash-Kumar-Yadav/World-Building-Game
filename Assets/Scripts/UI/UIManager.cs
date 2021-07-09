using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Scripts.Enum;

namespace Scripts.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] List<GameObject> panels = new List<GameObject>();
        [SerializeField] List<Button> HeaderButtons = new List<Button>();

        [SerializeField] GameObject InventoryPanel;
        [SerializeField] GameObject arrowPanel;
        [SerializeField] GameObject quitPanel;
        [SerializeField] Material highlight;
        [SerializeField] Material normal;

        private bool status;

        private void Awake()
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                arrowPanel.SetActive(true);
            }
            else
            {
                arrowPanel.SetActive(false);
            }
        }

        private void Start()
        {
            status = false;
            InventoryPanel.SetActive(status);
            InventoryPanel.transform.DOScale(new Vector3(0, 0, 0), 0);
            quitPanel.transform.DOScale(new Vector3(0, 0, 0), 0);
        }
        public void Shapes()
        {
            EnableORDisablePanels(UITags.Shapes.ToString());
        }
        public void Fence()
        {
            EnableORDisablePanels(UITags.Fence.ToString());
        }
        public void House()
        {
            EnableORDisablePanels(UITags.House.ToString());
        }
        public void Landscape()
        {
            EnableORDisablePanels(UITags.Nature.ToString());
        }

        public void Quit()
        {
            quitPanel.SetActive(true);
            quitPanel.transform.DOScale(new Vector3(1, 1, 1), .5f);
        }
        public void Yes()
        {
            Application.Quit();
        }
        public void No()
        {
            quitPanel.transform.DOScale(new Vector3(0, 0, 0), .5f).OnComplete(
                   () => quitPanel.SetActive(false));
        }
        public void Inventory()
        {
            status = !status;

            if (status)
            {
                InventoryPanel.SetActive(status);
                InventoryPanel.transform.DOScale(new Vector3(1, 1, 1), .5f);
            }
            else
            {
                InventoryPanel.transform.DOScale(new Vector3(0, 0, 0), .5f).OnComplete(
                    ()=> InventoryPanel.SetActive(status));
            }
        }

        private void EnableORDisablePanels(string name)
        {
            foreach (var item in panels)
            {
                if (item.gameObject.CompareTag(name))
                {
                    item.gameObject.SetActive(true);
                }
                else
                {
                    item.gameObject.SetActive(false);
                }
            }
        }

       
    }
}