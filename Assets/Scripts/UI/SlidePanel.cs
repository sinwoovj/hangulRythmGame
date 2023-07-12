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
        if (currentCoroutine != null) StopCoroutine(currentCoroutine);
        currentTime = 0;
        currentCoroutine = SlidePanelCoroutine(!isOpen);
        isOpen = !isOpen;
        StartCoroutine(currentCoroutine);
    }

    private IEnumerator SlidePanelCoroutine(bool isopen)
    {
        Vector3 ed = endPosition.position;
        Vector3 st = startPosition.position;

        while (currentTime <= lerpTime)
        {
            currentTime += Time.deltaTime;
            float t = Mathf.SmoothStep(0, 1, currentTime / lerpTime);
            this.transform.position = Vector3.Lerp(isopen ? ed : st, isopen ? st : ed, t);
            SlidePanelArrow.transform.rotation = Quaternion.Euler(new Vector3(0,0,isopen ? 180-180*t : 180*t));
            yield return null;
        }
        this.transform.position = isopen ? st : ed;
        currentCoroutine = null;
    }
}