using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class SlidingDoor : NetworkBehaviour
{

    public ButtonProperties buttProps;
    public string tagName;
    private Vector3 originalPosition;
    [Tooltip("Any set to true will copy the original position from the Object's Position to the new position.")]
    public bool xLock, yLock, zLock;
    public Vector3 newPosition;
    public float moveSpeed=0.5f;
    public float defaultTimeActivated = 10f;
    public float timeActivated=0f;
    public bool changedPos = false;
    //door slide is usually +- 0.6547
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Door";
        tagName = gameObject.tag;
        originalPosition = gameObject.transform.localPosition;

        if (xLock)
        {
            newPosition.x = originalPosition.x;
        }
        if (yLock)
        {
            newPosition.y = originalPosition.y;
        }
        if (zLock)
        {
            newPosition.z = originalPosition.z;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (buttProps.isTriggered == true && changedPos==false && timeActivated <= 0 && buttProps.canTriggerAgain==true)
        {
            ResetTimeActivated();
        }



        if (timeActivated > 0 && changedPos==true && transform.position!=newPosition)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, newPosition, moveSpeed * Time.deltaTime);
        }

        if (timeActivated < 0 && changedPos ==true && transform.localPosition != originalPosition)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, originalPosition, moveSpeed * Time.deltaTime);
            
            if (transform.localPosition == originalPosition)
            {
                changedPos = false;
            }

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
}
