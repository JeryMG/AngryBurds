using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Burd : MonoBehaviour
{
    private Color CurrentColor;
    private Rigidbody2D rb;
    private Vector3 InitialPos;
    [SerializeField] private float LaunchForce = 10f;
    private bool BurdLaunched;
    private float TimeIdle;
    [SerializeField]private float TimeReset = 2;
    private LineRenderer directionRender;

    private void Awake()
    {
        InitialPos = transform.position;
    }

    private void Start()
    {
        CurrentColor = GetComponent<SpriteRenderer>().color;
        rb = GetComponent<Rigidbody2D>();
        directionRender = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        directionRender.SetPosition(0, transform.position);
        directionRender.SetPosition(1, InitialPos);
        
        if (BurdLaunched && rb.velocity.magnitude <= 0.1)
        {
            TimeIdle += Time.deltaTime;
        }
        
        if (transform.position.y > 9 ||
            transform.position.y < -9 ||
            transform.position.x > 10 ||
            transform.position.x < -15 ||
            TimeIdle >= TimeReset ||
            Input.GetKeyDown(KeyCode.Space))
        {
            string currentScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentScene);
        }
    }

    private void OnMouseDown()
    {
        CurrentColor = (Color.yellow);
        directionRender.enabled = true;
        InitialPos = transform.position;
    }

    private void OnMouseUp()
    {
        CurrentColor = (Color.white);
        //Launch the burd
        BurdLaunched = true;
        directionRender.enabled = false;
        Vector3 Direction = InitialPos - transform.position;
        rb.AddForce(Direction * LaunchForce);
        rb.gravityScale = 1;
    }

    private void OnMouseDrag()
    { 
        Vector3 NewPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(NewPos.x,NewPos.y,0);
    }
}
