using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BrakeButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static CarController Car;

    public void OnPointerDown(PointerEventData eventData)
    {
        Car.Brake(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Car.Brake(false);
    }
}
