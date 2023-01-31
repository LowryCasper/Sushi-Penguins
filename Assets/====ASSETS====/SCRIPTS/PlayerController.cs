using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class PlayerController : MonoBehaviour
{
  
    Rigidbody2D rb;
    public float jumpPower = 9;
    public GameObject player;
    public Transform groundCheck;
    public LayerMask groundLayer;
    bool isGrounded;

    public float speed = 5.0f;
    private float horizontalInput;
    private float verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Jump( jumpPower);
        MobileTouch();
        MouseTouch();

        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector2.right * Time.deltaTime * speed * horizontalInput);
        // transform.Translate(Vector2.left * Time.deltaTime * speed * horizontalInput);

        if (Input.GetKeyDown(KeyCode.D))
        {
          player.transform.parent = null;
        }
    }

    public void Jump(float jumpPower)
    {
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(6.8f, 0.68f), CapsuleDirection2D.Horizontal, 0, groundLayer);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }

    public void MobileTouch()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }

    public void MouseTouch()
    {
        if (Input.GetMouseButton(0) )
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);

            Debug.Log("MouseClick");
        }
    }
}