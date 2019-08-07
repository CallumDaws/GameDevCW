using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LootTable : MonoBehaviour
{

    public Loot[] loots;
    public Loot loot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Loot LootDrop()
    {
        int prob = 0;
        int currentProb = Random.Range(0, 100);
        for(int i=0; i<loots.Length; i++)
        {
            prob += loots[i].chance;
            if(currentProb <= prob)
            {
                loots[i].item = loots[i].GetComponent<Item>();
                loot = loots[i];

                return loot;
            }
        }
        return null;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
