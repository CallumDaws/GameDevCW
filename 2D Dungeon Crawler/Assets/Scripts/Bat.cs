using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : Enemy
{
    // Start is called before the first frame update
    public Rigidbody2D myRigidbody;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Animator anim;
    void Start()
    {
        enemyState = EnemyState.idle;
        target = GameObject.FindWithTag("Player").transform;
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        lootTable = GameObject.FindWithTag("Mob Loot").GetComponent<LootTable>();
    }


    void FixedUpdate()
    {
        CheckDistance();
    }

    public virtual void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            if (enemyState == EnemyState.idle || enemyState == EnemyState.walk)
            {
                if(name == "Bat") 
                anim.SetBool("attacking", true);
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                changeAnimation(temp - transform.position);
                myRigidbody.MovePosition(temp);
                ChangeState(EnemyState.walk);
            }
            else
            {
                if (name == "Bat")
                    anim.SetBool("attacking", false);
            }
        }
    }

    public void setAnimationFloat(Vector2 setVector)
    {
        if (name == "Bat")
            anim.SetFloat("moveX", setVector.x);
        if (name == "Bat")
            anim.SetFloat("moveY", setVector.y);
    }

    public void changeAnimation(Vector2 direction)
    {
        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if(direction.x > 0)
            {
                setAnimationFloat(Vector2.right);
            }
            else if (direction.x < 0)
            {
                setAnimationFloat(Vector2.left);
            }
        }
        else if(Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if (direction.y < 0)
            {
                setAnimationFloat(Vector2.up);
            }
            else if (direction.y > 0)
            {
                setAnimationFloat(Vector2.down);
            }
        }
    }
    public void ChangeState(EnemyState newState)
    {
        if(enemyState != newState)
        {
            enemyState = newState;
        }
    }
}
