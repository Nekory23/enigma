using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScreen : MonoBehaviour
{
    public bool fadeOutOnStart = true;
    public float fadeDuration = 2f;
    public Color fadeColor;
    private Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        if (fadeOutOnStart)
        {
            FadeOut();
        }
    }

    public void FadeIn()
    {
        GetComponent<MeshRenderer>().enabled = true;
        Fade(0f, 1f);
    }

    public void FadeOut()
    {
        Fade(1f, 0f);
    }

    public void Fade(float alphaIn, float alphaOut)
    {
        StartCoroutine(FadeAnimation(alphaIn, alphaOut));
    }

    public IEnumerator FadeAnimation(float alphaIn, float alphaOut)
    {
        float t = 0f;
        while (t <= fadeDuration)
        {
            Color newColor = fadeColor;
            newColor.a = Mathf.Lerp(alphaIn, alphaOut, t / fadeDuration);
            rend.material.SetColor("_Color", newColor);

            t += Time.deltaTime;
            yield return null;
        }
        Color finalColor = fadeColor;
        finalColor.a = alphaOut;
        rend.material.SetColor("_Color", finalColor);
        if (alphaOut == 0f)
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
