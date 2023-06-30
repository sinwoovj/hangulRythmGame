using System.Collections;
using UnityEngine;

public class SlidePanel : MonoBehaviour
{
    private IEnumerator currentCoroutine;

    public Transform startPosition;
    public Transform endPosition;
    public GameObject SlidePanelArrow;

    public float lerpTime = 0.5f;
    private float currentTime = 0;
    private bool isOpen = true;

    private void Start()
    {
        this.transform.position = startPosition.position;
    }

    public void SlidePanelFunc()
    {
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }

        if (isOpen)
        {
            currentTime = 0;
            currentCoroutine = CloseSlidePanel();
        }
        else
        {
            currentTime = 0;
            currentCoroutine = OpenSlidePanel();
        }

        StartCoroutine(currentCoroutine);
    }

    private IEnumerator OpenSlidePanel()
    {
        isOpen = true;

        while (currentTime < lerpTime)
        {
            currentTime += Time.deltaTime;

            float t = Mathf.SmoothStep(0, 1, currentTime / lerpTime);
            this.transform.position = Vector3.Lerp(endPosition.position, startPosition.position, t);

            yield return null;
        }

        this.transform.position = startPosition.position;
        currentCoroutine = null;
    }

    private IEnumerator CloseSlidePanel()
    {
        isOpen = false;

        while (currentTime < lerpTime)
        {
            currentTime += Time.deltaTime;

            float t = Mathf.SmoothStep(0, 1, currentTime / lerpTime);
            this.transform.position = Vector3.Lerp(startPosition.position, endPosition.position, t);

            yield return null;
        }

        this.transform.position = endPosition.position;
        currentCoroutine = null;
    }
}
