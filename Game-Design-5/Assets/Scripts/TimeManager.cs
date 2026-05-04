using UnityEngine;

public class TimeManager : MonoBehaviour
{

    [SerializeField] private float timePassed;
    [SerializeField] private float totalTime;

    [SerializeField] private string winSceneName = "WinScene";
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    private void FixedUpdate()
    {
        if (GameOver.Instance != null)
        {
            if (GameOver.Instance.IsGameOver()) return;
        }
        timePassed += Time.fixedDeltaTime;
        CheckTime();
    }

    private void CheckTime()
    {
        if (timePassed > totalTime)
        {
            SceneSwitcher.Instance?.SwitchScene(winSceneName);
            Debug.Log("You won!");
        }
    }

    public float GetTimePassed() { return timePassed; }
}
