using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    private CameraController cameraController;
    private void Start()
    {
        cameraController = FindObjectOfType<CameraController>();
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

    public void changeCamera()
    {
        cameraController.incrementCamValue();
    }
}
