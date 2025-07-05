using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    public GameObject[] soalObjects;
    public GameObject kuisPanel;
    public GameObject selectLevelPanel;

    public void SelectLevel(int levelIndex)
    {
        if (kuisPanel != null)
            kuisPanel.SetActive(true);

        foreach (GameObject soal in soalObjects)
        {
            if (soal != null)
                soal.SetActive(false);
        }

        if (levelIndex >= 0 && levelIndex < soalObjects.Length)
        {
            if (soalObjects[levelIndex] != null)
                soalObjects[levelIndex].SetActive(true);
        }

        if (selectLevelPanel != null)
            selectLevelPanel.SetActive(false);

        // ? Simpan level yang sedang dikerjakan
        int currentLevel = levelIndex + 1;
        PlayerPrefs.SetInt("level_kuis", currentLevel);
        PlayerPrefs.Save();

        Debug.Log("Level yang dipilih dan disimpan: " + currentLevel);
    }
}
