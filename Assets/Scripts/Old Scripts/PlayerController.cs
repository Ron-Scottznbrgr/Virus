using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// 8 Directional movement, locked to 45*
/// Stops and faces current direct when no input
/// Taken from https://www.youtube.com/watch?v=cVy-NTjqZR8&list=WL&index=18
/// </summary>


public class PlayerController : MonoBehaviour
{
    public float velocity = 5f;
    public float turnspeed = 10f;
    public CharacterController controller;

    Vector2 input;
    float angle;

    Quaternion targetRotation;
    //Transform cam;

    private void Start()
    {
        //cam = Camera.main.transform;
    }

    private void Update()
    {
        GetInput();

        if (Mathf.Abs(input.x) <1 && Mathf.Abs(input.y)<1) return;

       // CalculateDirection();
       // Rotate();
        Move();



    }

    void GetInput()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
    }


   /* void CalculateDirection()
    {
        angle = Mathf.Atan2(input.x, input.y);
        angle = Mathf.Rad2Deg * angle;
        angle += cam.eulerAngles.y;     //    ¯\_(ツ)_/¯


    }


    void Rotate()
    {
        targetRotation = Quaternion.Euler(0, angle, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation,targetRotation, turnspeed*Time.deltaTime);
    }

    */


    void Move()
    {
        //transform.position += transform.forward * velocity * Time.deltaTime;
        //controller.Move(transform.forward * velocity * Time.deltaTime);
        transform.position = transform.forward* velocity *Time.deltaTime;
    }

}
