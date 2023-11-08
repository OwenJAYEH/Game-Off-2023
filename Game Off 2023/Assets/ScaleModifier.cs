using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

namespace Q3Movement
{
    public class ScaleModifier : MonoBehaviour
    {
        [SerializeField] private GameObject playerCamera;

        private PlayerInput playerInput;
        private bool scaledDown = false;
        private CharacterController characterController;
        private CapsuleCollider capsuleCollider;
        private Q3PlayerController playerController;
        public int heightScale;


        // Start is called before the first frame update
        void Start()
        {
            playerController = GetComponent<Q3PlayerController>();
            playerInput = GetComponent<PlayerInput>();
            characterController = GetComponent<CharacterController>();
            capsuleCollider = GetComponent<CapsuleCollider>();
        }

        // Update is called once per frame
        void Update()
        {
            if (playerInput.actions["Scale"].WasPressedThisFrame() && !scaledDown)
            {
                this.playerCamera.transform.localScale = new Vector3(this.playerCamera.transform.localScale.x / heightScale, this.playerCamera.transform.localScale.y / heightScale, this.playerCamera.transform.localScale.z / heightScale);
                this.gameObject.transform.localScale = new Vector3(this.gameObject.transform.localScale.x / heightScale, this.gameObject.transform.localScale.y / heightScale, this.gameObject.transform.localScale.z / heightScale);
                capsuleCollider.height = capsuleCollider.height / heightScale;
                capsuleCollider.radius = capsuleCollider.radius / heightScale;
                characterController.height = characterController.height / heightScale;
                characterController.radius = characterController.radius / heightScale;
                scaledDown = true;
                playerController.eventSmallMode.Invoke();
                Debug.Log("Going small mode");
            }
            else if (playerInput.actions["Scale"].WasPressedThisFrame() && scaledDown)
            {
                this.playerCamera.transform.localScale = new Vector3(this.playerCamera.transform.localScale.x * heightScale, this.playerCamera.transform.localScale.y * heightScale, this.playerCamera.transform.localScale.z * heightScale);
                this.gameObject.transform.localScale = new Vector3(this.gameObject.transform.localScale.x * heightScale, this.gameObject.transform.localScale.y * heightScale, this.gameObject.transform.localScale.z * heightScale);
                capsuleCollider.height = capsuleCollider.height * heightScale;
                capsuleCollider.radius = capsuleCollider.radius * heightScale;
                characterController.height = characterController.height * heightScale;
                characterController.radius = characterController.radius * heightScale;
                scaledDown = false;
                playerController.eventBigMode.Invoke();
                Debug.Log("Going big mode");
            }
        }
    }

}
