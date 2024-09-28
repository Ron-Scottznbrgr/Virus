using UnityEngine;
using Mirror;

public class PassVirus : NetworkBehaviour
{
    public PlayerStats transferVirus;
    public PlayerStats pProps;

    public Collider capusleColl;


    public WaterInfect water;

    // Update is called once per frame

    public void Start()
    {
        pProps = GetComponent<PlayerStats>();
        //   Debug.Log("Starting");
    }


    /*void OnCollisionEnter(Collision collisionInfo)
    {
        Debug.Log(collisionInfo);
        Debug.Log("WE HIT SHIT");
        if (collisionInfo.gameObject.tag == "Player")
        {
            
            transferVirus.isInfected = true;

        }
    }*/

    private void OnTriggerEnter(Collider collisionInfo)
    {

        if (collisionInfo.gameObject.tag == "Player" && transferVirus.isInfected == true)
        {
            
            Debug.Log("Trigger on Player");
            /*
            Debug.Log(collisionInfo.gameObject.transform.position.x);
            Debug.Log(collisionInfo.gameObject.transform.position.y);
            Debug.Log(collisionInfo.gameObject.transform.position.z);
            //collisionInfo.enabled = false;*/

            //PushInfection(collisionInfo);

            pProps = collisionInfo.GetComponent<PlayerStats>();

            //PushInfection(pProps);
            pProps.isInfected = true;
            pProps.isContagious = true;

        }


        if (collisionInfo.gameObject.tag == "canInfect" && pProps.isInfected==true)
        {
            water = (WaterInfect)collisionInfo.gameObject.GetComponentInChildren(typeof(WaterInfect));

            if (water.isContagious == false)
            {

                water.activated = true;
            }

            // if not contagious, && not clean, then set REDIRTY FLAG, taking Current color, instead of base color


           // Debug.Log("Trigger on "+gameObject.name);
           
            
           

        }

        if (collisionInfo.gameObject.tag == "canInfect" && pProps.isInfected == false)
        {
            water = (WaterInfect)collisionInfo.gameObject.GetComponentInChildren(typeof(WaterInfect));

            //Debug.Log("Trigger on " + gameObject.name);
         
            if (water.isContagious == true)
            {
                //water.activated = true;
                pProps.isContagious = true;
                pProps.isInfected = true;

            }

            

        }



    }

    private void OnTriggerStay(Collider collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "canInfect" && pProps.isInfected == true)
        {
            water = (WaterInfect)collisionInfo.gameObject.GetComponentInChildren(typeof(WaterInfect));

            /*
             * if water = !contagious && !pure && virustimer<=0, then activate, lerp color from current color to bad color;
            */


            if (water.virusTimer > 0)
            {
                water.ResetTimer();
            }

        }
    }
    

    //[Command]
    void PushInfection(PlayerStats ppProps)
    {
        ppProps.isInfected = true;
    }



}
