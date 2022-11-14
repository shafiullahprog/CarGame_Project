using Photon.Pun;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Target;
    public Transform Target2;
    private Vector3 offset;
    public Vector3 initialCameraPos;
    public Transform originalCamPos;
    public Transform cameraPos1;
    public Transform cameraPos2;
    public float DistancefromCar, HeightFromCar;
    bool isOriginalPostion = false;
    public bool isLookAtOf;
    PhotonView view;
    int currentCam = 1;
    private void Start()
    {
        view = GetComponent<PhotonView>();
        //distance from car to camera
        offset = transform.position - Target.position;
        isLookAtOf = true;
        SwitchCar(currentCam);
    }

    private void Update()
    {
        if (view.IsMine)
        {
            transform.position = offset + Target.position;
            if (isLookAtOf)
            {
                transform.LookAt(Target);
            }
        }
    }
   
    void changeCamPos(Transform CameraPosition)
    {
        transform.position = CameraPosition.position;
        offset = transform.position - Target.position;
    }

    public void incrementCamValue()
    {
        currentCam++;
        SwitchCar(currentCam);
        if (currentCam >= 3)
        {
            currentCam = 0;
        }
    }

    void SwitchCar(int camChanger)
    {
        switch (camChanger)
        {
            case 1:
                isLookAtOf = false;
                isOriginalPostion = true;
                transform.LookAt(Target2);
                changeCamPos(cameraPos1);
            break;

            case 2:
                isOriginalPostion = true;
                changeCamPos(cameraPos2);
                isLookAtOf = true;
                break;

            case 3:
                if (isOriginalPostion)
                {
                    isLookAtOf = true;
                    initialCameraPos = Target.position + (Vector3.forward * -DistancefromCar) - (Vector3.up * HeightFromCar);
                    originalCamPos.position = initialCameraPos;
                    changeCamPos(originalCamPos);
                    isOriginalPostion = false;
                }
            break;
        }
    }
}
