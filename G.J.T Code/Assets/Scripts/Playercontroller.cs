using System.Collections;
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

    [Header("Do Not Touch")]
    //store the value of the last pressed  key
    public float[] lastPressed = new float[2];

    private void Update()
    {
        //convert the float to recieve the input info
        Axis.x = Input.GetAxisRaw("Horizontal");
        Axis.y = Input.GetAxisRaw("Vertical");

        Axis = Axis.normalized;

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
        //Set the floats to use in the animator
        Anim.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal"));
        Anim.SetFloat("Vertical", Input.GetAxisRaw("Vertical"));

        //if pressing something set the horizontal value into the array
        if (Anim.GetFloat("Horizontal") != 0)
        {
            lastPressed[0] = Anim.GetFloat("Horizontal");
        } // if not pressing anything start the routine
        else
        {
            StartCoroutine(NotPressed(lastPressed, true));
        }
        //if pressing something set the vertical value into the array
        if (Anim.GetFloat("Vertical") != 0)
        {
            lastPressed[1] = Anim.GetFloat("Vertical");
        }// if not pressing anything start the routine
        else
        {
            StartCoroutine(NotPressed(lastPressed, false));
        }
        //if not moving
        if (Axis.x == 0 && Axis.y == 0)
        {//set idle true
                Anim.SetBool("idle", true);                
                //if the horizontal vaue is 1 set bool to idle rigth
                if (lastPressed[0] == 1)
                {
                    Anim.SetBool("IdleRigth", true);
                    Anim.SetBool("idle", false);
                    Anim.SetBool("IdleUp", false);
                    Anim.SetBool("IdleDown", false);
                }
            //if the horizontal vaue is -1 set bool to idle left
                if (lastPressed[0] == -1)
                {
                    Anim.SetBool("IdleLeft", true);
                    Anim.SetBool("idle", false);
                    Anim.SetBool("IdleUp", false);
                    Anim.SetBool("IdleDown", false);
                }
            //if the vertical vaue is 1 set bool to idle up
                if (lastPressed[1] == 1)
                {
                    Anim.SetBool("IdleUp", true);
                    Anim.SetBool("idle", false);
                    Anim.SetBool("IdleLeft", false);
                    Anim.SetBool("IdleRigth", false);
                }
            //if the vertical vaue is -1 set bool to idle down
                if (lastPressed[1] == -1)
                {
                    Anim.SetBool("IdleDown", true);
                    Anim.SetBool("idle", false);
                    Anim.SetBool("IdleLeft", false);
                    Anim.SetBool("IdleRigth", false);
                }
        }
        else
        {//if moving cancell all idles
            Anim.SetBool("IdleUp", false);
            Anim.SetBool("IdleDown", false);
            Anim.SetBool("IdleLeft", false);
            Anim.SetBool("IdleRigth", false);
            Anim.SetBool("idle", false);
        }
        IEnumerator NotPressed(float[] Lastpressed, bool Horizontal)
        {
            //wait untill end of frme to set the last pressed values to 0
            yield return new WaitForEndOfFrame();
            if (Horizontal)
            {
                lastPressed[0] = 0;
            }
            else
            {
                lastPressed[1] = 0;
            }
        }
    }
    
}
