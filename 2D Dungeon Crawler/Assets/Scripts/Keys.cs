using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : Interactable
{
    public Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            inventory.keys += 1;
            Destroy(this.gameObject);
        }
    }
}
