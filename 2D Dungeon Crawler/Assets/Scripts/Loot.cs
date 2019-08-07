using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
        public Item item;
        public int chance;
    
    // Start is called before the first frame update
    void Start()
    {
        item = this.gameObject.GetComponent<Item>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
