using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{

    /// <summary>
    /// Creates a camera that follows the player, 
    /// and allows the player to hold W and go away from the 
    /// camera, no matter the angle...
    /// 
    /// also taken from https://www.youtube.com/watch?v=cVy-NTjqZR8&list=WL&index=18
    /// ^ I'm not here to reinvent the wheel.
    /// </summary>


    public Transform target;
    public Vector3 offsetPos; //How far off the X from the player.
    public float moveSpeed = 5;
    public float turnSpeed = 10; //10
    public float smoothSpeed = 2f; //How quick the camera pivots //0.5

    Quaternion targetRotation;
    Vector3 targetPos;
    bool smoothRotating = false;

    private void Update()
    {
        MoveWithTarget();
        LookAtTarget();

        if (Input.GetKey(KeyCode.G) && !smoothRotating)
        {
            StartCoroutine("RotateAroundTarget", 45);//45
            
        }

        if (Input.GetKey(KeyCode.H) && !smoothRotating)
        {
            StartCoroutine("RotateAroundTarget", -45);
            
        }

    }

    void MoveWithTarget()
    {
        targetPos = target.position + offsetPos;
        transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);




    }

    void LookAtTarget()
    {
        targetRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);

    }

    IEnumerator RotateAroundTarget(float angle)
    {

        Vector3 vel = Vector3.zero;
        Vector3 targetOffsetPos = Quaternion.Euler(0, angle, 0) * offsetPos;
        float dist = Vector3.Distance(offsetPos, targetOffsetPos);
        smoothRotating = true;

        while (dist > 0.02f)
        {
            offsetPos = Vector3.SmoothDamp(offsetPos, targetOffsetPos, ref vel, smoothSpeed);
            dist = Vector3.Distance(offsetPos, targetOffsetPos);

            yield return null;
        }

        smoothRotating = false;
        offsetPos = targetOffsetPos;

    }


    


}
