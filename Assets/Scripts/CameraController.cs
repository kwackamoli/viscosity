using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(0, Player.transform.position.y, -10);
    }
}
