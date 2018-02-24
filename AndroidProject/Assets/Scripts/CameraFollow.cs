using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject player;
    public Vector3 offset;
    private float offsetMagnitute;
    public float lerpRate;
    public bool gameOver;

    // Use this for initialization
    void Start () {
        offset = player.transform.position - transform.position;
        offsetMagnitute = offset.magnitude;
        offset = offset.normalized;


    }
	
	// Update is called once per frame
	void Update () {
        if (!gameOver)
        {
            Follow();
        }
	}

    void Follow()
    {
        Quaternion rotation = player.transform.rotation;

        if (!transform.rotation.Equals(rotation))
        {
            //still problem - its just rotating over and over and not just a little
            //offset = rotation * offset;
            //Vector3 pos = transform.position;
            //Vector3 target = player.transform.position - offset * offsetMagnitute;
            //pos = Vector3.Lerp(pos, target, lerpRate * Time.deltaTime);
            //transform.position = pos;
        }
        
        
        
        
        //Notepad.....



        //transform.position = transform.position - change;
        //player.transform.position
        /*
        //current position of camera
        Vector3 pos = transform.position;
        System.Console.WriteLine("pos:" + pos);
        Vector3 change = new Vector3(Input.acceleration.x, Input.acceleration.y, 0);
        System.Console.WriteLine("change:" + change);
        offset = (offset + change).normalized * offset.magnitude;
        System.Console.WriteLine("offset:" + offset);
        Vector3 target = player.transform.position - offset;
        System.Console.WriteLine("target:" + target);
        pos = Vector3.Lerp(pos, target, lerpRate * Time.deltaTime);
        System.Console.WriteLine("pos:" + pos);
        transform.position = pos;

    */
    }
}
