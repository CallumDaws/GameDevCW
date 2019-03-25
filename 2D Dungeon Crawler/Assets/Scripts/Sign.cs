using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : Interactable
{

    public GameObject popupBox;
    public Text popupText;
    public string text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && inRange)
        {
            if(popupBox.activeInHierarchy)
            {
                popupBox.SetActive(false);
            }
            else
            {
                popupBox.SetActive(true);
                popupText.text = text;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
            popupBox.SetActive(false);
        }
    }
}
