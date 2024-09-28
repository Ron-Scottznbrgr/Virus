using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class StandardDoor : NetworkBehaviour
{

    public ButtonProperties buttProps;
    public string tagName;
    //private Vector3 closedAngle;
    //[Tooltip("Any set to true will copy the original position from the Object's Position to the new position.")]
    //public bool xLock, yLock, zLock;
    //public Vector3 openAngle;
    public float moveSpeed=5f;
    //public float defaultcoolDown = 5f;
    //public float coolDown=0f;
    //public bool changedPos = false;
    public int DoorQuestStage=0; //0 is closed, 1 is opening, 2 is closing
    public bool moving=false;

    public float rotationAngle;
    //public GameObject doorParent;


    //public Vector3 closedAngle;
    //public Vector3 currentAngle;
   // public float wherearewe;
   // public Vector3 openAngle;

    private Quaternion closed_angle;
    private Quaternion open_angle;
    private Quaternion current_Quat;

    public bool isButtonOnDoor;
        //door slide is usually +- 0.6547

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Door";
        tagName = gameObject.tag;
        //closedAngle = gameObject.transform.localRotation;
        //closedAngle = transform.localEulerAngles;
        closed_angle = Quaternion.Euler(new Vector3 (transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z));
        open_angle = Quaternion.Euler(new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y+rotationAngle, transform.localEulerAngles.z));
        current_Quat = closed_angle;
       
        /*if (isButtonOnDoor)
        {
            
        }*/
        

        //openAngle = new Vector3(closedAngle.x, closedAngle.y - rotationAngle, closedAngle.z);
        //wherearewe = transform.localEulerAngles.y;
        //transform.localEulerAngles = closedAngle;



        /*
        if (xLock)
        {
            openAngle.x = closedAngle.x;
        }
        if (yLock)
        {
            openAngle.y = closedAngle.y;
        }
        if (zLock)
        {
            openAngle.z = closedAngle.z;
        }
        */
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (buttProps.isTriggered == true && DoorQuestStage < 2 && moving == false && buttProps.canTriggerAgain==true)
        {
            ResetcoolDown();
          
        }



        if (DoorQuestStage == 1 && moving == true && current_Quat !=open_angle)
        {

            /*currentAngle = new Vector3(
           Mathf.LerpAngle(currentAngle.x, openAngle.x, moveSpeed * Time.deltaTime),
           Mathf.LerpAngle(currentAngle.y, openAngle.y, moveSpeed * Time.deltaTime),
           Mathf.LerpAngle(currentAngle.z, openAngle.z, moveSpeed * Time.deltaTime));

            transform.localEulerAngles = currentAngle;*/
            current_Quat = Quaternion.RotateTowards(transform.rotation, open_angle, moveSpeed * Time.deltaTime);
            
            transform.rotation = current_Quat;

            if (current_Quat == open_angle)
            {
                moving = false;               
            }
        }

        

        if (moving==true && DoorQuestStage==2 && current_Quat != closed_angle)
        {
            /*
            currentAngle = new Vector3(
           Mathf.LerpAngle(currentAngle.x, closedAngle.x, moveSpeed * Time.deltaTime),
           Mathf.LerpAngle(currentAngle.y, closedAngle.y, moveSpeed * Time.deltaTime),
           Mathf.LerpAngle(currentAngle.z, closedAngle.z, moveSpeed * Time.deltaTime));

            transform.localEulerAngles = currentAngle;*/
            current_Quat = Quaternion.RotateTowards(transform.rotation, closed_angle, moveSpeed * Time.deltaTime);
            transform.rotation = current_Quat;


            if (current_Quat == closed_angle)
            {
                moving = false;
                DoorQuestStage = 0;
            }

        }


       
    }

    void ResetcoolDown()
    {
        //        coolDown = defaultcoolDown;
        moving = true;
        DoorQuestStage += 1;
        buttProps.canTriggerAgain = false;
    }
}
