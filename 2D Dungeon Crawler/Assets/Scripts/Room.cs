using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public List<Enemy> enemies;
    public Door[] doors;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isClear();
    }

    public void isClear()
    {
        for(int i =0; i<enemies.Count; i++)
        {
            if(enemies[i].gameObject.activeInHierarchy)
            {
                CloseDoors();
                return;
            }
        }
        OpenDoors();
    }

    public void CloseDoors()
    {
        for(int i = 0; i<doors.Length; i++)
        {
            doors[i].Close();
        }
    }

    public void OpenDoors()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].Open();
        }
    }
    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            //Activate all enemies 
            for (int i = 0; i < enemies.Count; i++)
            {
                ChangeActivation(enemies[i], true);
            }
        }
    }

    public virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            //Deactivate all enemies  
            for (int i = 0; i < enemies.Count; i++)
            {
                ChangeActivation(enemies[i], false);
            }
            CloseDoors();
        }
       
    }

    public void ChangeActivation(Component component, bool activation)
    {
        component.gameObject.SetActive(activation);
    }
}
