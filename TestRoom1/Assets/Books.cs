﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Books : MonoBehaviour
{
    public GameObject book_green, book_red, book_blue;
    public GameObject dtop1, dtop2, dtop3;

    public GameObject key1, pergament1, pergament2;
    public GameObject chest1, chest2, banana1, banana2;

    public GameObject bagheta, key2, broasca;
    public GameObject maimuta1, pergament_final;

    public GameObject planks1, cutie1, topor;
    public GameObject cutie2, cutie3, cutie4, planks2, planks3;
    public double maxDistance = 0.6;

    public bool match = false;
    public bool first_chest_is_opened = false;
    public bool second_chest_is_opened = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    bool isNear(GameObject o1, GameObject o2, double distance)
    {
        return Vector3.Distance(o1.transform.position, o2.transform.position) < distance;
    }

    // Update is called once per frame
    void Update()
    {
        if (!match)
        {
            if (isNear(dtop1, book_red, maxDistance) &&
                isNear(dtop2, book_green, maxDistance) &&
                isNear(dtop3, book_blue, maxDistance))
            {
                match = true;
                key1.active = true;
                pergament1.active = false;
                pergament2.active = true;
            }
        }

        if(isNear(chest1, key1, 0.9))
        {
            first_chest_is_opened = true;
            // key1.active = false;
            chest1.active = false;
            banana1.active = true;
        }

        if (isNear(topor, cutie1, 1.1))
        {
            planks1.active = true;
            cutie1.active = false;
        }

        if (isNear(topor, cutie2, 0.9))
        {
              bagheta.active = true;
              cutie2.active = false;
        }

        if (isNear(topor, cutie3, 1.1))
        {
            planks2.active = true;
            cutie3.active = false;
        }

        if (isNear(topor, cutie4, 1.0))
        {
            planks3.active = true;
            cutie4.active = false;
        }

        if (isNear(bagheta, broasca, 5.0))
        {
            key2.active = true;
            bagheta.active = false;
        }

        if (isNear(chest2, key2, maxDistance))
        {
           // key2.active = false;
            chest2.active = false;
            banana2.active = true;
        }

        if (isNear(maimuta1, banana1, 3.0) && isNear(maimuta1, banana2, 3.0))
        {
            pergament_final.active = true;
            Thread.Sleep(10);
            Application.Quit();
        }
    }
}
