using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnMouseOverButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler{

    public GameObject Soul1;
    public GameObject Soul2;

    private void Start()
    {
        Soul1.SetActive(false);
        Soul2.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Soul1.SetActive(true);
        Soul2.SetActive(true);

    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        Soul1.SetActive(false);
        Soul2.SetActive(false);
    }
}
