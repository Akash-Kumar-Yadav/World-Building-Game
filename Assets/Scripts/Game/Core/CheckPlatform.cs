using System.Collections;
using UnityEngine;



    public class CheckPlatform : MonoBehaviour
    {
        public static bool isAndroid { get; private set; }

        private void Awake()
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                isAndroid = true;
            }
            else
            {
                isAndroid = false;

            }
        }

    }
