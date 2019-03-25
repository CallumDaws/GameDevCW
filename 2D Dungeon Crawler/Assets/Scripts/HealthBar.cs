using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform bar;
    public Player player;
    private float health;


    void Start()
    {
         bar = transform.Find("Bar");
       
    }

    // Update is called once per frame
    public void SetSize(float normalized)
    {
        bar.localScale = new Vector3(normalized, 1f); 
    }
}
