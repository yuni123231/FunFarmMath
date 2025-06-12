using UnityEngine;
using UnityEngine.SceneManagement; // Untuk load main menu

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
            pauseMenuUI.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            pauseMenuUI.SetActive(false);
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f; // Pastikan waktu normal lagi sebelum berpindah scene
        SceneManager.LoadScene("MainMenu"); // Ganti dengan nama scene Main Menu kamu
    }
}
