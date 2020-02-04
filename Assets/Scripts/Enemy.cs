using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        Burd Burd = other.collider.GetComponent<Burd>();
        if (Burd != null)
        {
            Destroy(gameObject);
            return;
        }

        Enemy enemy = other.collider.GetComponent<Enemy>();
        if (enemy !=null)
        {
            return;
        }

        if (other.GetContact(0).normal.y < -0.5)
        {
            //Debug.Log(other.GetContact(0).normal);
            Destroy(gameObject);
        }
    }
}
