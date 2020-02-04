using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    private static int _LevelIndex = 1;
    private Enemy[] _enemies;
    public Burd[] MyBurds;
    public int DeadBurd = 0;

    public TMP_Text LevelNumberDisplay;

    private void OnEnable()
    {
        _enemies = FindObjectsOfType<Enemy>();
    }
    private void Start()
    {
        InitBurd();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayCurrentLv();
        LoadNextBurd();
        if (DeadBurd == 2 && MyBurds[MyBurds.Length-1].TimeIdle >= MyBurds[MyBurds.Length-1].TimeReset)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
        foreach (Enemy enemy in _enemies)
        {
            if (enemy != null)
            {
                return;
            }
        }
        Debug.Log("All enemies are dead");
        if (_LevelIndex <= 1)
        {
            _LevelIndex++;
        }
        string NextLevelName = "LV" + _LevelIndex;
        SceneManager.LoadScene(NextLevelName);
    }

    private void LoadNextBurd()
    {
        for (int i = 0; i < MyBurds.Length; i++)
        {
            if (MyBurds[i].TimeIdle >= MyBurds[i].TimeReset && DeadBurd < 2)
            {
                MyBurds[i].enabled = false;
                MyBurds[i].gameObject.SetActive(false);
                MyBurds[i + 1].gameObject.SetActive(true);
            }
        }
    }

    private void InitBurd()
    {
        for (int i = 1; i < MyBurds.Length; i++)
        {
            MyBurds[i].gameObject.SetActive(false);
        }
    }

    private void DisplayCurrentLv()
    {
        LevelNumberDisplay.text = "Level " + _LevelIndex.ToString();
    }
}
