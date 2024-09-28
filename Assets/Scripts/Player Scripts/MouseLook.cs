using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MouseLook: NetworkBehaviour
{

    public float mouse_X_Sensitivity = 100f;
    public float mouse_Y_Sensitivity = 100f;
    public bool isInverted;
    public Transform playerBody;
    //public NetworkIdentity parentID;
    public Transform playerHead;
    //public Camera mainCam;


   [SyncVar]float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
        Cursor.lockState = CursorLockMode.Locked;
       // Camera mainCam = GameObject.Find("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!isLocalPlayer)
        {
            return;

        }
        float mouseX = Input.GetAxis("Mouse X") * mouse_X_Sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouse_Y_Sensitivity * Time.deltaTime;


        if (isInverted)
        {
            mouseY *= -1f;
        }

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //playerHead.GetComponentInParent<NetworkIdentity>();
        playerHead.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);


    }
}
