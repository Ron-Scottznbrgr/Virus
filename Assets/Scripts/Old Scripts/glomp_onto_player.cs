﻿using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glomp_onto_player : NetworkBehaviour
{

    public GameObject CameraMountPoint;


    // Start is called before the first frame update
    void Start()
    {
        if (isLocalPlayer)
        {
            Transform cameraTransform = Camera.main.gameObject.transform;  //Find main camera which is part of the scene instead of the prefab
            cameraTransform.parent = CameraMountPoint.transform;  //Make the camera a child of the mount point
            cameraTransform.position = CameraMountPoint.transform.position;  //Set position/rotation same as the mount point
            cameraTransform.rotation = CameraMountPoint.transform.rotation;
        }
    }
}
