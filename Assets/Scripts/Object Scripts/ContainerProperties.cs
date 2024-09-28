using UnityEngine;
using Mirror;

public class ContainerProperties : NetworkBehaviour
{
    [SyncVar]public float virusTimer;
    [SyncVar]public bool isOccupied;
    [SyncVar]public bool isContagious;
    



    private void Start()
    {
        //virusTimer = 0;
        //isOccupied = false;
        //isContagious = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (virusTimer > 0)
        {

            if (virusTimer > 0 && isContagious == false)
            {

                PushContagious(true);
        
            }


            if (isOccupied != true)
            {
                virusTimer -= Time.deltaTime;
            }
        }

        if (virusTimer<=0 && isContagious == true && isOccupied==false)
        {
            PushContagious(false);
            
        }


    }


    
    public void PushContagious(bool contagious)
    {
        isContagious = contagious;

    }
    
    public void PushOccupied(bool occupied)
    {
        isOccupied = occupied;

    }


    
    public void ResetTimer()
    {
        virusTimer = 30f;

    }

}
