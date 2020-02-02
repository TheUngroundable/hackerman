﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public Text uiTimer;
    public Text uiCounter;
    public Text addTimer;
    public float timer = 20;

    private static TimeManager _instance;
    public static TimeManager Instance { get { return _instance; } }
    private void Awake()
    {
        if (_instance != null && _instance != this) Destroy(this.gameObject);
        else _instance = this;
    }


    private void Start()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (TileManager.Instance.rooms.Count > 1)
        { 
        timer -= Time.deltaTime;
            if (timer < 0)
            {
                TimerFinised();
                uiTimer.text = "GAME OVER";
                GameManager.Instance.PlayGameOverSong();
            } else {
                uiTimer.text = timer.ToString("f1")+" SECONDS LEFT";
            }
        }
    }

    public void AddTimer(float addTime)
    {
        timer += addTime;
        addTimer.gameObject.SetActive(true);
        addTimer.text = "+" + addTime.ToString();
        StartCoroutine(AddUiScore(addTime));
    }

    public void UpdateCounter(int counter){
        uiCounter.text = counter+" COMPUTERS REPAIRED";
    }

    public IEnumerator AddUiScore(float time)
    {
        yield return new WaitForSeconds(1);
        addTimer.gameObject.SetActive(false);
    }

    public void TimerFinised()
    {
        Time.timeScale = 0;
    }
}
