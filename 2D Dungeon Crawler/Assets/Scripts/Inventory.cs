using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public Item currentItem;
    public List<Item> items = new List<Item>();
    public Player player;
    public int keys;
    public int coins;
    public int itemType;
    public int HealthPots;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        player = FindObjectOfType<Player>();
    }

    public bool HasItem(Item i)
    {
        if (items.Contains(i))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void addItem(Item i)
    {
        if (itemType == 1)
        {
            player.health += i.health;
            player.speed += i.speed;
            foreach (KnockBack k in player.GetComponents<KnockBack>())
            {
                k.damage += i.damage;
            }
        }
        else
        {
            items.Add(i);
        }
    }
}
