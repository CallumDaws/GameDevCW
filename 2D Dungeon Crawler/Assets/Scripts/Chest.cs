using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable
{
    private Animator anim;
    private bool isOpen;
    public Inventory playerInventory;
    public LootTable contents;
    public Loot loot;
    public Player player;
    public Item item;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
        playerInventory = FindObjectOfType<Inventory>();
        contents = GameObject.FindGameObjectWithTag("ChestLoot").GetComponent<LootTable>();
        loot = contents.LootDrop();
        item = loot.item;
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(inRange)
        {
            if(!isOpen)
            {
                OpenChest();
                StartCoroutine(player.ItemPickup());
            }
            else
            {
                chestOpen();
            }
        }
    }

    public void OpenChest()
    {
        anim.SetBool("Open", true);
        playerInventory.addItem(item);
        playerInventory.currentItem = item;
        isOpen = true;

    }
    public void chestOpen()
    {
        playerInventory.currentItem = null;
    }
}
