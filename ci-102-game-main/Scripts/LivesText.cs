using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesText : MonoBehaviour
{
    public Text LifeText;

    // Update is called once per frame
    void Update()
    {
        LifeText.text = Stats.Life.ToString() + " Lives";
    }
}
