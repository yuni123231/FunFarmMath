using UnityEngine;
using UnityEngine.UI;

public class KoinManager : MonoBehaviour
{
    public Text koinText;

    void Start()
    {
        int jumlahKoin = PlayerPrefs.GetInt("koin", 0);
        koinText.text = "Koin: " + jumlahKoin;
    }

    void Update()
    {
        // Opsional: update terus koin di UI
        int jumlahKoin = PlayerPrefs.GetInt("koin", 0);
        koinText.text = "Koin: " + jumlahKoin;
    }
}
