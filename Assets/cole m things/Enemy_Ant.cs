﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Ant : MonoBehaviour
{
    public float speedMod;
    public float damage;
    public GameObject ant;

    public Transform stationCore;
    private Rigidbody2D antBody;
    private Transform antTransform;


    // Start is called before the first frame update
    void Start()
    {
        if (ant == null)
        {
            print("No ant object set to ant script in prefab");
        }

        //getting the ant rigid body
        antBody = ant.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //set the ray on the ant to point to the center of the map (ie, the station core)
        antTransform = ant.GetComponent<Transform>();
        antTransform.up = (antTransform.position - stationCore.position) * -1;
        
        //these are extremely static enemies so the velocity is just gonna be instanced here
        Vector2 vel = new Vector2(antTransform.up.x, antTransform.up.y);
        antBody.velocity = vel * speedMod;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject toDestroy = collision.gameObject;
        if (toDestroy.tag == "StationArmor")
        {
           // Destroy(toDestroy);
        }
    }

    public void setStationCore(Transform core)
    {
        stationCore = core;
    }
}
