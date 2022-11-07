using UnityEngine.UI;
using UnityEngine;

public class CarSelection : MonoBehaviour
{
    public Button previousBtn;
    public Button nextBtn;
    public int currentCar;

    private void Start()
    {  
        SelectCar(0);
    }
    void SelectCar(int _index)
    {
        previousBtn.interactable = (_index != 0);
        nextBtn.interactable = (_index != transform.childCount - 1);
        for(int i=0; i<transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == _index);
        }
    }

    public void changeCar(int _change)
    {
        currentCar += _change;
        SelectCar(currentCar);
    }
}
