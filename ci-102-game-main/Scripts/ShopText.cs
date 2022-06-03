using UnityEngine;
using TMPro;

public class ShopText : MonoBehaviour
{
    public TMP_Text MoneyText;

    // Update is called once per frame
    void Update()
    {
        MoneyText.text = "Money: $" + Stats.Money.ToString();
    }
}