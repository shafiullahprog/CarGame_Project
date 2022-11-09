using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    private void Start()
    {
        //getCarNum = PlayerPrefs.GetInt("CurrentCarNumber");
        //getGunNum = PlayerPrefs.GetInt("CurrentGunNumber");

        //GameObject car = Instantiate(Car[getCarNum]);
        //car.transform.parent = spawnCarPosition.transform;
        //car.transform.position = transform.position;

        //GameObject gun = Instantiate(Gun[getGunNum]);
        //gun.transform.parent = car.transform;
        //gun.transform.position = gunSpwanPosition;

        //spawnCarPosition.playerPrefab = car;
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        PauseGame();
        gameOverScreen.SetActive(true);
    }
}
