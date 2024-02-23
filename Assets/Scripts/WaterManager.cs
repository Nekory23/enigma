using UnityEngine;
using UnityEngine.Events;

public class WaterManager : MonoBehaviour
{
    [SerializeField] GameObject[] watersChildren;
    [SerializeField] GameObject waterParent;
    [SerializeField] Transform TopWaterPosition;
    [SerializeField] Transform BottomWaterPosition;

    [SerializeField] UnityEvent onSuccess;

    private bool isBathTubEmpty = false;

    public void CleanBathTub()
    {
        if (isBathTubEmpty == true)
        {
            return;
        }
        isBathTubEmpty = true;
        StartCoroutine(WaterAnimation(5f, TopWaterPosition.position, BottomWaterPosition.position, false));
    }

    public void FillBathTub()
    {
        if (isBathTubEmpty == false)
        {
            return;
        }
        isBathTubEmpty = false;
        waterParent.gameObject.SetActive(true);
        foreach (GameObject water in watersChildren)
        {
            ChangeMaterial changeMaterial = water.GetComponent<ChangeMaterial>();
            changeMaterial.SetOtherMaterial();
        }
        StartCoroutine(WaterAnimation(5f, BottomWaterPosition.position, TopWaterPosition.position, true));
        onSuccess.Invoke();
    }

    private System.Collections.IEnumerator WaterAnimation(float time, Vector3 startingPos, Vector3 finalPos, bool isActive)
    {
        float elapsedTime = 0;
         
        while (elapsedTime < time)
        {
            waterParent.transform.position = Vector3.Lerp(startingPos, finalPos, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        waterParent.transform.position = finalPos;
        waterParent.gameObject.SetActive(isActive);
    }

    public void OnWaterWheelValueChanged(float value)
    {
        if (value >= 3f && isBathTubEmpty == true)
        {
            FillBathTub();
        }
    }
}
