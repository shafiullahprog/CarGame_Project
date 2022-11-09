using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarAndGunSelection : MonoBehaviour
{
    public Button previousBtn;
    public Button nextBtn;
    public int currentCar;
    public float currentTime;
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

    public void StoreCarValue()
    {
        PlayerPrefs.SetInt("CurrentCarNumber", this.currentCar);
    }

    public void StoreGunValue()
    {
        PlayerPrefs.SetInt("CurrentGunNumber", this.currentCar);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene("Loading");
    }

    public void Minute(int seconds)
    {
        currentTime = seconds;
        PlayerPrefs.SetFloat("TimeSetForGame", currentTime);
    }

}
