using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class EndGame : MonoBehaviour
{
    [SerializeField] private int numberOfKeys = 0;
    [SerializeField] private GameObject textLabel;
    [SerializeField] private GameObject timerLabel;
    [SerializeField] private GameObject endTimerLabel;

    [SerializeField] float timer = 5f;

    [SerializeField] UnityEvent onEndGame;

    [SerializeField] private float gameTime;
    [SerializeField] private string[] bestTimes = new string[3];

    private float endTime = 0f;

    private void Start()
    {
        for (int i = 0; i < bestTimes.Length; i++)
        {
            bestTimes[i] = PlayerPrefs.GetString("BestTime" + i, "0");
            Debug.Log("Best time " + i + ": " + bestTimes[i]);
        }
    }

    private void Update()
    {
        if (numberOfKeys < 3) {
            gameTime += Time.deltaTime;
        }
    }

    public void addKey()
    {
        numberOfKeys++;
        if (numberOfKeys == 3)
        {
            endTime = gameTime;
            textLabel.SetActive(true);
            timerLabel.SetActive(true);
            endTimerLabel.SetActive(true);

            SaveTimeIfNeeded(endTime);

            int hours = Mathf.FloorToInt(endTime / 3600);
            int minutes = Mathf.FloorToInt((endTime % 3600) / 60);
            int seconds = Mathf.FloorToInt((endTime % 3600) % 60);
            string timeString = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);

            endTimerLabel.GetComponent<TMP_Text>().text = timeString;
            onEndGame.Invoke();
            StartCoroutine(StartTimer(timer));
        }
    }

    private void SaveTimeIfNeeded(float endTime)
    {
        for (int i = 0; i < bestTimes.Length; i++)
        {
            if (endTime < float.Parse(bestTimes[i]) || float.Parse(bestTimes[i]) == 0)
            {
                for (int j = bestTimes.Length - 1; j > i; j--)
                {
                    bestTimes[j] = bestTimes[j - 1];
                }
                bestTimes[i] = endTime.ToString();
                break;
            }
        }
        for (int i = 0; i < bestTimes.Length; i++)
        {
            Debug.Log("Best time " + i + ": " + bestTimes[i]);
            PlayerPrefs.SetString("BestTime" + i, bestTimes[i]);
        }
    }

    IEnumerator StartTimer(float timer)
    {
        while (timer > 0)
        {
            yield return new WaitForSeconds(1.0f);
            timer--;
            timerLabel.GetComponent<TMP_Text>().text = timer.ToString();
        }
        SceneManager.LoadScene("Menu");
    }

}
