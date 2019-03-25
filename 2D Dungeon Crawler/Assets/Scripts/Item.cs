using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{   
    public string itemName;
    public string weaponType;
    public Sprite sprite;
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
