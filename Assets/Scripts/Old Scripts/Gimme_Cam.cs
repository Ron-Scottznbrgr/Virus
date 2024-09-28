using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimme_Cam : NetworkBehaviour

{
    public GameObject CameraTarget;
    [SerializeField] private Camera playerCam;

    // Start is called before the first frame update
    void Start()
    {
       /* if (isLocalPlayer)
        {
            playerCam = Camera.FindObjectOfType<Camera>().transform;
            
            playerCam.parent = CameraTarget.transform;  //Make the camera a child of the mount point
            playerCam.position = CameraTarget.transform.position;  //Set position/rotation same as the mount point
            playerCam.rotation = CameraTarget.transform.rotation;
        }

        */

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
