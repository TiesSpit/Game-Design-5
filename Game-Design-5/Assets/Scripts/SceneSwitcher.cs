using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{

    [SerializeField]
    private string sceneName;

    public static SceneSwitcher Instance;

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
    public void SwitchScene()
    {
        SwitchScene(sceneName);
    }
    public void SwitchScene(string pSceneName)
    {
        SceneManager.LoadScene(pSceneName);
    }
}
