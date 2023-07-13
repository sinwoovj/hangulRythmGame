using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class HoverSlide : MonoBehaviour
    , IPointerEnterHandler
    , IPointerExitHandler
{
    public GameObject MainMenuButtons;

    private IEnumerator currentCoroutine;

    public Vector3 mainUIStartPosition;
    public Vector3 mainUIEndPosition;

    public float mainUILerpTime = 0.3f;
    private float currentTime = 0;

    private void Start()
    {
        this.transform.position = mainUIStartPosition;
    }

    private IEnumerator HoverSlideCoroutine(bool isopen)
    {
        Vector3 ed = mainUIEndPosition;
        Vector3 st = mainUIStartPosition;

        while (currentTime <= mainUILerpTime)
        {
            currentTime += Time.deltaTime;
            float t = Mathf.SmoothStep(0, 1, currentTime / mainUILerpTime);
            this.transform.position = Vector3.Lerp(isopen ? ed : st, isopen ? st : ed, t);
            yield return null;
        }
        this.transform.position = isopen ? st : ed;
        currentCoroutine = null;
    }

    // 열림
    public void OnPointerEnter(PointerEventData eventData) {
        Debug.Log("Enter");
        if (currentCoroutine != null) StopCoroutine(currentCoroutine);
        currentTime = 0;
        currentCoroutine = HoverSlideCoroutine(false);
        StartCoroutine(currentCoroutine);
    }

    // 닫힘
    public void OnPointerExit(PointerEventData eventData) {
        Debug.Log("Exit");
        if (currentCoroutine != null) StopCoroutine(currentCoroutine);
        currentTime = 0;
        currentCoroutine = HoverSlideCoroutine(true);
        StartCoroutine(currentCoroutine);
        MainMenuButtons.GetComponent<MainMenuButtons>().ButtonInactivity();
    }
}
