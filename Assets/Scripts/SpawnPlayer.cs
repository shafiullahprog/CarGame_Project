using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] private GameObject[] Car;
    [SerializeField] private GameObject[] Gun;
    int getCarNum;
    int getGunNum;
    float timer;
    public Text timerText;
    Vector3 gunSpwanPosition = new Vector3(0, 0.7f, 1.6f);
    public float minX, maxX, minZ, maxZ;
    bool IsGameOver;


    private void Start()
    {
        Vector3 randomSpawnPostion = new Vector3(Random.Range(minX, maxX), 0, Random.Range(minZ, maxZ));
        
        getCarNum = PlayerPrefs.GetInt("CurrentCarNumber");
        getGunNum = PlayerPrefs.GetInt("CurrentGunNumber");
        timer = PlayerPrefs.GetFloat("TimeSetForGame");
        var car = PhotonNetwork.Instantiate(Car[getCarNum].name , randomSpawnPostion, Quaternion.identity);
        car.transform.parent = this.transform;
        car.transform.position = randomSpawnPostion;

        GameObject gun = Instantiate(Gun[getGunNum]);
        gun.transform.parent = car.transform;
        gun.transform.position = car.transform.position + new Vector3(0, 0.7f, 1.5f);
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            IsGameOver = true;
        }

        if (IsGameOver)
        {
            FindObjectOfType<GameManager>().GameOver();
        }
        var ts = System.TimeSpan.FromSeconds(timer);
        timerText.text = string.Format("{0:00}:{1:00}", ts.TotalMinutes, ts.Seconds);
    }

}
