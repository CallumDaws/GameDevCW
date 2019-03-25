using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
	private float waitTime = 5;

	void Update(){
		waitTime -= Time.deltaTime;
		if(waitTime<=0){
			Destroy(this.gameObject);
		}
	}
	void OnTriggerEnter2D(Collider2D other){
        	if (!other.CompareTag("NoDelete"))
        	{
        	if(!other.CompareTag("Player")){
        Debug.Log("Destroyed");
			Destroy(other.gameObject);
			}
			}
		}
	}
