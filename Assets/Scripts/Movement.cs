using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    float jumpPressedRememberTimer;
    [Header("Button Settings")]
    [Tooltip("Jump Buffer Leniency")]
    public float jumpPressedRememberTime;
    [Tooltip("Coyote Time Leniency")]
    public float groundedRememberTime;
    float groundedRememberTimer;

    [Range(0f, 1f)]
    [Tooltip("Factor of how much a jump height should be cut based off of letting go of space")]
    public float cutJumpHeightFactor;
    [Tooltip("Leniency distance for what counts as on the ground.")]
    public float distance;
    public LayerMask mask;
    public float JumpForce;
    public float MaxAerialJumps;
    float doubleJumpsLeft;

    //Movement
    public float speed;
    float moveVelocity;
    bool hasDoubleJumped;
    [Tooltip("True=you can do X consecutive in air jumps, False=you can do X double jumps")]
    public bool allowConsecutiveAerialJumps;
    
    string originalText;
    public TextMeshProUGUI jumpsLeft;

    //Collision Audio
    public AudioSource CollisionSFX; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        doubleJumpsLeft = MaxAerialJumps;
        hasDoubleJumped = false;
        originalText = jumpsLeft.text;
        jumpsLeft.text = jumpsLeft.text + " " + MaxAerialJumps;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitGround;
        hitGround = Physics2D.Raycast(transform.position, Vector3.down, distance + rb.GetComponent<CapsuleCollider2D>().size.y/2, mask);
        //grounded buffer
        groundedRememberTimer -= Time.deltaTime;
        if (hitGround.collider != null) //hit ground
        {
            groundedRememberTimer = groundedRememberTime;
            hasDoubleJumped = false;
        }
        //code for buffering jump
        jumpPressedRememberTimer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
            jumpPressedRememberTimer = jumpPressedRememberTime;

        //jump
        if (groundedRememberTimer > 0 && jumpPressedRememberTimer > 0)
        {
            jumpPressedRememberTimer = 0;
            groundedRememberTimer = 0;
            //rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            rb.velocity = new Vector3(rb.velocity.x, JumpForce);
        }
        //double jump
        if (allowConsecutiveAerialJumps)
        {
            if (Input.GetKeyDown(KeyCode.Space) && doubleJumpsLeft > 0 && hitGround.collider == null)
            {
                DoubleJump();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && doubleJumpsLeft > 0 && hitGround.collider == null && !hasDoubleJumped)
            {
                DoubleJump();
            }
        }
      
        //user can jump more or less depending on how long they press 
        if (Input.GetKeyUp(KeyCode.Space)&&!hasDoubleJumped)
        {
            if (rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * cutJumpHeightFactor);
            }
        }
        //can implement acceleration left and right later if wanted
        moveVelocity = 0;
        //Left Right Movement
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            moveVelocity += -speed;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            moveVelocity += speed;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
    }

    void DoubleJump()
    {
        doubleJumpsLeft--;
        rb.velocity = new Vector3(rb.velocity.x, JumpForce);
        hasDoubleJumped = true;
        jumpsLeft.text = originalText + " " + doubleJumpsLeft;
    }

//Collision Event for Collision sound effect
public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "CollisionTag")
        {
            CollisionSFX.Play();
        }
    }

}

