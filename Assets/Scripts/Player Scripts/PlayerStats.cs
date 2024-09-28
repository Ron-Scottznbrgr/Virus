using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerStats : NetworkBehaviour
{
    [SyncVar] public bool isInfected = false;
    [SyncVar] public bool isContagious = false;
    [SyncVar] public bool isHiding = false;
    [SyncVar] public string playerName = "player_name";

    [SyncVar] public Vector3 previousPosition;

    public Renderer SkinRender;


    public Material VirusMaterial;
    public Material DefaultSkin;
    public ParticleSystem particleFlames;
    private bool flamesOn = false;
    public Material[] Skins;



    // Start is called before the first frame update
    void Start()
    {
        //int num = random.Next();
        int num = Random.Range(0, 5);


        switch (num)
        {
            case 5:


                SkinRender.material = Skins[num];
                break;
            case 4:
                SkinRender.material = Skins[num];
                break;
            case 3:
                SkinRender.material = Skins[num];
                break;
            case 2:
                SkinRender.material = Skins[num];
                break;
            case 1:
                SkinRender.material = Skins[num];
                break;
            case 0:
                SkinRender.material = Skins[num];
                break;
        }
        //default:






        DefaultSkin = SkinRender.material;
        //particleFlames = GetComponentInChildren<ParticleSystem>();
        //particleFlames.emission.enabled = true;
        particleFlames.Stop();


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("x") && isInfected == false)
        {
            isInfected = true;
        }
        if (Input.GetKey("b") && isInfected == true)
        {
            isInfected = false;
        }


        
            if (isInfected == true && isHiding == false && flamesOn == false)
            {
                SkinRender.material = VirusMaterial;
                // GetComponent<Renderer>().material = VirusMaterial;
                particleFlames.Play();
                flamesOn = true;
            if (isLocalPlayer)
            {
                StartFlames();
            }
            
            }

            if (isInfected == true && isHiding == true && flamesOn == true)
            {
                SkinRender.material = VirusMaterial;
                // GetComponent<Renderer>().material = VirusMaterial;
                particleFlames.Stop();
                flamesOn = false;
            if (isLocalPlayer)
            {
                StopFlames();
            }


                // flamesChange = true;
            }
        

        /*
                if (isInfected == true && flamesChange == false && isHiding == false)
                {
                    SkinRender.material = VirusMaterial;
                    // GetComponent<Renderer>().material = VirusMaterial;
                    particleFlames.Play();
                    flamesChange = true;
                }

                if (isInfected == true && flamesChange == false && isHiding == true)
                {
                    SkinRender.material = VirusMaterial;
                    particleFlames.Stop();
                    flamesChange = false;
                }

                if (isInfected == false && flamesChange == true)
                {
                    SkinRender.material = DefaultSkin;
                    particleFlames.Stop();
                    flamesChange = false;
                }
        */



    }

 [Command]
    public void ActivateVirus()
        {
        SkinRender.material = VirusMaterial;
        isInfected = true;
        isContagious = true;

        }

    [Command]
    public void StartFlames()
    {
        SkinRender.material = VirusMaterial;
        particleFlames.Play();
    }

    [Command]
    public void StopFlames()
    {
        particleFlames.Stop();
    }



}


