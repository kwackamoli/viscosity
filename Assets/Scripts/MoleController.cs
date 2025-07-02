using UnityEngine;

public class MoleController : MonoBehaviour
{
    [SerializeField]
    private KeyCode walkLeft = KeyCode.A;

    [SerializeField]
    private KeyCode walkRight = KeyCode.D;

    [SerializeField]
    private KeyCode jumpKey1 = KeyCode.W;

    [SerializeField]
    private KeyCode jumpKey2 = KeyCode.Space;

    [SerializeField]
    private Rigidbody2D rigidbody;

    private float movementForce = 0;

    [SerializeField]
    private float movementSpeed = 10f;

    [SerializeField]
    private float jumpForce = 10f;

    [SerializeField]
    private BoxCollider2D groundTrigger;

    private bool isGrounded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movementForce = 0;
        if (Input.GetKey(walkLeft))
        {
            movementForce += -movementSpeed;
        }
        else if (Input.GetKey(walkRight))
        {
            movementForce += movementSpeed;
        }
        else
        {
            movementForce = 0;
        }

        rigidbody.linearVelocity = new Vector2(movementForce,rigidbody.linearVelocityY);

        if (Input.GetKey(jumpKey1) && isGrounded || Input.GetKey(jumpKey2)  && isGrounded) 
        {
            rigidbody.linearVelocity = new Vector2(rigidbody.linearVelocityX, jumpForce);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
