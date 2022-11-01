using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float moveInput, turnInput;
    public float fwdSpeed, revSpeed, turnSpeed;
    public Rigidbody spearRigidbody;
    public LayerMask groundLayer;
    private bool isCarGrounded;

    public float airDrag;
    public float groundDrag;
    private void Start()
    {
        spearRigidbody.transform.parent = null;
    }
    private void Update()
    {
        moveInput = Input.GetAxisRaw("Vertical");
        turnInput = Input.GetAxisRaw("Horizontal");
        moveInput *=  moveInput > 0 ? fwdSpeed : revSpeed; //if else condition for forward and backward direction

        float newCarRotation = turnInput * turnSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical");
        transform.Rotate(0, newCarRotation, 0, Space.World);

        //set car pos to spear
        transform.position = spearRigidbody.transform.position;

        RaycastHit hit;
        isCarGrounded = Physics.Raycast(transform.position, -transform.up, out hit, 1f, groundLayer);

        transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;

        if (isCarGrounded)
        {
            spearRigidbody.drag = groundDrag;
        }
        else
        {
            spearRigidbody.drag = airDrag;
        }
    }

    private void FixedUpdate()
    {
        if (isCarGrounded)
        {
            spearRigidbody.AddForce(transform.forward * moveInput, ForceMode.Acceleration);
        }
        else
        {
            spearRigidbody.AddForce(transform.up * 30f);
        }
    }
}
