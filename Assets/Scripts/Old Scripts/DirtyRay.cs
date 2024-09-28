using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class DirtyRay : NetworkBehaviour
{
    // Start is called before the first frame update
    public PressButtonScript pressButton;
    public GameObject DirtyRayBox;


    




    // Update is called once per frame
    void Update()
    {
       
    }


    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Button")
        {




            Debug.Log("POKE");
            pressButton.canTrigger = true;
        }
    }

    private void OnCollisionExit(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Button")
        {
            Debug.Log(collisionInfo.gameObject.tag);
            pressButton.canTrigger = false;
        }
    }
}
