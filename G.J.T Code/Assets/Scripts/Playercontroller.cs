using UnityEngine;

public class Playercontroller : MonoBehaviour

{
    [Header("GameChangingFloats")]

    [SerializeField] private float speed;
    [SerializeField] private float JumpPower;

    [Header("Requirements")]

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform HitPoint;

    [Header("Bools")]

    public bool Grounded = false;

    //the movement is calculated here
    void FixedUpdate()
    {
        //Simple Movement
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(1 * speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-1 * speed * Time.deltaTime, 0, 0);
        }
        //Trow ray towards the ground
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(HitPoint.position.x, HitPoint.position.y), -Vector2.up);
        //if hit something
        if (hit)
        {
            //get distance of the ground
            float distance = Mathf.Abs(hit.point.y - transform.position.y);

            //if touching the ground (meanning that the ray is 2.9 units or less long, this may vary) Grounded = true if not Grounded = false
            if (distance < 2.9)
            {
                Grounded = true;
            }
            else
            {
                Grounded = false;
            }
        }
        //if press W and touching the floor 
        if (Input.GetKey(KeyCode.W) && Grounded)
        {
            //Add 2d force up
            Vector2 Jump = new Vector2(0, 50 * JumpPower);
            rb.AddForce(Jump);
        }
    }
}
