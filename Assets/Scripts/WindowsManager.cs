using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsManager : MonoBehaviour
{
    [SerializeField] private GameObject[] windows;
    [SerializeField] private SpriteRenderer hint;

    public void StartFog()
    {
        StartCoroutine(FogAnimation(5f));
    }

    private System.Collections.IEnumerator FogAnimation(float time)
    {
        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            foreach (GameObject window in windows)
            {
                Color color = window.GetComponent<Renderer>().materials[1].color;
                color.a = Mathf.Lerp(0, 1, (elapsedTime / time));
                window.GetComponent<Renderer>().materials[1].color = color;
            }
            Color hintColor = hint.color;
            hintColor.a = Mathf.Lerp(0, 1, (elapsedTime / time));
            hint.color = hintColor;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
