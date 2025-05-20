//remove the first 2 rows
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody2D rigidbody; //reference to the rigidbody

    private float moveX; //horizontal movement

    private Vector2 movement;

    public float MoveSpeed = 5f;

    public float JumpForce = 10f; //power of the jump

    public LayerMask GroundLayer;

    public BoxCollider2D GroundCollider; //detects when the plyaer touches the ground

    public bool OnGround; //is the plyaer on the ground

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        OnGround = true; //on the ground
    }

    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal"); //horizontal movement
        if(Input.GetKeyDown(KeyCode.Space) && OnGround) //press the space button
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, JumpForce); //the player jumps
            OnGround = false; //not on the ground
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (GroundLayer == (1 << other.gameObject.layer)) //if the object is on the ground layer
        {
            OnGround = true; 
        }
    }

    void FixedUpdate() //affects the physics
    {
        movement = new Vector2(moveX * MoveSpeed, rigidbody.velocity.y); //vertical speed remains the same
        rigidbody.velocity = movement; //velocity based on movement
    }
}
