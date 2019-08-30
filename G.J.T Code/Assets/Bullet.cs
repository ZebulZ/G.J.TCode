using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float LifeTime = 2;
    [SerializeField] private float Damage;
    [SerializeField] private Animator Anim;
    private bool CanMove = true;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, LifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyHealth>().RecieveDmg(Damage);
        }
        if (!collision.CompareTag("Item"))
        {
            Anim.SetBool("HitSomething", true);
            CanMove = false;
            StartCoroutine(WaitForAnimation());
        }
    }
    void Update()
    {
        if (CanMove)
        {
            rb.velocity = transform.right * Speed;
        }
        else
        {
            rb.velocity = new Vector2(0,0);
        }
    }

    IEnumerator WaitForAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
