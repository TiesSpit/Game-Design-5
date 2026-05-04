using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class BusDriving : MonoBehaviour
{
    private Quaternion originalRotation;

    [SerializeField] private float speed;
    [SerializeField] private float steeringSpeed;   // Degrees per second
    [SerializeField] private float driftSpeed;      // Degrees per second

    [Header("Controls")]
    [SerializeField] private KeyCode leftButton = KeyCode.A;
    [SerializeField] private KeyCode rightButton = KeyCode.D;

    // Update is called once per frame
    void Update()
    {
        AutoDrive();
        StandartDrift();

        Steering();
    }

    private void Steering()
    {
        bool isSteering = false;
        if (Input.GetKey(rightButton))
        {
            transform.Rotate(0, steeringSpeed * Time.deltaTime, 0);
            RotatingArm.Instance?.RightRotation();
            isSteering = true;
        }
        if (Input.GetKey(leftButton))
        {
            transform.Rotate(0, -steeringSpeed * Time.deltaTime, 0);
            RotatingArm.Instance?.LeftRotation();
            isSteering = true;
        }

        if (!isSteering) RotatingArm.Instance?.MiddleRotation();
    }

    private void AutoDrive()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void StandartDrift()
    {
        if (Input.GetKey(rightButton) || Input.GetKey(leftButton)) return;
        transform.Rotate(0, driftSpeed * Time.deltaTime, 0);
    }
}
