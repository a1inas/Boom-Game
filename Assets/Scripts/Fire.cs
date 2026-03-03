using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject BrickDeathEffect;

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Brick")
        {
            Destroy(other.gameObject);
            Instantiate(BrickDeathEffect, transform.position, transform.rotation);
        }
    }
}
