using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Debug_Button : NetworkBehaviour
{

    public ButtonProperties buttProps;
    public string tagName;
    public Vector3 originalPosition;
    public Vector3 newPosition;
    public float moveSpeed = 0.5f;
    public float defaultTimeActivated = 1f;
    public float timeActivated = 0f;
    public bool changedPos = false;
    public int DebugNumber=0;


    // Start is called before the first frame update
    void Start()
    {
        //gameObject.tag = "Debug";
        tagName = gameObject.tag;
        originalPosition = gameObject.transform.position;

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (buttProps.isTriggered == true && changedPos == false && timeActivated <= 0 && buttProps.canTriggerAgain == true)
        {
            ResetTimeActivated();
        }



        if (timeActivated > 0 && changedPos == true)
        {
            //    transform.position = Vector3.Lerp(transform.position, newPosition, moveSpeed * Time.deltaTime);

            DebugRedirect(DebugNumber);


            //Debug.Log("Shit Happens");
            changedPos = false;
        }

        if (timeActivated < 0 && changedPos == true)
        {
            changedPos = false;
            //  transform.position = Vector3.Lerp(transform.position, originalPosition, moveSpeed * Time.deltaTime);

            /*if (transform.position == originalPosition)
            {
                changedPos = false;
            }*/

        }


        if (timeActivated >= 0)
        {
            timeActivated -= Time.deltaTime;
        }
    }

    void ResetTimeActivated()
    {
        changedPos = true;
        timeActivated = defaultTimeActivated;
        buttProps.canTriggerAgain = false;
    }

    void DebugRedirect(int num)
    {

        switch (num)
        {
            case 5:
                
                break;
            case 4:
                
                break;
            case 3:
                
                break;
            case 2:
                
                break;
            case 1:
                
                break;
            case 0:
                DebugZero();
                break;
        }
    }

    void DebugZero()
    {
        List<GameObject> playerList  = new List<GameObject>();
        var myObject = GameObject.FindGameObjectsWithTag("Player");
        for (var i = 0; i < myObject.Length; i++)
        {
            playerList.Add(myObject[i]);
         //   yield;
        }
        Debug.Log("Active Players: " + playerList.Count);
       
        string pName = playerList[0].GetComponent<PlayerStats>().playerName;
            
        Debug.Log("Player 1: " + pName);
        //Debug.Log("Player 2: " + playerList[1]);

    }




}
