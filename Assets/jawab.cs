using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jawab : MonoBehaviour
{
    public GameObject feed_benar;   // Panel feedback benar
    public GameObject feed_salah;   // Panel feedback salah

    // Fungsi ini dipanggil ketika tombol jawaban diklik
    // Parameter isCorrect bernilai true jika jawaban benar
    public void PilihJawaban(bool isCorrect)
    {
        if (isCorrect)
        {
            feed_benar.SetActive(true);
            feed_salah.SetActive(false);
        }
        else
        {
            feed_benar.SetActive(false);
            feed_salah.SetActive(true);
        }

        // Feedback tidak otomatis hilang
        // Kamu bisa menambahkan tombol "Lanjut" untuk menyembunyikannya atau lanjut ke soal berikut
    }

    // Fungsi opsional untuk menyembunyikan feedback jika dibutuhkan manual lewat tombol
    public void ResetFeedback()
    {
        feed_benar.SetActive(false);
        feed_salah.SetActive(false);
    }
}
