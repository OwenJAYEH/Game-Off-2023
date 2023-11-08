using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Transform FirePoint;
    [SerializeField] private Transform FireVisualPoint;
    [SerializeField] private GameObject Fire;
    [SerializeField] private GameObject Hit;

    private PlayerInput playerInput;
    // Start is called before the first frame update
    void Start()
    {
        playerInput = new PlayerInput();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInput.actions["Fire"].WasPressedThisFrame()){
            RaycastHit hit;

            if (Physics.Raycast(FirePoint.position, transform.TransformDirection(Vector3.forward), out hit, 100))
            {
                Debug.DrawRay(FirePoint.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

                GameObject a = Instantiate(Fire, FireVisualPoint.position, Quaternion.identity);
                GameObject b = Instantiate(Hit, hit.point, Quaternion.identity);

                Destroy(a, 1);
                Destroy(b, 1);
            }
        }

    }
}
