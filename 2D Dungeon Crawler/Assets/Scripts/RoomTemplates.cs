using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
	public GameObject[] bottomRooms;
	public GameObject[] topRooms;
	public GameObject[] leftRooms;
	public GameObject[] rightRooms;

	public GameObject[] closedRooms;

	public List<GameObject> rooms;

	public float waitTime;
	private bool spawnedBoss = false;
    private bool spawnedItem = false;
	public GameObject boss;
    public GameObject[] lootRooms;

	void Update(){

        if (waitTime <= 0.5 && spawnedItem == false)
        {
            for(int i=0; i<rooms.Count; i++)
            {
                if(rooms[i].transform.parent.tag == "Left")
                {
                    Vector3 pos = new Vector3(rooms[i].transform.position.x, rooms[i].transform.position.y, 0);
                    Instantiate(lootRooms[0], pos, Quaternion.identity);
                    spawnedItem = true;
                    rooms[i].tag = "Untagged";
                    break;
                }
                else if(rooms[i].transform.parent.tag == "Right")
                {
                    Vector3 pos = new Vector3(rooms[i].transform.position.x, rooms[i].transform.position.y, 0);
                    Instantiate(lootRooms[2], pos, Quaternion.identity);
                    spawnedItem = true;
                    rooms[i].tag = "Untagged";
                    break;
                }
                else if(rooms[i].transform.parent.tag == "Bottom")
                {
                    Vector3 pos = new Vector3(rooms[i].transform.position.x, rooms[i].transform.position.y, 0);
                    Instantiate(lootRooms[1], pos, Quaternion.identity);
                    rooms[i].tag = "Untagged";
                    spawnedItem = true;
                    break;
                }
            }
        }
		if(waitTime <= 0 && spawnedBoss == false){
			for(int i = 0; i<rooms.Count; i++){
				if(rooms[i].CompareTag("EndRoom")){
                   Vector3 pos =  new Vector3(rooms[i].transform.position.x + 30,rooms[i].transform.position.y-15,-1);
					Instantiate(boss, pos, Quaternion.identity);
					spawnedBoss = true;
                    break;
				}
			}
		}else{
			waitTime -= Time.deltaTime;
		}
	}

}
