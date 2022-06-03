using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurt : MonoBehaviour
{

    /*
    public static GameObject border80;
    public GameObject border60;
    public GameObject border40;
    public GameObject border20;
    public GameObject border0;

    public static Renderer rend80;
    public static Renderer rend60;
    public static Renderer rend40;
    public static Renderer rend20;
    public static Renderer rend0;

    public static Color lit = new Color(255, 200, 200, 255);
    public static Color midlit = new Color(255, 160, 160, 255);
    public static Color mid = new Color(255, 120, 120, 255);
    public static Color darkmid = new Color(255, 80, 80, 255);
    public static Color dark = new Color(255, 0, 0, 255);
    public static Color invis = new Color(255, 255, 255, 0);

    public static float time = 0f;
    */

    public static GameObject border;

    void Start()
    {
        /*
        rend80 = border80.GetComponent<Renderer>();
        rend60 = border60.GetComponent<Renderer>();
        rend40 = border40.GetComponent<Renderer>();
        rend20 = border20.GetComponent<Renderer>();
        rend0 = border0.GetComponent<Renderer>();

        border80.active = false;
        border60.active = false;
        border40.active = false;
        border20.active = false;
        border0.active = false;
        */

        border.active = false;
    }

    void Update()
    {

    }

    public static void Ouch2()
    {
        border.active = true;
    }

    /*public static void Ouch()
    {
        if (Stats.startLife * 0.8 <= Stats.Life)
        {
            Debug.Log("oUCH");
            rend80.material.color = lit;

            border80.active = true;

        }
        else if (Stats.startLife * 0.6 <= Stats.Life)
        {
            Debug.Log("oUCH 2");
            rend80.material.color = midlit;
            rend60.material.color = lit;


        }
        else if (Stats.startLife * 0.4 <= Stats.Life)
        {
            Debug.Log("oUCH 3");
            rend80.material.color = mid;
            rend60.material.color = midlit;
            rend40.material.color = lit;

        }
        else if (Stats.startLife * 0.2 <= Stats.Life)
        {
             Debug.Log("oUCH 4");
             rend80.material.color = darkmid;
             rend60.material.color = mid;
             rend40.material.color = midlit;
             rend20.material.color = lit;

        }
        else
        {
             Debug.Log("oUCH 5");
             rend80.material.color = dark;
             rend60.material.color = darkmid;
             rend40.material.color = mid;
             rend20.material.color = midlit;
             rend0.material.color = lit;

        }
    }
    */
}
