using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatItem : Item
{
    public Player player;
    public KnockBack KnockBack;
    
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.Equals(player)) ;
    }
}
