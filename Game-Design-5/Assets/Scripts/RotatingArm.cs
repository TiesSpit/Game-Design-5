using UnityEngine;

public class RotatingArm : MonoBehaviour
{
    public enum Rotation
    {
        left, middle, right
    }

    [Header("Settings")]
    [SerializeField] private float maxClockwiseRotation;
    [SerializeField] private float maxAntiClockwiseRotation;

    [Header("Debug")]
    [SerializeField] private float currentRotation;
    [SerializeField] private Rotation currentEnumRotation;


    public void LeftRotation()
    {
        SetRotation(Rotation.left);
    }
    public void MiddleRotation()
    {
        SetRotation(Rotation.middle);
    }
    public void RightRotation()
    {
        SetRotation(Rotation.right);
    }

    public void SetRotation(Rotation pRotation)
    {
        if (pRotation == currentEnumRotation) return;
        Rotate(pRotation);
    }


    private void Rotate(Rotation pRotation)
    {
        transform.RotateAround(transform.position, Vector3.forward, -currentRotation);
        currentRotation = GetRotationAmount(pRotation);
        currentEnumRotation = pRotation;
        transform.RotateAround(transform.position, Vector3.forward, currentRotation);

    }

    private float GetRotationAmount(Rotation pRotation)
    {
        switch (pRotation)
        {
            case Rotation.left: return maxClockwiseRotation;
            case Rotation.right: return maxAntiClockwiseRotation;
            default: return 0;
        }
    }

}
