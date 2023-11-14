using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 2;

        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            // SceneManager.LoadScene("GameOver");
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            TakeDamage(2);
            Debug.Log("hit");
        }

    }
}

