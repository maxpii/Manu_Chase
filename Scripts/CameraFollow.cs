using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{   
    private Transform player;
    private Vector3 tempPos;

    [SerializeField]
    private float minX,maxX;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        minX = 26;
        maxX = 122;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // late update is called after all other updates are finished
    void LateUpdate() {
        if(!player) return;          
        tempPos = transform.position;// current position of camera
        tempPos.x = player.position.x;  // set the this things x to the x position of the camera 

        if (tempPos.x < minX) tempPos.x = minX;
        else if (tempPos.x > maxX) tempPos.x = maxX;


        transform.position = tempPos; // back to the camera
    }
}
