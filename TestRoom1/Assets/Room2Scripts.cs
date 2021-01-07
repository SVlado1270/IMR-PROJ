using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2Scripts : MonoBehaviour
{
    public GameObject pergament3;
    public GameObject piesa1, piesa2, piesa3, key1;
    public GameObject Einstein, key2, usaDulap, dulap;
    public GameObject Sunflower, Est, pergament_etaj_clue;
    public GameObject tabla, pergament_final;
    public double maxDist = 6.0;
    // public GameObject Einstein, dulap, cheie;

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
        Debug.Log(Vector3.Distance(Est.transform.position, Sunflower.transform.position));
        if(isNear(piesa1, pergament3, maxDist) && isNear(piesa2, pergament3,maxDist) && isNear(piesa3, pergament3, maxDist))
        {
            key1.active = true;
            piesa1.active = false;
            piesa2.active = false;
            piesa3.active = false;
        }

        if(isNear(key2, usaDulap, 1.0))
        {
            usaDulap.active = false;
            Einstein.active = true;
        }

        if (isNear(Sunflower, Est, maxDist))
        {
            key2.active = true;
            pergament_etaj_clue.active = true;
            Est.active = false;
        }

        if (isNear(Einstein, tabla, maxDist))
        {
            pergament_final.active = true;
            tabla.active = false;
        }
    }
}
