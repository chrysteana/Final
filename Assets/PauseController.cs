using UnityEngine;

public class PauseController : MonoBehaviour
{
    public static PauseController Instance { get; private set; }

    public bool IsGamePaused { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional, keeps it alive between scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetPause(bool pause)
    {
        IsGamePaused = pause;
        Time.timeScale = pause ? 0 : 1;
    }
}
