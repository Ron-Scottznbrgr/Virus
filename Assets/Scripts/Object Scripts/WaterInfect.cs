using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class WaterInfect : NetworkBehaviour
{

    public Material ActualMaterial;

   [SyncVar] public Color baseColor;
    [SyncVar] public Color targetColor;
    [SyncVar] public Color lerpColor;

    [ColorUsage(true, true)]
    [SyncVar] public Color baseHDR;
    [ColorUsage(true, true)]
    [SyncVar] public Color targetHDR;
    [ColorUsage(true, true)]
    [SyncVar] public Color lerpHDR;

    [SyncVar] public bool isContagious;
    [SyncVar] public float virusTimer;
    [SyncVar] public bool isPureWater=true;
    [SyncVar] public bool activated = false;



    [SyncVar] public float cleanseTime;
    [SyncVar] public float timeActivated;
   // [SyncVar] public float defaultTime;
    [SyncVar] public float timePassed;
    [SyncVar] public float dirtySpeed;
    [SyncVar] public float cleanSpeed;
   // [SyncVar] public int MAXGLOW;
    

   
    public Renderer waterRend;


    // Start is called before the first frame update
    void Start()
    {
        waterRend.material = ActualMaterial;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        
        

        if (virusTimer > 0)
        {
            virusTimer -= Time.deltaTime;
        }

        if (virusTimer <= 0 && isContagious == true)
        {
            activated = true;
            isContagious = false;
          //  ActivateGLOW(0);
            
        }


        if (activated && isContagious == false && isPureWater == true)
        {
            /*
             * if recontaminated == 1 {
             * interuptedColor=lerpColor
             * set recontaminated = 2;
             * }
             */


            // timeActivated -= Time.deltaTime;
            //.Lerp(transform.position, originalPosition, moveSpeed * Time.deltaTime);
            //Material.Base


            timePassed += (dirtySpeed * Time.deltaTime);
            
            
            //if Recontaminate == 0; //clean to dirty
            lerpColor = Color.Lerp(baseColor, targetColor, timePassed);

            //if Recontaminate ==2; //not clean to dirty
            //lerpColor = Color.Lerp(interuptedColor, targetColor, timePassed);

            lerpHDR = (Vector4)Color.Lerp(baseHDR, targetHDR, timePassed);


            
            ChangeWater(lerpColor, lerpHDR);
            
            

            // waterRend.material.SetColor("Color_557CDFE8", lerpColor);
            // waterRend.material.SetVector("Color_89854505", (Vector4)lerpHDR);

            //water.SetColor("Color_557CDFE8", lerpColor);

            if (timePassed >= 1)
            {
                activated = false;
                isContagious = true;
                timePassed = 0;
                virusTimer = cleanseTime;
                isPureWater = false;
               // ActivateGLOW(MAXGLOW);
            }
        }




        if (activated && isContagious == false && isPureWater == false)
        {
            // timeActivated -= Time.deltaTime;
            //.Lerp(transform.position, originalPosition, moveSpeed * Time.deltaTime);
            //Material.Base
            

            timePassed += (cleanSpeed * Time.deltaTime);
            lerpColor = Color.Lerp(targetColor, baseColor, timePassed);
            lerpHDR = (Vector4)Color.Lerp(targetHDR, baseHDR, timePassed);


            //waterRend.material.SetColor("Color_557CDFE8", lerpColor);
            //waterRend.material.SetVector("Color_89854505", (Vector4)lerpHDR);

            //water.SetColor("Color_557CDFE8", lerpColor);

            //waterRend.material.SetColor("Color_557CDFE8", lerpColor);
            // waterRend.material.SetVector("Color_89854505", (Vector4)lerpHDR);


            ChangeWater(lerpColor, lerpHDR);

            if (timePassed >= 1)
            {
                activated = false;
                timePassed = 0;
                isPureWater = true;
            }

        }

        









    }

    /*
    public void PushContagious(bool contagious)
    {
        isContagious = contagious;

    }
    */
   

    public void ResetTimer()
    {
        virusTimer = cleanseTime;

    }

  
    void ChangeWater(Color baseLerp, Vector4 HDRLerp)
    {
        waterRend.material.SetColor("Color_557CDFE8", baseLerp);
        
        waterRend.material.SetVector("Color_89854505", HDRLerp);
    }

   /* void ActivateGLOW(int glow)
    {
        waterRend.material.SetInt("Vector1_6E73C828", glow);
    }*/

}
