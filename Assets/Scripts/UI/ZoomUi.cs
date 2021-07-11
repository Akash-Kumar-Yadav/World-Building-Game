using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Scripts.UI
{
    public class ZoomUi : MonoBehaviour
    {
        Camera cam;
        [SerializeField] Slider slider;
        [SerializeField] GameObject sliderButton;

        static bool status;
        private void Start()
        {
            status = false;
            slider.onValueChanged.AddListener(delegate { SliderValue(); });
            slider.gameObject.SetActive(false);
            cam = Camera.main;
        }

        public void OnClick()
        {
            status = !status;
            var rect = slider.GetComponent<RectTransform>();
            
            slider.gameObject.SetActive(status);

        }
  
        public void SliderValue()
        {
            cam.transform.position = new Vector3(cam.transform.position.x,slider.value, cam.transform.position.z);
        }
    }
}