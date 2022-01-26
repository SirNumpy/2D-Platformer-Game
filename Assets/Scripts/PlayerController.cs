using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Vector3 localTransform;
    private Rigidbody2D rigidbody2d;
    public float speed;
    private Vector3 position;
    public Groundcheck groundcheck;
    public BoxCollider2D crouchcollider;
    public CapsuleCollider2D idleCollider;
    //private bool iscrouch=false;
    private bool isJump = false;
    public float jumpforce;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        crouchcollider = GetComponent<BoxCollider2D>();
        idleCollider = GetComponent<CapsuleCollider2D>();
    }

    void Start()
    {
        localTransform = transform.localScale;
        position = transform.position;
        crouchcollider.enabled = false;

    }

    
    void Update()
    {


        //horizontal movement and flipping
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
        {
            
            if (horizontalInput > 0)
            {
                localTransform.x = Mathf.Abs(transform.localScale.x);
                
            }
            else if (horizontalInput < 0)
            {
                localTransform.x = -1 * (Mathf.Abs(transform.localScale.x));
                
            }
            animator.SetFloat("speed", 0.8f);
            transform.localScale = localTransform;
            position = new Vector3( position.x+speed * Time.deltaTime*horizontalInput,transform.position.y,0);
            transform.position = position;

        }
        else
        {
            animator.SetFloat("speed", 0.0f);
        }
        //vertical movement
        if (Input.GetKeyDown(KeyCode.Space)&& groundcheck.isGrounded==true)
        {
            animator.SetBool("isJump", true);
            isJump = true;
            
        }
        

        




        //crouch working
        if (Input.GetKey(KeyCode.C))
        {
            animator.SetBool("isCrouch", true);
            crouchcollider.enabled = true;
            idleCollider.enabled = false;
        }
        else
        {
            animator.SetBool("isCrouch", false);
            crouchcollider.enabled = false;
            idleCollider.enabled = true;

        }
       
        
        
    }
    private void FixedUpdate()
    {
        if (isJump == true)
        {
            rigidbody2d.AddForce(Vector2.up * jumpforce * Time.deltaTime, ForceMode2D.Impulse);
            groundcheck.isGrounded = false;
            isJump = false;
            animator.SetBool("isJump", false);

        }
    }


}
