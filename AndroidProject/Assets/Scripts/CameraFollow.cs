using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject player;
    public Vector3 offset;
    private float offsetMagnitute;
    public float lerpRate;
    public bool gameOver;

    void Start () {
        offset = player.transform.position - transform.position;
        offsetMagnitute = offset.magnitude;
        offset = offset.normalized;
    }
	
	void Update () {
        if (!gameOver)
        {
            Follow();
        }
	}

    void Follow()
    {
        Quaternion rotation = player.transform.rotation;
        //offset is normalized
        //so new offset too
        Vector3 newOffset = rotation * offset;
        //camera current position
        Vector3 pos = transform.position;
        //where camera should go
        Vector3 target = player.transform.position - newOffset * offsetMagnitute;
        //new position for camera without shaking
        pos = Vector3.Lerp(pos, target, lerpRate * Time.deltaTime);
        //assign new possition.
        transform.position = pos;
        //turn to player
        transform.LookAt(player.transform.position);
    }
}
