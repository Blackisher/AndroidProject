using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public enum Moves
    {
        Up,
        Down,
        Left,
        Right,
        Jump
    }
    

    public Vector3 com;
    Rigidbody rb;
    [SerializeField]
    private float speed;

    public Text myText1;
    public Text myText2;
    public Text myText22;
    public Text myText3;

    private Vector2 touchOrigin = -Vector2.one;
    public int force = 50;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        myText1.text = "AAA";
        myText2.text = "BBB";
        myText22.text = "BBB";
        myText3.text = "CCC";
        rb.centerOfMass = com;
        //rb.velocity = new Vector3(speed, 0, speed);
    }
	
	// Update is called once per frame
	void Update ()
    {

        

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Command(Moves.Left, force);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Command(Moves.Right, force);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            Command(Moves.Up, force);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            Command(Moves.Down, force);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Command(Moves.Jump, force);
        }

        myText1.text = Input.acceleration.ToString();
        myText2.text = Input.gyro.rotationRate.ToString();
        myText22.text = Input.gyro.rotationRateUnbiased.ToString();
        myText3.text = Input.compass.magneticHeading + ", " + Input.compass.trueHeading + ", " + Input.compass.headingAccuracy;

        int test = (int)(10000 * Input.gyro.userAcceleration.y);
        System.Console.WriteLine("Input.gyro.userAcceleration:" + Input.gyro.userAcceleration);
        if (test > 0)
        {
            Command(Moves.Up, test);
        }
        else if (test < 0)
        {
            Command(Moves.Down, test);
        }



        /*int horizontal = 0;
        int vertical = 0;

#if UNITY_STANDALONE || UNITY_WEBPLAYER
            horizontal = (int) (Input.GetAxisRaw("Horizontal"));
            vertical = (int) (Input.GetAxisRaw("Vertical"));
        if (horizontal != 0) 
        {
         vertical =0;
        }
#else
        if (Input.touchCount > 0)
            {
                Touch myTouch = Input.touches[0];
            if (myTouch.phase == TouchPhase.Began)
            {
                touchOrigin = myTouch.position;
            } else if (myTouch.phase == TouchPhase.Ended && touchOrigin.x >=0)
            {
                Vector2 touchEnd = myTouch.position;
                float x = touchEnd.x - touchOrigin.x;
                float y = touchEnd.y - touchOrigin.y;
                touchOrigin.x = -1;
                if (Mathf.Abs(x) > Mathf.Abs(y))
                    horizontal = x > 0 ? 1 : -1;
                else
                    vertical = y > 0 ? 1 : -1;

            }

            }
#endif
        rb.velocity = new Vector3(horizontal, 0, vertical);
        */
    }

    private void Command(Moves move, int passedForce)
    {
        switch (move)
        {
            case Moves.Left:
                rb.AddForce(new Vector3(-passedForce, 0, 0));
                break;
            case Moves.Right:
                rb.AddForce(new Vector3(passedForce, 0, 0));
                break;
            case Moves.Up:
                rb.AddForce(new Vector3(0, 0, passedForce));
                break;
            case Moves.Down:
                rb.AddForce(new Vector3(0, 0, -passedForce));
                break;
            case Moves.Jump:
                rb.AddForce(new Vector3(0, passedForce, 0));
                break;
        }
    }
}
