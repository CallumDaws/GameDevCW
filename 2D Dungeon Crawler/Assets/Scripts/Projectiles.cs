using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public float speed;
    public Vector2 direction;
    public float duration;
    private float counter;
    public Rigidbody2D rigidbodys;
    // Start is called before the first frame update
    void Start()
    {
        rigidbodys = GetComponent<Rigidbody2D>();
        counter = duration;
    }

    // Update is called once per frame
    void Update()
    {
        counter -= Time.deltaTime;
        if(counter <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void Fire(Vector2 startVelo)
    {
        rigidbodys.velocity = startVelo * speed;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
