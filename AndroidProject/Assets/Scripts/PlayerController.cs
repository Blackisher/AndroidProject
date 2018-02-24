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
        Jump,
        TurnLeft,
        TurnRight
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
       // myText1.text = "AAA";
        myText2.text = "BBB";
        myText22.text = "BBB";
        myText3.text = "CCC";
        rb.centerOfMass = com;
        //rb.velocity = new Vector3(speed, 0, speed);
        Input.compass.enabled = true;
        Input.gyro.enabled = true;
        Input.location.Start();
    }
	
	// Update is called once per frame
	void Update ()
    {

        

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            Command(Moves.Left, force);
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            Command(Moves.Right, force);
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            Command(Moves.Up, force);
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            Command(Moves.Down, force);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Command(Moves.Jump, force);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            Command(Moves.TurnLeft, force);
        }

        if (Input.GetKey(KeyCode.E))
        {
            Command(Moves.TurnRight, force);
        }

        //myText1.text = "a" + 10 * Input.acceleration;
        //myText1.text = transform.rotation.ToString();
        //myText2.text = "b" +  (10 * Input.gyro.rotationRate).ToString();
        //myText22.text = "c"+ (10 * Input.gyro.rotationRateUnbiased);
        //myText3.text = "d" + 10 * Input.compass.magneticHeading + ", " + 10 * Input.compass.trueHeading + ", " + 10 * Input.compass.headingAccuracy;


        //TODO if small then do nothing
        //Moves player by tellting
        Command(Moves.Up, (int)(10 * (-Input.acceleration.z)));
        int x = (int) (10*Input.acceleration.x);
        if (x < -2)
        {
            Command(Moves.TurnLeft, force);
        }

        if (x > 2)
        {
            Command(Moves.TurnRight, force);
        }

        //Turn player
        // Command(Moves.TurnRight, (int)(10 * (-Input.acceleration.x)));



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
        Quaternion playerRotation = transform.rotation;
        switch (move)
        {
            case Moves.Left:
                rb.AddForce(playerRotation * new Vector3(-passedForce, 0, 0));
                break;
            case Moves.Right:
                rb.AddForce(playerRotation * new Vector3(passedForce, 0, 0));
                break;
            case Moves.Up:
                rb.AddForce(playerRotation * new Vector3(0, 0, passedForce));
                break;
            case Moves.Down:
                rb.AddForce(playerRotation * new Vector3(0, 0, -passedForce));
                break;
            case Moves.Jump:
                rb.AddForce(new Vector3(0, passedForce, 0));
                break;
            case Moves.TurnLeft:
                transform.RotateAround(transform.position, -transform.up, Time.deltaTime * 90f);
                break;
            case Moves.TurnRight:
                transform.RotateAround(transform.position, transform.up, Time.deltaTime * 90f);
                break;
        }
    }
}
