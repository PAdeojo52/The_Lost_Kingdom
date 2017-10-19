using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    public GameObject player;
    public float speed;
    public float jumpSpeed;
    public bool isGrounded = false;
    public Vector2 up;
    public UnityEngine.Transform playerTransform;
    public float angle;
    public Vector2 position;
    public Vector2 velocity;
    public Vector2 vertAccelertaion;
    public Vector2 horAccelertaion;
    public float limit;
    public float JumpSpeed;
    public bool isJumping;


    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        playerTransform = player.GetComponent<UnityEngine.Transform>().transform;
        rb = GetComponent<Rigidbody2D>();
        vertAccelertaion = new Vector2(0, 0);
        horAccelertaion = new Vector2(0, 0);
        velocity = new Vector2(0, 0);


        //angle = playerTransform.
    }

    // Update is called once per frame
    void Update()
    {

    }


    void FixedUpdate()
    {
        playerTransform = player.GetComponent<UnityEngine.Transform>().transform;
        position = playerTransform.position;
        //velocity = rb.velocity;
        bool moveRight = Input.GetKey(KeyCode.D);
        bool moveLeft = Input.GetKey(KeyCode.A);
        //float moveVertical = Input.GetAxis("Vertical") * Time.deltaTime * 150.0f;

        //Vector2 move = new Vector2(moveHorizontal, 6);
        //Vector2 movement = new Vector2(moveHorizontal, 0);
        if (moveRight)
        {
            vertAccelertaion.x = speed;
        }
        else if (moveLeft)
        {
            vertAccelertaion.x = -speed ;
        }
        else
        {
            if(velocity.x!=0)
            {
                velocity.x = 0;
            }
        }

        velocity = velocity + (vertAccelertaion * Time.fixedDeltaTime);

        if (velocity.magnitude >= limit)
        {
            velocity.Normalize();
            velocity.Set(velocity.x * limit, velocity.y * limit);
        }

        rb.MovePosition(rb.position + velocity );

       


        /*if (moveLeft)
        {
            accelertaion.x = accelertaion.x - (speed * 20);
        }
        else
        {
            accelertaion.x = 0;
        }*/

        //accelertaion.y = accelertaion.y + (speed * movement.y);



        /*velocity = velocity + accelertaion;
        if (velocity.x > 30)
        {
            //rb.velocity.Normalize();
            velocity.x = 30;
        }*/

        //position = position + velocity;
        //rb.velocity.Set(velocity.x,0);
        //rb.
        // position = position + velocity;
        //rb.position.Set(position.x, position.y);
        //playerTransform.position = position;


        isJumping = Input.GetKey(KeyCode.Space);
        //if (isJumping)

        if (isGrounded)
        {
            Debug.Log("true");
            if (isJumping)
            {

                horAccelertaion.y = horAccelertaion.y + ( jumpSpeed * Time.fixedDeltaTime);
                Debug.Log("jump");
                rb.MovePosition(rb.position + horAccelertaion);
                //rb.AddForce(horAccelertaion);
                //Jump();
                //rb.velocity = new Vec;

            }


        }
       

        vertAccelertaion.x = 0;
        vertAccelertaion.y = 0;
        horAccelertaion.x = 0;
        horAccelertaion.y = 0;
        up.y = 0;
        up.x = 0;
        //velocity.x = 0;
        //Debug.Log();
    }

    void Jump()
    {
        //up.y = up.y + jumpSpeed * 2;
        //rb.MovePosition(rb.position + horAccelertaion);
        
    }


    void OnCollisionEnter2D(Collision2D theCollision)
    {
        if (theCollision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }

    }
    void OnCollisionExit2D(Collision2D theCollision)
    {
        if (theCollision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
