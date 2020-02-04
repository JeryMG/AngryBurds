using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public GameObject _PoufPrefab;

    private void Update()
    {
        if (transform.position.y > 9 ||
            transform.position.y < -9 ||
            transform.position.x > 15 ||
            transform.position.x < -15)
        {
            string currentScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentScene);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Burd Burd = other.collider.GetComponent<Burd>();
        if (Burd != null)
        {
            Destroy(gameObject);
            GameObject _Pouf = Instantiate(_PoufPrefab, transform.position, Quaternion.identity);
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
            GameObject _Pouf = Instantiate(_PoufPrefab, transform.position, Quaternion.identity);
        }
    }
}
