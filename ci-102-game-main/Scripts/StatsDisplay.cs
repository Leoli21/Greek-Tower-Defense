using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsDisplay : MonoBehaviour
{
    public TMP_Text GoldSpent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GoldSpent.text = "Crates Opened: " + GameStats.instance.cratesOpened.ToString();
    }
}
