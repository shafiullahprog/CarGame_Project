using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform carTransform;
	public float followSpeed = 2;
	public float lookSpeed = 5;

	[Space(10)]
	public Transform CameraPos1;
	public Transform cameraPos2;
	public Transform cameraPos3;

	Vector3 initialCameraPosition;
	Vector3 initialCarPosition;
	Vector3 absoluteInitCameraPosition;
	Vector3 absolutePreviousPosition;

	//Transform absoluteInitCameraPosition;
	void Start(){
		initialCameraPosition = gameObject.transform.position;
		initialCarPosition = carTransform.position;
		absoluteInitCameraPosition = initialCameraPosition - initialCarPosition;
		absolutePreviousPosition = absoluteInitCameraPosition;
	}


    private void Update()
	{ 
		ChangeCamPosition();
	}
    void FixedUpdate()
	{     
		FollowingCar();
	}

	void FollowingCar()
    {
		//Look at car
		Vector3 _lookDirection = (new Vector3(carTransform.position.x, carTransform.position.y, carTransform.position.z)) - transform.position;
		Quaternion _rot = Quaternion.LookRotation(_lookDirection, Vector3.up);
		transform.rotation = Quaternion.Lerp(transform.rotation, _rot, lookSpeed * Time.deltaTime);

		//Move to car
		Vector3 _targetPos = absoluteInitCameraPosition + carTransform.transform.position;
		transform.position = Vector3.Lerp(transform.position, _targetPos, followSpeed * Time.deltaTime);
	}

	void ChangeCamPosition()
	{
		if (Input.GetKeyDown(KeyCode.Q))
		{
			//absoluteInitCameraPosition = driverCamPos.position;
		}
        else if(Input.GetKeyDown(KeyCode.O))
        {
			absoluteInitCameraPosition = absolutePreviousPosition;

		}
	}

}
