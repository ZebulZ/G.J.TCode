using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float LifeTime = 2;
    [SerializeField] private float Damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyHealth>().RecieveDmg(Damage);
        }
    }

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, LifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.right * Speed;

    }
}
