using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArea : Bat
{
    public Collider2D boundary;

    public override void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius
            && boundary.bounds.Contains(target.transform.position))
        {
            
            if (enemyState == EnemyState.idle || enemyState == EnemyState.walk)
            {
                anim.SetBool("attacking", true);
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                changeAnimation(temp - transform.position);
                myRigidbody.MovePosition(temp);
                ChangeState(EnemyState.walk);
            }
            else
            {
                anim.SetBool("attacking", false);
            }       
        }
    }
}
