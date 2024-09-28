using UnityEngine;
using Mirror;

public class PressButtonScript : NetworkBehaviour
{
     public PlayerStats playerStats;
    private BoxCollider bc;
     private Rigidbody rb;
    public string targetObject;
    public ButtonProperties buttProps;
    //public BoxCollider DirtyRay;

     public bool canTrigger = false;
    Vector3 DoorOpenPosition;
    Vector3 DoorClosePosition;

    public void Start()
    {

            //bc = gameObject.GetComponent<BoxCollider>();
            //rb = gameObject.GetComponent<Rigidbody>();

            playerStats = gameObject.GetComponentInParent<PlayerStats>();
         
            
        //gameObject.GetComponent<PlayerStats>();
        //playerMove = gameObject.GetComponent<PlayerMovement>();


        //DefaultSkin = GetComponent<Renderer>().material;
    }

    void Update()
    {

       
        if (canTrigger == true)
        {
            if (isLocalPlayer && Input.GetKeyDown("e") && buttProps.isTriggered == false)
            {
                ActivateButton();
            }
        }
    }

    [Command]
    void ActivateButton()
    {
        Debug.Log("Button Activated");
        
        buttProps.isTriggered = true;

        buttProps.ResetTriggerTimer();
        // Debug.Log("Button Successful");


        if (playerStats.isInfected == true)
        {
            buttProps.isContagious = true;
            buttProps.ResetVirusTimer();
        }

        if (playerStats.isInfected == false && buttProps.isContagious == true)
        {
            playerStats.isInfected = true;
        }
    }


    /*void OnTriggerEnter(Collider collisionInfo)
    {
            if (collisionInfo.gameObject.tag == "Button")
            {
            Debug.Log("ENTERING");
                canTrigger = true;
               buttProps = collisionInfo.GetComponentInParent<ButtonProperties>();

            }
       
    }


    void OnTriggerExit(Collider collisionInfo)
    {
        
        if (collisionInfo.gameObject.tag == "Button")
            {
            Debug.Log("EXITING");
            canTrigger = false;
            }
        
    }*/



    /*public void CollisionDetected(ChildScript childScript)
        {
            Debug.Log("child collided");
        }

    */


}