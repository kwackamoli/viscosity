using UnityEngine;

public class MoleController : MonoBehaviour
{
    [SerializeField]
    private KeyCode walk_left = KeyCode.A;

    [SerializeField]
    private KeyCode walk_right = KeyCode.D;

    [SerializeField]
    private Rigidbody2D rigidbody;

    private float movementforce = 0;

    [SerializeField]
    private float movementspeed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movementforce = 0;
        if (Input.GetKey(walk_left))
        {
            movementforce += -movementspeed;
        }
        else if (Input.GetKey(walk_right))
        {
            movementforce += movementspeed;
        }
        else
        {
            movementforce = 0;
        }

        rigidbody.linearVelocity = new Vector2(movementforce,0);
    }
}
