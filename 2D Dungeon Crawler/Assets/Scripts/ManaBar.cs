using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaBar : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform bar;
    public Player player;
    private float mana;


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
