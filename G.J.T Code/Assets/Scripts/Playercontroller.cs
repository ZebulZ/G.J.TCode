using UnityEngine;

public class Playercontroller : MonoBehaviour

{
    [Header("Game Changing Floats")]

    [SerializeField] private float speed;

    [Header("Required Components")]

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator Anim;

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
        AnimationController();
    }

    //the movement is calculated here
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + Move);
    }

    void AnimationController()
    {
        if (Axis.x == 0 && Axis.y == 0)
        {
            Anim.SetBool("idle", true);
        }
        else
        {
            Anim.SetBool("idle", false);
        }

        Anim.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal"));
        Anim.SetFloat("Vertical", Input.GetAxisRaw("Vertical"));
    }
    
}
