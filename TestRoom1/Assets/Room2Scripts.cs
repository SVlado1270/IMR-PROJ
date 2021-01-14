using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room2Scripts : MonoBehaviour
{
    public GameObject pergament3;
    public GameObject piesa1, piesa2, piesa3, key1;
    public GameObject Einstein, key2, usaDulap, dulap, table_p;
    public GameObject Sunflower, Est, pergament_etaj_clue, Nord;
    public GameObject tabla, pergament_fin;
    public double maxDist = 6.0;
    private bool flower_is_active = false;
    private bool einst_is_active = false;

    private bool timer_started = false;
    private float fire_start_time;

    private bool finished = false;
    private bool second_key_dropped = false;
    private bool pieces_together = false;
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
        if (!pieces_together)
        {
            if (isNear(piesa1, pergament3, maxDist) && isNear(piesa2, pergament3, maxDist) && isNear(piesa3, pergament3, maxDist))
            {
                key1.active = true;
                piesa1.active = false;
                piesa2.active = false;
                piesa3.active = false;
                pieces_together = true;
            }
        }

        if (!einst_is_active)
        {
            if (isNear(key2, usaDulap, 2.0))
            {
                einst_is_active = true;
                usaDulap.active = false;
                Einstein.active = true;
                key2.active = false;
            }
        }

        if (!flower_is_active)
        {
            if (isNear(key1, table_p, 3.0))
            {
                flower_is_active = true;
                Sunflower.active = true;
                key1.active = false;
            }
        }


        if (!second_key_dropped)
        {
            if (isNear(Sunflower, Est, maxDist))
            {
                key2.active = true;
                pergament_etaj_clue.active = true;
                Est.active = false;
                second_key_dropped = true;
            }
        }

        if (!finished)
        {
            if (isNear(Einstein, tabla, maxDist))
            {
                pergament_fin.active = true;
                tabla.active = false;
                Nord.active = false;
                timer_started = true;
                fire_start_time = Time.time;
                finished = true;
            }
        }



        if (timer_started)
        {
            float time_elapsed = Time.time - fire_start_time;

            if (time_elapsed > 10)
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }
}
