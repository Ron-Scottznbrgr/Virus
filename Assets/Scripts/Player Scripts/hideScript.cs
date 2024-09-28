using UnityEngine;
using Mirror;

public class hideScript : NetworkBehaviour
{
     public PlayerStats playerStats;        //Player Stats Script
    //private PlayerMovement playerMove;
     public PlayerMovement2 playerMove;     //Player Movement Script
     public ParticleSystem particleFlames;  //Player Virus Particles
     public CharacterController charCont;   //Player Controller Physics Component
    public GameObject playerChar;           ///Player Character Object -- used to scale player up/down on hiding
    public RaycastHit fromRay;
    
    // Update is called once per frame
    //private BoxCollider bc;
    //private Rigidbody rb;
    [SyncVar]public string targetContainer;         //Name of the Object the player is trying to hide in (Debug purposes)
     public ContainerProperties cProps;             //Container Properties Script
     public ContainerProperties currentlyHidingIn;  //Currently hiding in which Object (used to reference back to obj after exit)

    [SyncVar]public bool canHide = false;           //is the player capable of hiding?
    [SyncVar]public Vector3 hidePosition;           //The position of the object the player will teleport to when inside an object

    [SyncVar] public float hideCooldown;
    public float hideCooldownConst;

    public void Start()
    {

       // bc = gameObject.GetComponent<BoxCollider>();
       // rb = gameObject.GetComponent<Rigidbody>();
       // playerStats = gameObject.GetComponent<PlayerStats>();
        //playerMove = gameObject.GetComponent<PlayerMovement>();
       // playerMove = gameObject.GetComponent<PlayerController>();
       // particleFlames = GetComponentInChildren<ParticleSystem>();
        
        //DefaultSkin = GetComponent<Renderer>().material;
    }

    private void FixedUpdate()
    {
         if (hideCooldown >= 0) 
        {
            hideCooldown -= Time.deltaTime;
        }
    }
    void Update()
    {



        if (isLocalPlayer && canHide == true && playerStats.isHiding == false && Input.GetKeyDown("e") && cProps.isOccupied == false)
        {
            HidePlayer(cProps);
            
        }


        if (isLocalPlayer && canHide==false && playerStats.isHiding == true && hideCooldown < 0)
            {
                if (isLocalPlayer && Input.GetKeyDown("e") && playerStats.isHiding == true)
                {
                UnhidePlayer();
                }
            }


       


    }

    public void DataDump(GameObject objContainer, string hitTag, ContainerProperties passedProps)
    {
        hidePosition = objContainer.transform.position;
        targetContainer = objContainer.name;
        cProps = passedProps;
        if (hitTag == "Hide")
        {
            //canHide = true;

        }
        else
        {
            canHide = false;

        }


    }


 //[Command]
   public void HidePlayer(ContainerProperties cProps_param)
    {
       this.cProps = cProps_param;

            
         //Debug.Log("Hide Successful");

        //Vector3 temp = new Vector3(collisionInfo.gameObject.transform.position.x, collisionInfo.gameObject.transform.position.y, collisionInfo.gameObject.transform.position.z);

        if (isLocalPlayer)
        {

            playerStats.previousPosition = transform.position;
            transform.position = hidePosition;
            playerMove.enabled = false;
            charCont.enabled = false;
            hideCooldown = hideCooldownConst;


            playerStats.isHiding = true;

            if (playerStats.isInfected == true)
            {
                //cProps.isContagious = true;
                playerStats.StopFlames();
            }

            if (playerStats.isInfected == false && cProps.isContagious == true)
            {
                Debug.Log("Infecting...");
                // playerStats.isInfected = true;
                PushInfection(playerStats);
               // particleFlames.Stop();
            }


        }    
            
            

            playerChar.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
          //  Debug.Log("Moving Player");
            
            currentlyHidingIn = cProps;
            canHide = false;


        //}









        //bc.enabled = false;
        //rb.velocity = Vector3.zero;
        //rb.useGravity = false;

        if (isLocalPlayer && playerStats.isInfected == true)
        {
            OccupyWallstreet(cProps, true, true); // player is infected, infect barrel
        }
        else
        {
            OccupyWallstreet(cProps, true, false) ; // player is not infected, dont infect barrel

        }

        
        //cProps.isOccupied = true;
        

       
    }

    
    void PushInfection(PlayerStats ppProps)
    {
       // ppProps.isInfected = true;
       // ppProps.isContagious = true;
        ppProps.ActivateVirus();
        ppProps.StopFlames();

    }

[Command]    
    void OccupyWallstreet(ContainerProperties targetCprop, bool occupied, bool infected)
    {
        targetCprop.isOccupied = occupied;
        targetCprop.isContagious = infected;

        if (infected==true && occupied == false)
        {
            // currentlyHidingIn.ResetTimer();
            targetCprop.ResetTimer();
        }



    }

    

   public void UnhidePlayer()
    {
        playerStats.isHiding = false;

        // Debug.Log("Unhide Successful");

        //Debug.Log(transform.position);
        //Debug.Log(playerStats.previousPosition);

        //Debug.Log(transform.position);
        //Vector3 temp = new Vector3(collisionInfo.gameObject.transform.position.x, collisionInfo.gameObject.transform.position.y, collisionInfo.gameObject.transform.position.z);
        Debug.Log("unhide");
        if (isLocalPlayer)
        {
            playerMove.enabled = true;
            playerChar.transform.localScale = new Vector3(1f, 1f, 1f);
            transform.position = playerStats.previousPosition;
            charCont.enabled = true;
        }
        //bc.enabled = true;
        //rb.useGravity = true;


        if (playerStats.isInfected == true)
        {
            OccupyWallstreet(currentlyHidingIn, false, true);

            playerStats.StartFlames();
            currentlyHidingIn.ResetTimer();
        }
        else
        {
            OccupyWallstreet(currentlyHidingIn, false, false);
        }
        
        

        
        //transform.position = temp;




    }


    /*

    void OnTriggerEnter(Collider collisionInfo)
    {
        
        if (collisionInfo.gameObject.tag == "Hide")
        {
            
            canHide = true;
            hidePosition = new Vector3(collisionInfo.gameObject.transform.position.x, collisionInfo.gameObject.transform.position.y, collisionInfo.gameObject.transform.position.z);
            targetContainer = collisionInfo.gameObject.name;
            cProps = collisionInfo.GetComponentInParent<ContainerProperties>();
                //.GetComponent<ContainerProperties>();
        }
    }*/


    /*


    void OnTriggerExit(Collider collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Hide")
        {
            canHide = false;
        }
    }*/

    /* private void OnTriggerStay(Collider other)
     {
         if (other.gameObject.tag == "Hide" && canHide==true && playerStats.isHiding==true)
         {
             other.GetComponent<ContainerProperties>().isOccupied = true;
         }
     }*/





    /*
    Debug.Log("Trigger on Barrel");
    Debug.Log(collisionInfo.gameObject.transform.position.x);
    Debug.Log(collisionInfo.gameObject.transform.position.y);
    Debug.Log(collisionInfo.gameObject.transform.position.z);
    */
    //collisionInfo.enabled = false;
    //collisionInfo.GetComponent<PlayerStats>().isInfected = true;





}