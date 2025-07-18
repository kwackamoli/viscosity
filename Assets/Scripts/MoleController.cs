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
    private float slideSpeed = 5f;

    [SerializeField]
    private float jumpForce = 10f;

    [SerializeField]
    private BoxCollider2D groundTrigger;

    [SerializeField]
    private SpriteRenderer Spriteremder;

    private bool isGrounded;

    private float gravity = -9.81f;

    private bool isSlippery;

    private bool isFacingLeft;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFacingLeft)
        {
            Spriteremder.flipX = true;
        }
        else
        {
            Spriteremder.flipX = false;
        }

        if (!isSlippery)
        { 
            movementForce = 0;
            if (Input.GetKey(walkLeft))
            {
                movementForce += -movementSpeed;
                isFacingLeft = true;
            }
            else if (Input.GetKey(walkRight))
            {
                movementForce += movementSpeed;
                isFacingLeft = false;
            }
            else
            {
                movementForce = 0;
            }
        }

        rigidbody.linearVelocity = new Vector2(movementForce,rigidbody.linearVelocityY);

        if (Input.GetKeyDown(jumpKey1) && isGrounded || Input.GetKeyDown(jumpKey2)  && isGrounded) 
        {
            rigidbody.linearVelocity = new Vector2(rigidbody.linearVelocityX, jumpForce);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Slippery-Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Respawn"))
        {
            killMole();
        }

        if (collision.gameObject.CompareTag("Slippery-Ground"))
        {
            isSlippery = true;

            if (isFacingLeft)
            {
                movementForce += -slideSpeed;
            }
            else
            {
                movementForce += slideSpeed;
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Slippery-Ground"))
        {
            isGrounded = false;
        }

        if (collision.gameObject.CompareTag("Slippery-Ground"))
        {
            isSlippery = false;
        }
    }

    private void killMole()
    {

    }
}
