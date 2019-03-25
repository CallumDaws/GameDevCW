using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState {
    idle,
    walk,
    attack,
    interact,
    stagger
}

public class Player : MonoBehaviour
{
    float speed = 5;
    private Rigidbody2D rigidbodys;
    public PlayerState currentState;
    private Vector3 change;
    public Animator animator;
    public Animator cameraAnimator;
    public int health;
    public int mana;
    public float manaFloat;
    private Vector3 direction;
    public Inventory playerInventory;
    public SpriteRenderer itemSprite;
    public GameObject projectile;
    public FireBall fireBall;
    public Item wand;

    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.walk;
       animator = gameObject.GetComponent<Animator>();
        rigidbodys = GetComponent<Rigidbody2D>();
        manaFloat = 100;
    }

    private IEnumerator screenKick()
    {
        cameraAnimator.SetBool("kick bool", true);
        yield return new WaitForSeconds(0.6f);
        cameraAnimator.SetBool("kick bool", false);
    }
    private void TakeDamage(float damage)
    {
        health -= (int)damage;
        StartCoroutine(screenKick());
        if (health <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (manaFloat < 100)
        {
            manaFloat = manaFloat += Time.deltaTime;
        }
        mana = (int)manaFloat;

        if (Input.GetButtonDown("Use") && playerInventory.HealthPots > 0 && health <= 100)
        {
            health += 10;
            playerInventory.HealthPots -= 1;
        }

        if(currentState == PlayerState.interact)
        {
            return;
        }
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"),0);
        direction = input.normalized;
        Vector3 velocity = direction * speed;
        Vector3 moveAmount = velocity * Time.deltaTime;
        transform.position += moveAmount;

        if (Input.GetButtonDown("Attack") && currentState != PlayerState.attack && currentState != PlayerState.stagger)
        {
            StartCoroutine(Attack());
        } else if ((Input.GetButtonDown("Ranged Attack") && currentState != PlayerState.attack && currentState != PlayerState.stagger))
        {
            if (playerInventory.HasItem(wand))
            {
                StartCoroutine(RangedAttack());
            }
        }
        else if(currentState == PlayerState.walk || currentState == PlayerState.idle)
        {
            Move();
        }
        
    
    }
    public IEnumerator RangedAttack()
    {
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        FireProjectile();
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.3f);
        if (currentState != PlayerState.interact)
        {
            currentState = PlayerState.walk;
        }
    }

    private void FireProjectile()
    {
        Vector2 vector = new Vector2(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        if (manaFloat >= fireBall.manaCost)
        {
            manaFloat -= fireBall.manaCost;
            fireBall = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<FireBall>();
            fireBall.Create(vector, ProjectileDirection());
        }
  
    }

    Vector3 ProjectileDirection()
    {
        float trig = Mathf.Atan2(animator.GetFloat("moveY"), animator.GetFloat("moveX"));
        return new Vector3(0,0,trig);
    }
    public IEnumerator Attack()
    {
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.3f);
        if(currentState != PlayerState.interact)
        {
            currentState = PlayerState.walk;
        }
    }
     public IEnumerator ItemPickup()
    {
        animator.SetBool("pickedup item", true);
        currentState = PlayerState.interact;
        itemSprite.sprite = playerInventory.currentItem.sprite;
        yield return new WaitForSeconds(1f);
        animator.SetBool("pickedup item", false);
        itemSprite.sprite = null;
        currentState = PlayerState.walk;
    }
    public void Move()
    {
        if (direction.x != 0 || direction.y != 0)
        {
            animator.SetFloat("moveX", direction.x);
            animator.SetFloat("moveY", direction.y);
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }
    }
    public void Knock(float knockTime, float damage)
    {
        StartCoroutine(KnockCo(knockTime));
        TakeDamage(damage);
    }
    private IEnumerator KnockCo(float knockTime)
    {
        if(rigidbodys != null)
        {
            yield return new WaitForSeconds(knockTime);
            rigidbodys.velocity = Vector2.zero;
            currentState = PlayerState.idle;
            rigidbodys.velocity = Vector2.zero;
               
            }
    }
}
