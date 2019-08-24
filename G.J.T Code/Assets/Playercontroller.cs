using UnityEngine;

public class Playercontroller : MonoBehaviour

{
    [SerializeField] private float speed;
    [SerializeField] private float JumpPower;
    [SerializeField] private Rigidbody2D rb;
    public bool Grounded = false;
    [SerializeField] private Transform HitPoint;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(1 * speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-1 * speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.W) && Grounded)
        {
            Vector2 Jump = new Vector2(0, 50 * JumpPower);
            rb.AddForce(Jump);
        }
    }
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(HitPoint.position.x, HitPoint.position.y), -Vector2.up);
        if (hit)
        {
            float distance = Mathf.Abs(hit.point.y - transform.position.y);

            if (distance < 2.9)
            {
                Grounded = true;
            }
            else
            {
                Grounded = false;
            }
        }
    }
}
