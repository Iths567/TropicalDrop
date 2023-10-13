using UnityEngine;

public class cameraScript : MonoBehaviour
{
    
    [SerializeField] Transform attachedPlayer;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
        Vector3 playerPOS = attachedPlayer.transform.position;
        Vector3 camPOS = transform.position;
        
        
        if (playerPOS.y < camPOS.y-4)
        {
            Vector3 newcamPOS = new Vector3(transform.position.x, playerPOS.y + 4, transform.position.z);
            transform.position = newcamPOS;
        }

        
        
    }
}
