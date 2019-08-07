using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyTemplates templates;
    public Room r;
    private int rand;
    private bool spawned = false;
    private int count = 0;

    public float waitTime = 1f;

    void Start()
    {
        Destroy(gameObject, waitTime);
        r = GetComponentInParent<Room>();
        templates = GameObject.FindGameObjectWithTag("Enemies").GetComponent<EnemyTemplates>();
        Invoke("Spawn", 0.1f);
        rand = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Spawn()
    {
        if (spawned == false)
        {
            switch (rand)
            {

                case 1:
                    Enemy e1 = Instantiate(templates.enemies[0], transform.position, Quaternion.identity);
                    r.enemies.Add(e1);
                    break;
                case 2:

                   Enemy e = Instantiate(templates.enemies[1], transform.position, Quaternion.identity);
                    r.enemies.Add(e);
                    break;


            }
        }

    }
}
