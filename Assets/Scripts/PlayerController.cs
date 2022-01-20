using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Vector3 localTransform;
    private float horizontalInput;
    private Rigidbody2D rigidbody2d;
    void Start()
    {
        animator = GetComponent<Animator>();
        localTransform = transform.localScale;
        rigidbody2d = GetComponent<Rigidbody2D>();
        
    }

    
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
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
            rigidbody2d.AddForce(new Vector2(10.0f, 0) * 50.0f *horizontalInput* Time.deltaTime, ForceMode2D.Force);

        }
        else
        {
            animator.SetFloat("speed", 0.0f);
        }
        
        
    }
}
