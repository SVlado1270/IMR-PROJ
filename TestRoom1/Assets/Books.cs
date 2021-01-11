using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Books : MonoBehaviour
{
    public GameObject book_green, book_red, book_blue;
    public GameObject dtop1, dtop2, dtop3;

    public GameObject pergament1, pergament2, pergament_final;
    public GameObject chest1, chest2;
    public GameObject key1, key2;



    public GameObject broasca;
    public GameObject maimuta1, maimuta2;
    public GameObject banana1, banana2;

    public GameObject bagheta, topor;
    public GameObject cutie_bagheta;
    public GameObject cutie1,  cutie2, cutie3;
    public GameObject planks1, planks2, planks3;
    public double maxDistance = 0.6;
    public double chestDistance = 0.9;

    private bool match = false;
    private bool first_chest_is_opened = false;
    private bool second_chest_is_opened = false;
    private bool second_key_is_dropped = false;
    private bool bagheta_is_dropped = false;
    private bool player_won = false;
    private bool crate1_is_destroyed = false;
    private bool crate2_is_destroyed = false;
    private bool crate3_is_destroyed = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    private bool isNear(GameObject o1, GameObject o2, double distance)
    {
        return Vector3.Distance(o1.transform.position, o2.transform.position) < distance;
    }

    private bool monkey_has_banana(GameObject monkey)
    {
        return isNear(monkey, banana1, 0.75) || isNear(monkey, banana2, 0.75);
    }

    private void handle_empty_crates_destruction() 
    {
        double crate_min_dist = 1.75;
        Debug.Log(Vector3.Distance(topor.transform.position, cutie1.transform.position));
        if(!crate1_is_destroyed && isNear(topor, cutie1, crate_min_dist))
        {
            crate1_is_destroyed = true;
            planks1.SetActive(true);
            cutie1.SetActive(false);
        }
        if (!crate2_is_destroyed && isNear(topor, cutie2, crate_min_dist))
        {
            crate2_is_destroyed = true;
            planks2.SetActive(true);
            cutie2.SetActive(false);
        }
        if (!crate3_is_destroyed && isNear(topor, cutie3, crate_min_dist))
        {
            crate3_is_destroyed = true;
            planks3.SetActive(true);
            cutie3.SetActive(false);
        }
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
                key1.SetActive(true);
                pergament1.SetActive(false);
                pergament2.SetActive(true);
            }
        }

        if (!first_chest_is_opened)
        {
            if (isNear(chest1, key2, 0.9))
            {
                first_chest_is_opened = true;
                chest1.SetActive(false);
                banana1.SetActive(true);
                key2.SetActive(false);
            }
            else if (isNear(chest1, key1, 0.9))
            {
                first_chest_is_opened = true;
                chest1.SetActive(false);
                banana1.SetActive(true);
                key1.SetActive(false);
            }
        }

        if (!bagheta_is_dropped)
        {
            if (isNear(topor, cutie_bagheta, 0.9))
            {
                bagheta_is_dropped = true;
                bagheta.SetActive(true);
                cutie_bagheta.SetActive(false);
            }
        }

        if (!second_key_is_dropped)
        {
            if (isNear(bagheta, broasca, 5.0))
            {
                second_key_is_dropped = true;
                key2.SetActive(true);
                bagheta.SetActive(false);
            }
        }

        if (!second_chest_is_opened)
        {
            if (isNear(chest2, key2, 0.9))
            {
                second_chest_is_opened = true;
                chest2.SetActive(false);
                banana2.SetActive(true);
                key2.SetActive(false);
            }
            else if (isNear(chest2, key1, 0.9))
            {
                second_chest_is_opened = true;
                chest2.SetActive(false);
                banana2.SetActive(true);
                key1.SetActive(false);
            }
        }

        handle_empty_crates_destruction();
        if (!player_won)
        {
            player_won = monkey_has_banana(maimuta1) && monkey_has_banana(maimuta2);
            if (player_won)
            {
                pergament_final.SetActive(true);
                Thread.Sleep(10);
                Application.Quit();
            }
        }
    }
}
