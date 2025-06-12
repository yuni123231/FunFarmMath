using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    // Array untuk menampung semua GameObject soal (soal(1), soal(2), dst.)
    public GameObject[] soalObjects;

    // Panel Kuis (parent dari semua soal)
    public GameObject kuisPanel;

    // Panel SelectLevel (halaman pemilihan level)
    public GameObject selectLevelPanel;

    // Fungsi yang dipanggil ketika level dipilih
    public void SelectLevel(int levelIndex)
    {
        // Aktifkan panel Kuis
        if (kuisPanel != null)
            kuisPanel.SetActive(true);

        // Nonaktifkan semua soal terlebih dahulu
        foreach (GameObject soal in soalObjects)
        {
            if (soal != null)
                soal.SetActive(false);
        }

        // Aktifkan soal yang sesuai level
        if (levelIndex >= 0 && levelIndex < soalObjects.Length)
        {
            if (soalObjects[levelIndex] != null)
                soalObjects[levelIndex].SetActive(true);
        }

        // Sembunyikan panel SelectLevel
        if (selectLevelPanel != null)
            selectLevelPanel.SetActive(false);
    }
}
