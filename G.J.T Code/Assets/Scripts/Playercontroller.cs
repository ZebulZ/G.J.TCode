using UnityEngine;

public class Playercontroller : MonoBehaviour

{
    [Header("Game Changing Floats")]

    [SerializeField] private float speed;

    [Header("Required Components")]

    [SerializeField] private Rigidbody2D rb;

    [Header("Additional Stuff")]
    public Vector2 Move;
    public Vector2 Axis;

    private void Update()
    {
        //convert the float to recieve the input info
        Axis.x = Input.GetAxisRaw("Horizontal");
        Axis.y = Input.GetAxisRaw("Vertical");

        //Get final summed movement
        Move = (Axis * speed * Time.fixedDeltaTime);
    }

    //the movement is calculated here
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + Move);
    }
}
