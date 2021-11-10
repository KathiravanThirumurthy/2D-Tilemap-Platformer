using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rgd;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float speed;
    [SerializeField]
    private bool isGrounded;
    [SerializeField]
    private LayerMask _groundLayer;
    //jump force
    // playeranimaiton handler
    private Playeranimation _playeranim;
    private SpriteRenderer _playerSprite;
    private void Awake()
    {
        // assign handler to playeranimation
        _playeranim = GetComponent<Playeranimation>();
        _playerSprite = GetComponentInChildren<SpriteRenderer>();
        rgd = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        //isGrounded = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        // if hor > 0 faceright
        // else if(hor < 0 ) faceLeft
        if (horizontal > 0)
        {
            flipPlayer(true);
        }else if(horizontal < 0)
        {
            flipPlayer(false);
        }

            



        // space key && grounded true
        // current velocity=new velocity(current x, jumpForce)
        //2D raycast from Player to the ground collider to detect the ground
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded )
        {

            // rgd.velocity = Vector2.up * jumpForce;
            rgd.velocity =new Vector2(rgd.velocity.x,jumpForce);
            isGrounded = false;
        }
        rgd.velocity = new Vector2(horizontal * speed, rgd.velocity.y);
        _playeranim.runPlayer(horizontal);


    }
    private void flipPlayer(bool faceRight)
    {
        if(faceRight == true)
        {
            _playerSprite.flipX = false;
        }
        else if (faceRight == false)
        {
            _playerSprite.flipX = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Ground");
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

   private void isGroundedfn()
    {
        /* RaycastHit2D raycastInfo = Physics2D.Raycast(transform.position, Vector2.down, 1.5f, 1 << 8);
        Debug.DrawRay(transform.position, Vector2.down * 1.5f,Color.green);

        if (raycastInfo.collider != null)
        {
            Debug.Log("hit:" + raycastInfo.collider.name); 
            print("collided");
            isGrounded = true;
        }*/

    }
}
