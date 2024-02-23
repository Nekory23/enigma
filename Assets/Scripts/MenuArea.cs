using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuArea : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text[] bestTimeLabels = new TMPro.TMP_Text[3];
    private void Start()
    {
        RefreshBestScore();
    }

    public void RefreshBestScore()
    {
        for (int i = 0; i < 3; i++)
        {
            string bestTime = PlayerPrefs.GetString("BestTime" + i, "0");
            
            Debug.Log("Best time " + i + ": " + bestTime);
            int hours = Mathf.FloorToInt(float.Parse(bestTime) / 3600);
            int minutes = Mathf.FloorToInt((float.Parse(bestTime) % 3600) / 60);
            int seconds = Mathf.FloorToInt((float.Parse(bestTime) % 3600) % 60);
            string timeString = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
            bestTimeLabels[i].text = timeString;
        }
    }

    public void ResetBestScore()
    {
        for (int i = 0; i < 3; i++)
        {
            PlayerPrefs.SetString("BestTime" + i, "0");
        }
        RefreshBestScore();
    }

    public void Play()
    {
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("Main");
    }
}
