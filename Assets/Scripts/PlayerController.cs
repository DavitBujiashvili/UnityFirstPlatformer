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

    private Vector3 respawnPoint;

    private LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
        respawnPoint=gameObject.transform.position;
        levelManager=FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        IsGrounded=Physics2D.OverlapCircle(JumpPoint.position,radius,Mask);

        if(Input.GetAxisRaw("Horizontal")>0){
            rb.velocity=new Vector3(MoveSpeed,rb.velocity.y,0f); 
            transform.localScale=Vector3.one;
        }

        if(Input.GetAxisRaw("Horizontal")<0){
            rb.velocity=new Vector3(-MoveSpeed,rb.velocity.y,0f);
            transform.localScale=new Vector3(-1f,1f,1f);
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

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="KillPlane"){
            gameObject.SetActive(false);
            levelManager.Respawn();
        }

         if(other.tag=="Hurtable"){
            gameObject.SetActive(false);
            levelManager.Respawn();
        }

        if(other.tag=="ChekPoint"){
            respawnPoint=other.transform.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag=="MovingPlatform"){
            gameObject.transform.parent=other.transform;
        }
    }

     private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.tag=="MovingPlatform"){
            gameObject.transform.parent=null;
        }
    }

    public void Respawn(){
        gameObject.SetActive(true);
        gameObject.transform.position=respawnPoint;
    }
}
