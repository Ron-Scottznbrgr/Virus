using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform targetPlayer;
    public Vector3 cameraOffset;
        
        // Update is called once per frame
    void Update()
    {
        transform.position = targetPlayer.position+cameraOffset;
    }
}
