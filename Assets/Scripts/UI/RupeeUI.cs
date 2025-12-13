using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RupeeUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI rupeeText;
    private readonly float timeBetweenCountUpdates = 0.1f;
    private int currentCount = 0;
    private IEnumerator coroutine; 

    public void RupeeCounter()
    {
        coroutine = UpdateCount();
        StartCoroutine(coroutine);
    }

    private IEnumerator UpdateCount()
    {
        while(currentCount != RupeeManager.Instance.RupeeCount)
        {
            currentCount += currentCount < RupeeManager.Instance.RupeeCount ? 1 : -1;
            rupeeText.text = currentCount.ToString();
            Debug.Log("hereo" + currentCount);
            yield return new WaitForSeconds(timeBetweenCountUpdates);
        }
    }
}
