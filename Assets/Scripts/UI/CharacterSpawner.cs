using System;
using System.Collections;
using UnityEngine;

namespace Scripts.UI
{
    public class CharacterSpawner : MonoBehaviour
    {
        [SerializeField] Transform prefab;
        [SerializeField] Transform spawnpoint;
        [SerializeField] GameObject arrowPanel;
        [SerializeField] Vector3 camPos;
        [SerializeField] Quaternion camRot;
        [SerializeField] Camera cam;
       

        [SerializeField] GameObject character;

        public static Action OnCharacterSpawned;
        public static Action OnCharacterDisable;
        public bool isAndroid { get; private set; }
        private void Awake()
        {
            Init();

            if (Application.platform == RuntimePlatform.Android)
            {
                isAndroid = true;
            }
            else
            {
                isAndroid = false;

            }

        }

        private void Init()
        {
            cam = Camera.main;
            camPos = cam.transform.position;
            camRot = cam.transform.rotation;
            arrowPanel.SetActive(false);
            OnCharacterDisable += DisableCharacter;
        }

        public void Spawn()
        {
            if (OnCharacterSpawned != null)
            {
                OnCharacterSpawned.Invoke();
            }
            if (!GetCharacter())
            {
                Instantiate(prefab, spawnpoint.position, Quaternion.identity);
            }
            if (isAndroid)
            {
                arrowPanel.SetActive(true);
            }
        }

        private void DisableCharacter()
        {
            if (character == null)
            {
                character = GameObject.FindGameObjectWithTag("Player");
            }
            Destroy(character.gameObject);
            cam.transform.position = camPos;
            cam.transform.rotation = camRot;
            arrowPanel.SetActive(false);
        }

        private void OnDisable()
        {
            OnCharacterDisable -= DisableCharacter;
        }

        GameObject GetCharacter()
        {
            return GameObject.FindGameObjectWithTag("Player");
        }

    }
}