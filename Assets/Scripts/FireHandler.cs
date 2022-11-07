using UnityEngine.EventSystems;
using UnityEngine;

public class FireHandler : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{

    public bool shoot;
    public void OnPointerDown(PointerEventData eventData)
    {
        shoot = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        shoot = false;
    }
}
