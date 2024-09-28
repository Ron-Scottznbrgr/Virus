using UnityEngine;
using Mirror;

public class ButtonProperties : NetworkBehaviour
{

    public float virusTimer = 0;
     public float triggerTimer = 0;
     public float coolDownTimer = 10f;
     public bool isTriggered = false;
    [SyncVar]public bool canTriggerAgain = true;
     public bool isContagious = false;
     public ButtonProperties connectedButton;
     public bool twoButtsOneTrig = false;
     public bool leadButton = false;
    public bool hasMaterial;


    
    


     public Material ActivatedMaterial;
     public Material DeactivatedMaterial;

    void Start()
    {
        if (hasMaterial)
        {
           
            DeactivatedMaterial = GetComponent<Renderer>().material;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        if (virusTimer > 0)
        {

            if (virusTimer > 0 && isContagious == false)
            {
                isContagious = true;
            }



            virusTimer -= Time.deltaTime;

        }

        if (virusTimer <= 0 && isContagious == true)
        {
            isContagious = false;
        }

        if (triggerTimer >= 0 && isTriggered == true)
        {
            triggerTimer -= Time.deltaTime;
            TwoButtons();
            if (hasMaterial)
            {
                ActivateMatsForClients();
            }

            
        }

        if (triggerTimer < 0 && isTriggered == true)
        {
            isTriggered = false;
            triggerTimer = -1;
            canTriggerAgain = true;
            if (hasMaterial)
            {
                DeactivateMatsForClients();
            }
            leadButton = false;
        }


        


        

    }

    [ClientRpc]
    void ActivateMatsForClients()
    {
        GetComponent<Renderer>().material = ActivatedMaterial;
    }

    [ClientRpc]
    void DeactivateMatsForClients()
    {
        GetComponent<Renderer>().material = DeactivatedMaterial;
    }


    public void ResetVirusTimer()
    {
        virusTimer = 30f;

    }

    public void ResetTriggerTimer()
    {
        triggerTimer = coolDownTimer;
        leadButton = true;
    }

    void TwoButtons()
    {
        #region

        if (twoButtsOneTrig)
        {
            if (triggerTimer >= connectedButton.triggerTimer && leadButton)
            {
                connectedButton.triggerTimer = triggerTimer;
            }

            if (connectedButton.triggerTimer >= triggerTimer && !leadButton)
            {
                triggerTimer = connectedButton.triggerTimer;
            }

            if (isTriggered && !connectedButton.isTriggered && leadButton)
            {
                connectedButton.isTriggered = true;
            }

            if (connectedButton.isTriggered && !isTriggered && !leadButton)
            {
                isTriggered = true;
            }
            if (canTriggerAgain && !connectedButton.canTriggerAgain && !leadButton)
            {
                canTriggerAgain = false;
            }
            if (connectedButton.canTriggerAgain && !canTriggerAgain && leadButton)
            {
                connectedButton.canTriggerAgain = false;

            }


        }

        #endregion
    }

}
