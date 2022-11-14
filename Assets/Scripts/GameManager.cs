using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    private CameraController cameraController;
    //private AudioListener[] audioListener;
    private void Start()
    {
        cameraController = FindObjectOfType<CameraController>();
       //for(int i=0; i<audioListener.Length; i++)
       // {
       //     audioListener[i] = FindObjectOfType<AudioListener>();
       // }
       // if(audioListener.Length >= 1)
       // {
       //     Destroy(audioListener[1]);
       // }
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
        //PauseGame();
        //gameOverScreen.SetActive(true);
    }

    public void changeCamera()
    {
        cameraController.incrementCamValue();
    }
}
