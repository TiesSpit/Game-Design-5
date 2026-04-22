using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class BusDriving : MonoBehaviour
{
    private Quaternion originalRotation;

    [SerializeField] private float speed;
    [SerializeField] private float steeringSpeed;
    [SerializeField] private float driftSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        AutoDrive();
        StandertDrift();

        var maxRotation = Quaternion.Euler(0, 40, 0);
        var rotation = maxRotation.eulerAngles;

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(rotation * steeringSpeed * Time.deltaTime);            
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-rotation * steeringSpeed * Time.deltaTime);
        }
    }

    private void AutoDrive()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void StandertDrift()
    {
        var maxRotation = Quaternion.Euler(0, 20, 0);
        var rotation = maxRotation.eulerAngles;
        transform.Rotate(rotation * driftSpeed * Time.deltaTime);
    }
}
