using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState {
    idle,
    walk,
    attack,
    stagger
}

public class Enemy : MonoBehaviour
{
    public EnemyState enemyState;
    public int health;
    public string enemyName;
    public int attackDamage;
    public float speed;
    public Animator anima;
    public LootTable lootTable;
    public GameObject doorway;

    public IEnumerator Dead()
    {
        if (enemyName != "fakeBat")
        anima.SetBool("Dead", true);
        yield return new WaitForSeconds(0.5f);
        MakeLoot();
        this.gameObject.SetActive(false);     
    }

    private void MakeLoot()
    {
        if(lootTable != null)
        {
            Loot current = lootTable.LootDrop();
            if(current != null)
            {
                Instantiate(current.item, transform.position, Quaternion.identity);
            }
            if(enemyName == "Boss")
            {
                Instantiate(doorway, transform.position, Quaternion.identity);
            }
        }
    }

    public void TakeDamage(float damage)
    {
        health -= (int)damage;
        if(health <= 0)
        {
            StartCoroutine(Dead());       
        }
    }
    public void Knock(Rigidbody2D rigidbody, float knockTime, float damage)
    {
        StartCoroutine(KnockCo(rigidbody, knockTime));
        TakeDamage(damage);
    }

    private IEnumerator KnockCo(Rigidbody2D enemy, float knockTime)
    {
        if (enemy != null)
        {
            yield return new WaitForSeconds(knockTime);
            enemy.velocity = Vector2.zero;
            enemyState = EnemyState.idle;
            enemy.velocity = Vector2.zero;
        }
    }
}
