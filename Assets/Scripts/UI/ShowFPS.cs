using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI
{
    public class ShowFPS : MonoBehaviour
    {
        [SerializeField] Text FPS;

        public float avgFrameRate;

        public void Update()
        {
            avgFrameRate = Time.frameCount / Time.time;
            FPS.text = "FPS: "+avgFrameRate.ToString("00");
        }
    }
}