using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public Text uiTimer;
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
        uiTimer.text = timer.ToString("f1");
            if (timer < 0)
            {
                TimerFinised();
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
