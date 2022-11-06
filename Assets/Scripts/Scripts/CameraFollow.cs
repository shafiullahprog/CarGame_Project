using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public float followSpeed = 2;
	public float lookSpeed = 5;

	[Space(10)]
	public Transform CameraPos;
	public Transform CameraPos1;
	public Transform CameraPos2;
	public Transform CarPosition;

	Vector3 initialCameraPosition;
	Vector3 initialCarPosition;
	Vector3 Offset;
	Vector3 absolutePreviousPosition;

	private int currentTarget;
    private Vector3 dist;
    public float sSpeed;

    void Start()
	{
		currentTarget = 1;
		SetCameraTarget(currentTarget);
		setCamera();
	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
			SwitchCamera();
        }
    }
    void FixedUpdate()
	{
		FollowingCar();
	}
	void setCamera()
    {
		initialCameraPosition = gameObject.transform.position;
		initialCarPosition = CarPosition.position;
		Offset = initialCameraPosition - initialCarPosition;
		//absolutePreviousPosition = absoluteInitCameraPosition;
	}
	public void SetCameraTarget(int num)
	{
		switch (num)
		{
			case 1:
				CameraPos = Camera.main.transform;
				break;
			case 2:
				CameraPos = CameraPos1.transform;
				break;
			case 3:
				CameraPos = CameraPos2.transform;
				break;
		}
	}

	public void SwitchCamera()
	{
		if (currentTarget < 3)
			currentTarget++;
		else
			currentTarget = 1;
		SetCameraTarget(currentTarget);
	}

	void FollowingCar()
    {
		//Vector3 currentCameraPos = CameraPos.position + Offset;

		//Look at car
		//transform.LookAt(CameraPos);
		//Move to car
		//transform.position = Offset + CameraPos.position;


		Vector3 dPos = CameraPos.position + dist;
		Vector3 sPos = Vector3.Lerp(transform.position, dPos, sSpeed * Time.deltaTime);
		transform.position = sPos;
		transform.LookAt(CarPosition.position);
	}
}
