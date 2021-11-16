using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public PersonalController Player;
    // Use this for initialization
    private void Start()
    {
        Player = Player == null ? GetComponent<PersonalController>() : Player;
        if (Player == null)
        {
            Debug.LogError("Player not set to controller");
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Player != null)
        {

            //if (Input.GetKey(KeyCode.D)) Player.MoveRigth();
           // if (Input.GetKey(KeyCode.A)) Player.MoveLeft();
           // if (Input.GetKey(KeyCode.Space)) Player.Jump();
            //if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift)) Player. ();

        }


    }
}
