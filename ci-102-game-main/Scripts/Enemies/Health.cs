using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 100f;
    public int reward = 50;
    public bool hit = false;

    public Color originalColor;
    public Color hitColor;

    public Renderer rend;

    public GameObject blood;

    // Taken damage

    void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
    }

    public void Update()
    {
        if (hit)
        {

            hitColor = new Color(200, 0, 0, 200);
            rend.material.color = hitColor;

            Vector3 newPos = transform.position;
            newPos.x = transform.position.x - (1 / 5);

            transform.position = newPos;
        }
    }

    public void TakeDamage(float damage)
    {

        Shake();
        GameObject bloodInstance = (GameObject)Instantiate(blood, transform.position, transform.rotation);
        Destroy(bloodInstance, 1f);

        health -= damage;

        if (health <= 0)
        {
            Die();
        }

    }

    public void Shake()
    {
        StartCoroutine("ShakeNow");
    }

    IEnumerator ShakeNow()
    {
        originalColor = gameObject.GetComponent<Renderer>().material.color;
        Vector3 originalPos = transform.position;

        if (hit == false)
        {
            hit = true;
        }

        yield return new WaitForSeconds(.1f);

        hit = false;
        
        rend.material.color = originalColor;

        transform.position = originalPos;
    }

    // Kills enemy

    void Die()
    {
        Destroy(gameObject);
        Stats.Money += reward;

        WaveSpawner.EnemiesAlive--;
    }

}
