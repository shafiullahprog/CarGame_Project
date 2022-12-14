using UnityEngine;

public class CarAminForSelection : MonoBehaviour
{
    private Touch touch;
    private Vector2 touchPosition;
    private Quaternion rotationY;
    public float force = 0.2f;

    [SerializeField] private Vector3 finalPosition;
    Vector3 initialPos;
    private void Start()
    {
        initialPos = transform.position;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, finalPosition, 0.1f);
        RotateCar();
    }

    void RotateCar()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
        }

        if(touch.phase == TouchPhase.Moved)
        {
            rotationY = Quaternion.Euler(0f, -touch.deltaPosition.x * force, 0f);
        }

        transform.rotation = rotationY * transform.rotation;
    }
    private void OnDisable()
    {
        transform.position = initialPos;
    }
}
