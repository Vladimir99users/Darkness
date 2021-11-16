using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHero : MonoBehaviour
{
    public GameObject Player;
    public GameObject Prafabs_hero;
    private Transform Start_position;
    private bool Hero_dead = false ;


    private void Start()
    {
        Start_position = GetComponent<Transform>();
    }

    public void NewPoinerSpawnHero(GameObject _pointer)
    {
        Start_position = _pointer.transform;
    }


    void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        if(Player ==null) Hero_dead = true;

        if (Hero_dead)
        {
            Hero_dead = false;
            Instantiate(Prafabs_hero, Start_position);
            Player = Prafabs_hero;
        }    
    }



}
