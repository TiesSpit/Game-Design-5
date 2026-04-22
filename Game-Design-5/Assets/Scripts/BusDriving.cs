using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class BusDriving : MonoBehaviour
{
    private Quaternion originalRotation;

    [SerializeField] private float speed;
    [SerializeField] private float steeringSpeed;   // Degrees per second
    [SerializeField] private float driftSpeed;      // Degrees per second

    // Update is called once per frame
    void Update()
    {
        AutoDrive();
        StandartDrift();

        Steering();
    }

    private void Steering()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, steeringSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -steeringSpeed * Time.deltaTime, 0);
        }
    }

    private void AutoDrive()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void StandartDrift()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)) return;
        transform.Rotate(0, driftSpeed * Time.deltaTime, 0);
    }
}
