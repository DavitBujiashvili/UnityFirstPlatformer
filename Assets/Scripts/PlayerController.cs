using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed;
    public float JumpSpeed;

    private Animator animator;
    public bool IsGrounded;
    public Transform JumpPoint;
    public float radius;
    public LayerMask Mask;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        IsGrounded=Physics2D.OverlapCircle(JumpPoint.position,radius,Mask);

        if(Input.GetAxisRaw("Horizontal")>0){
            rb.velocity=new Vector3(MoveSpeed,rb.velocity.y,0f); 
        }

        if(Input.GetAxisRaw("Horizontal")<0){
            rb.velocity=new Vector3(-MoveSpeed,rb.velocity.y,0f);
        }

        if(Input.GetAxisRaw("Horizontal")==0){
            rb.velocity=new Vector3(0f,rb.velocity.y,0f);
        }

        if(Input.GetButtonDown("Jump") && IsGrounded){
            rb.velocity=new Vector3(0f,JumpSpeed,0f);
        }
        animator.SetInteger("speed",(int)Mathf.Abs(rb.velocity.x));
        animator.SetBool("isGrounded",IsGrounded);
        
    }
}
