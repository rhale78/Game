using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector2 Direction;
    public float Speed;
    public bool IsMoving;

    public Animator Animator;
    public Rigidbody2D Rigidbody2D;
    //protected Transform Cam;

    protected bool DidCollide;

    private void Start()
    {
        Input.ResetInputAxes();
    }

    private void Awake()
    {
        Animator = GetComponent<Animator>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
        //Cam = Camera.main.transform;
        
    }

    void Update()
    {
        IsMoving = false;
        float horizontal =  Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        float drift = 0.5f;
        if (horizontal < -drift)
        {
            Direction = Vector2.left;
            //transform.Translate(Direction * Time.deltaTime * Speed);
            //Rigidbody2D.velocity = new Vector2(horizontal*Speed, Rigidbody2D.velocity.y);
            Rigidbody2D.velocity = new Vector2(horizontal * Speed, 0);
            IsMoving = true;
        }
        else if (horizontal > drift)
        {
            Direction = Vector2.right;
            //transform.Translate(Direction * Time.deltaTime * Speed);
            //Rigidbody2D.velocity = new Vector2(horizontal*Speed, Rigidbody2D.velocity.y);
            Rigidbody2D.velocity = new Vector2(horizontal * Speed, 0);
            IsMoving = true;
        }
        else if (vertical < -drift)
        {
            Direction = Vector2.down;
            //transform.Translate(Direction * Time.deltaTime * Speed);
            //Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x, vertical*Speed);
            Rigidbody2D.velocity = new Vector2(0, vertical * Speed);
            IsMoving = true;
        }
        else if (vertical > drift)
        {
            Direction = Vector2.up;
            //transform.Translate(Direction * Time.deltaTime * Speed);
            //Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x, vertical*Speed);
            Rigidbody2D.velocity = new Vector2(0, vertical * Speed);
            IsMoving = true;
        }
        else
        {
            Rigidbody2D.velocity = new Vector2(0f, 0f);
        }

        //if(Rigidbody2D.velocity.x!=0f||Rigidbody2D.velocity.y!=0f)
        //{
        //    IsMoving = true;
        //}

        if (!DidCollide&&IsMoving)
        {
            //Cam.transform.Translate(Direction * Time.deltaTime * Speed);
        }

        Animator.SetBool("IsMoving", IsMoving);
        Animator.SetFloat("X", Direction.x);
        Animator.SetFloat("Y", Direction.y);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        DidCollide = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        DidCollide = false;
    }
}
