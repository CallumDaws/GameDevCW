using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowBoss : Enemy
{
    // Start is called before the first frame update
    public Rigidbody2D myRigidbody;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public GameObject shadowBall;
    public float delay;
    private float delaySeconds;
    public bool canFire = true;

    private void Update()
    {
        delaySeconds -= Time.deltaTime;
        if(delaySeconds <= 0)
        {
            canFire = true;
            delaySeconds = delay;
        }
    }

    void Start()
    {
        enemyState = EnemyState.idle;
        target = GameObject.FindWithTag("Player").transform;
        myRigidbody = GetComponent<Rigidbody2D>();
        lootTable = GameObject.FindWithTag("Boss Loot").GetComponent<LootTable>();
    }


    void FixedUpdate()
    {
        CheckDistance();
    }

    public void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            if (enemyState == EnemyState.idle || enemyState == EnemyState.walk)
            {
                if (canFire)
                {
                    Vector3 temp = target.transform.position - transform.position;
                    GameObject current = Instantiate(shadowBall, transform.position, Quaternion.identity);
                    current.GetComponent<Projectiles>().Fire(temp);
                    canFire = false;
                    ChangeState(EnemyState.walk);
                }
            }
            else
            {
                ChangeState(EnemyState.idle);
            }
        }
    }

    public void ChangeState(EnemyState newState)
    {
        if (enemyState != newState)
        {
            enemyState = newState;
        }
    }
}
