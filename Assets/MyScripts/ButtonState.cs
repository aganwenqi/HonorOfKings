using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
public class ButtonState : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public UnityEvent OnDown;
    public UnityEvent OnUp;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (OnDown != null)
            OnDown.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (OnUp != null)
            OnUp.Invoke();
    }
}
