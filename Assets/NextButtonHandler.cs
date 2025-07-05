using UnityEngine;
using UnityEngine.SceneManagement;

public class NextButtonHandler : MonoBehaviour
{
    public void GoToLevelScene()
    {
        // Ambil level kuis dari PlayerPrefs
        int level = PlayerPrefs.GetInt("level_kuis", 1); // default ke 1 jika tidak ada

        string sceneName = "level" + level;  // Contoh: level1, level2, dst.
        Debug.Log("Scene yang akan dibuka: " + sceneName);

        if (Application.CanStreamedLevelBeLoaded(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning("Scene tidak ditemukan atau belum dimasukkan ke Build Settings: " + sceneName);
        }
    }
}
