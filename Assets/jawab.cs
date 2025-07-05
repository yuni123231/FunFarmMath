using UnityEngine;

public class jawab : MonoBehaviour
{
    public GameObject feed_benar;
    public GameObject feed_salah;

    public void PilihJawaban(bool isCorrect)
    {
        if (isCorrect)
        {
            feed_benar.SetActive(true);
            feed_salah.SetActive(false);

            // Tambah 1 koin
            int currentKoin = PlayerPrefs.GetInt("koin", 0);
            PlayerPrefs.SetInt("koin", currentKoin + 1);
            PlayerPrefs.Save();

            Debug.Log("Jawaban benar! Koin sekarang: " + (currentKoin + 1));
        }
        else
        {
            feed_benar.SetActive(false);
            feed_salah.SetActive(true);
        }
    }

    public void ResetFeedback()
    {
        feed_benar.SetActive(false);
        feed_salah.SetActive(false);
    }
}
