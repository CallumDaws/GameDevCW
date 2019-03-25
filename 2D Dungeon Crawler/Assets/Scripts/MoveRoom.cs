using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRoom : MonoBehaviour
{
    // Start is called before the first frame update
    private CameraMove cam;
    public Vector2 cameraPos;
    public Vector3 playerPos;
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMove>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cam.minPosition += cameraPos;
            cam.maxPosition += cameraPos;
            other.transform.position += playerPos;
        }
    }
}
