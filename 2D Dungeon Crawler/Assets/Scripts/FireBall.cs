using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{

    public float speed;
    public Rigidbody2D rigidbodys;
    public float damage;
    public float lifetime = 2f;
    public float manaCost = 10;
    // Start is called before the first frame update
    void Start()
    {
        rigidbodys = GetComponent<Rigidbody2D>();
    }

    public void Create(Vector2 vector, Vector3 direction)
    {
        rigidbodys.velocity = vector.normalized * speed;
        transform.rotation = Quaternion.Euler(direction);
    }
    // Update is called once per frame
    void Update()
    {
        if(lifetime > 0)
        {
            lifetime -= Time.deltaTime;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
