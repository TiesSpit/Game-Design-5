using UnityEngine;

public class TimeManager : MonoBehaviour
{

    [SerializeField] private float timePassed;
    [SerializeField] private float totalTime;
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    private void FixedUpdate()
    {
        timePassed += Time.fixedDeltaTime;
        CheckTime();
    }

    private void CheckTime()
    {
        if (timePassed > totalTime)
        {
            Debug.Log("You won!");
        }
    }

    public float GetTimePassed() { return timePassed; }
}
