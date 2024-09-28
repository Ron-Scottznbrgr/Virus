using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class RayCaster : NetworkBehaviour
{

    public PressButtonScript pressButton;
    public PlayerStats playerStats;
    public hideScript hideScript;
    public ButtonProperties buttProps;
    public ContainerProperties cProps;
    public string hitTag;
    public int rayLength; // 5 is good

    public Camera myCam;

   // public bool hideFired=false;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        //var ray = Camera.main.

        Ray forwardRay = new Ray(myCam.transform.position, myCam.transform.forward);
        //Debug.DrawRay(Camera.main.transform.position, transform.forward, Color.green);
        Debug.DrawRay(myCam.transform.position, myCam.transform.forward * 1000, Color.blue);
        Debug.DrawRay(myCam.transform.position, myCam.transform.forward * rayLength, Color.green);
        
        if (Physics.Raycast(forwardRay, out hit,rayLength))
        {
            var selection = hit.transform;
            hitTag = hit.collider.tag;

            if (hit.collider.CompareTag("Button") && playerStats.isHiding == false )
            {
                pressButton.canTrigger = true;
                buttProps = hit.collider.GetComponentInParent<ButtonProperties>();
                pressButton.buttProps = buttProps;
                //Debug.Log("Hit");            
            }
            else
            {
                pressButton.canTrigger = false;

            }


            if (hit.collider.CompareTag("Hide")&& playerStats.isHiding==false)
            {
                //Debug.Log("Dumping");
                cProps = hit.collider.GetComponentInParent<ContainerProperties>();
                hideScript.canHide = true;
                hideScript.DataDump(hit.collider.gameObject,hitTag, cProps);
                
                
                /*
                
                    if (isLocalPlayer && Input.GetKeyDown("e") && playerStats.isHiding == false && hideScript.canHide==true && cProps.isOccupied==false && hit.collider.CompareTag("Hide"))
                    {

                    hideScript.hidePosition = hit.collider.gameObject.transform.position;
                    hideScript.targetContainer = hit.collider.gameObject.name;
                   
                    //Debug.Log("Target Container: " + hideScript.targetContainer+"//  Player is Hiding: "+playerStats.isHiding+"//  Can hide here: "+hideScript.canHide+"// Occupied? "+cProps.isOccupied);
                    
                    //hit = new RaycastHit();
                    
                    hideScript.HidePlayer(cProps);
                    // this.enabled = false;

                   // Debug.Log("Tag Before: "+hit.collider.tag);
                    // forwardRay = new Ray(new Vector3(0f,0f,0f), new Vector3(1f,1f,1f));
                    // Debug.Log("Made it to after HIdeplayer");
                   // hit.collider.tag = "Untagged";
                   // Debug.Log("Tag After: "+hit.collider.tag);




                }
                    else
                    {

                    //hideScript.canHide = false;


                    }


                */




            }
            else
            {
                
                  hideScript.canHide = false;
                
                //hideFired = false;
               

            }

            



            
        }
        else
        {
            hideScript.canHide = false;
            pressButton.canTrigger = false;
        }



    }
}
