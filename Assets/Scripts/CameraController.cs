using System.Collections;
using System.Collections.Generic;
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

    private void Start()
    {
        //distance from car to camera
        offset = transform.position - Target.position;

        isLookAtOf = true;
    }

    private void Update()
    {       
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isLookAtOf = false;
            isOriginalPostion = true;

            //this.transform.rotation = Quaternion.Euler(0, 10f, 0);
            transform.LookAt(Target2);
            changeCamPos(cameraPos1);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            isOriginalPostion = true;
            changeCamPos(cameraPos2);
            isLookAtOf = true;

        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isOriginalPostion)
            {
                isLookAtOf = true;
                initialCameraPos = Target.position +  (Vector3.forward * -DistancefromCar) - (Vector3.up * HeightFromCar);
                originalCamPos.position = initialCameraPos;
                changeCamPos(originalCamPos);
                isOriginalPostion = false;
            }  
        }

        transform.position = offset + Target.position;
        if (isLookAtOf)
        {
            transform.LookAt(Target);
        }
    }
   
    void changeCamPos(Transform CameraPosition)
    {
        transform.position = CameraPosition.position;
        offset = transform.position - Target.position;
    }

}
