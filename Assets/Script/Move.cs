using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    public int flag = 1;
    Rigidbody2D rb;
    private bool isGrounded = false;
    public float jumpForce = 1.0F;
    public bool isLookingLeft;
    private float x;
    private Animation anim;
    public Animator charAnimator;

    private SpriteRenderer sprite;
    public Quaternion rotation = Quaternion.identity;

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animation>();
        charAnimator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        GlobalSetting.Speed = speed;

    }
    private void Start()
    {
       // transform.GetChild(0).transform.SetParent(null);
    }
    private void FixedUpdate()
    {
        speed = GlobalSetting.Speed;
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            isGrounded = false;
            Jump();
            charAnimator.SetInteger("Run", 2);
        }
        if (Input.GetButton("Horizontal"))
        {
            Run();
            if (isGrounded == true)
                charAnimator.SetInteger("Run", 1);
   
                ;
        }
        else
        {
            if (isGrounded == true)
                charAnimator.SetInteger("Run", 0);
 
                ;
        }





        if (x < 0 && !isLookingLeft)
            TurnTheRat();
        if (x > 0 && isLookingLeft)
            TurnTheRat();
    }
    private void Jump()
    {
        flag++;
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }
    private void Run()
    {
        
        x = Input.GetAxis("Horizontal");
        Vector3 move = new Vector3(x * speed, rb.velocity.y, 0f);
        rb.velocity = move;
      
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
        charAnimator.SetInteger("Run", 0);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }

    void TurnTheRat()
    {
        isLookingLeft = !isLookingLeft;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y-180, transform.eulerAngles.z);
    }

}
