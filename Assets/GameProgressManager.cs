using UnityEngine;

public class GameProgressManager : MonoBehaviour
{
    public static GameProgressManager Instance;

    public int currentLevel = 0;
    public bool isAnswerCorrect = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Supaya tidak hilang saat pindah scene
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
