using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
	public int openingDirection;

	private RoomTemplates templates;

	private int rand;
	private bool spawned = false;
	private int count = 0;

	public float waitTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
		Destroy(gameObject, waitTime);
		templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
		Invoke("Spawn", 0.1f);
    }

    // Update is called once per frame
    void Spawn()
    {
		if(spawned == false){
		switch(openingDirection){

		case 2:
				rand = Random.Range(0, templates.topRooms.Length);
				Instantiate(templates.topRooms[rand], transform.position, Quaternion.identity);
				break;
		case 1:
				rand = Random.Range(0, templates.bottomRooms.Length);
				Instantiate(templates.bottomRooms[rand], transform.position, Quaternion.identity);
				break;
		case 3:
				rand = Random.Range(0, templates.leftRooms.Length);
				Instantiate(templates.leftRooms[rand], transform.position, Quaternion.identity);
				break;
		case 4:
				rand = Random.Range(0, templates.rightRooms.Length);
				Instantiate(templates.rightRooms[rand], transform.position, Quaternion.identity);
				break;
			}
			spawned = true;

		}
    }
	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Spawn Point")){
			if(other.GetComponent<RoomSpawner>().spawned == false && spawned == false){
				Instantiate(templates.closedRooms[0], transform.position, Quaternion.identity);
				Destroy(gameObject);
			}
			spawned = true;
		}
	}
}
