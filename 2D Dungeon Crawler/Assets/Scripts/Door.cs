using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType
{
    shop,
    enemy,
    item
}
public class Door : Interactable
{
    public DoorType type;
    public bool open = false;
    public Inventory inventory;
    public SpriteRenderer sprite;
    public BoxCollider2D bcollider2D;

    // Start is called before the first frame update
    void Start()
    {
        bcollider2D = GetComponent<BoxCollider2D>();
        inventory = FindObjectOfType<Player>().playerInventory;
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(inRange && type == DoorType.shop)
        {
            if(inventory.keys > 0)
            {
                inventory.keys -= 1;
                Open();
            }
        }
    }

    public void Open()
    {
        open = true;
        bcollider2D.enabled = false;
    }

    public void Close()
    {
        open = false;
        bcollider2D.enabled = true;
    }
}
