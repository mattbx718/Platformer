using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{

    Health damage;

    public GameObject hitPoints;

    public int speed = 1;
    Vector2 direction;
    public bool left =  true;

    // Start is called before the first frame update
    void Start()
    {
        damage = hitPoints.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (left)
        {
            transform.position = Vector2.left;
        }
        transform.position = new Vector2(transform.position.x + direction, Transform.position.y);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Player")
        {
            damage.TakeDamage(2);
        }
    }
}
