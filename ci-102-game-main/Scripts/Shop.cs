using UnityEngine;

public class Shop : MonoBehaviour
{

    public int minataurCost = 200;
    public int hydraCost = 400;

    void Start()
    {
    }

    public void PurchaseTurret()
    {

        if (Stats.Money < minataurCost)
        {
            Debug.Log("Not enough money");
            return;
        }

        Stats.Money -= minataurCost;

        Debug.Log("Mintoaur Built");
    }

    public void PurchaseLaser()
    {
        if (Stats.Money < hydraCost)
        {
            Debug.Log("Not enough money");
            return;
        }

        Stats.Money -= hydraCost;

        Debug.Log("Hydra Built");
    }
}