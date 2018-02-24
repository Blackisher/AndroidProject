using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player_NetworkSetUp : NetworkBehaviour {

	// Use this for initialization
	void Start () {
        if (isLocalPlayer)
        {
            //GameObject.Find("Main Camera").SetActive(false);
           // GetComponent<CharacterController>().enabled = true;
            //GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = true;
            GetComponent<PlayerController>().enabled = true;
            GetComponent<BoxCollider>().enabled = true;
            //GetComponent<Animator>().enabled = true;

        }
	}
	

}
