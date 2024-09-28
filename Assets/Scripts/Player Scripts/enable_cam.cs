using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class enable_cam : NetworkBehaviour
{
    // Start is called before the first frame update

    public Camera myCam;
    public AudioListener audioComp;
    public MeshRenderer playerBod;
    public PlayerStats player;

    void Awake()
    {
       
    }

    void Start()
    {
        if (!isLocalPlayer)

        {
            
            myCam.enabled = false;
            myCam.gameObject.SetActive(false);

        }



        if (isLocalPlayer)
        {
            audioComp.enabled = false;
            playerBod.enabled = false;
           

        }

        /*
        if (isLocalPlayer)
        {
           myCam.enabled = true;
           audioComp.enabled = true;
            
        }*/

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
