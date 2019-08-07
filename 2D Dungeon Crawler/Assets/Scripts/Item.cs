using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{   
    public string itemName;
    public string weaponType;
    public int itemType;
    public Sprite sprite;
    public int damage;
    public int health;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {

        sprite = GetComponent<Sprite>();
    }

    // Update is called once per frame
    void Update()
    {
    
    }


}
