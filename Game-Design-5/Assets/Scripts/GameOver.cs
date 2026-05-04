using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private bool isGameOver;

    [SerializeField]
    private GameObject crackedGlass;

    public static GameOver Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    public void DoGameOver()
    {
        crackedGlass.SetActive(true);
        isGameOver = true;
    }

    public bool IsGameOver() { return isGameOver; }
}
