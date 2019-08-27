using UnityEngine;

public class Bullet : MonoBehaviour
{
    // [SerializeField] private float Damage;
    [SerializeField] private float Speed;
    [SerializeField] private Vector2 Direction;
    [SerializeField] private float LifeTime = 2;

    private void OnEnable()
    {
        Direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Destroy(gameObject, LifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Direction * Time.fixedDeltaTime * Speed);
    }
}
