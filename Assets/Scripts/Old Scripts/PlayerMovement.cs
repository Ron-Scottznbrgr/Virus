using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody targetRigid;
    public float forwardForce = 2000f;
    public float sideForce = 500f;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Herrow");

        //targetRigid.useGravity = false;
        //targetRigid.AddForce(0, 200, 500);

    }

    // Update is called once per frame
    void Update()
    { 
       // targetRigid.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("d"))
        {
            targetRigid.AddForce(sideForce*Time.deltaTime, 0, 0);
        }

        if (Input.GetKey("a"))
        {
            targetRigid.AddForce(-sideForce * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey("w"))
        {
            targetRigid.AddForce(0,0,sideForce * Time.deltaTime);
        }

        if (Input.GetKey("s"))
        {
            targetRigid.AddForce(0,0,-sideForce * Time.deltaTime);
        }
    }
}
