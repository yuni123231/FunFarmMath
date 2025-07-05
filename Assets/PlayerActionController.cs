using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerActionController : MonoBehaviour
{
    public GameObject bibitPrefab;           // Prefab bibit
    public GameObject tanamanPrefab;         // Prefab tanaman jadi
    public Grid grid;                        // Grid tempat menanam
    public GameObject tanahTanamObject;      // GameObject area tanam (pakai Renderer atau Collider)
    public Tilemap tilemapBlokir;            // Tilemap yang tidak boleh ditanami (jalan/tengah ladang)

    private Dictionary<Vector3Int, GameObject> tanamanGrid = new Dictionary<Vector3Int, GameObject>();
    private Dictionary<Vector3Int, bool> siapPanen = new Dictionary<Vector3Int, bool>();

    public void TanamBibit()
    {
        // Ambil posisi tile dari bawah kaki player
        Vector3Int cellPos = grid.WorldToCell(transform.position + new Vector3(0, -0.5f, 0));
        Vector3 worldPos = grid.GetCellCenterWorld(cellPos);

        // Cek apakah posisi berada di area tanahTanam
        Bounds bounds = tanahTanamObject.GetComponent<Renderer>().bounds;
        if (!bounds.Contains(worldPos))
        {
            Debug.Log("Bukan area tanahTanam.");
            return;
        }

        // Cek apakah ada tile di tilemapBlokir (misalnya jalan) ? tidak boleh tanam di sini
        if (tilemapBlokir.HasTile(cellPos))
        {
            Debug.Log("Tidak boleh tanam di tilemapBlokir.");
            return;
        }

        // Cek apakah sudah ada tanaman di posisi ini
        if (tanamanGrid.ContainsKey(cellPos))
        {
            Debug.Log("Sudah ada tanaman di sini.");
            return;
        }

        // Tanam bibit
        GameObject bibit = Instantiate(bibitPrefab, worldPos, Quaternion.identity);
        tanamanGrid[cellPos] = bibit;
        siapPanen[cellPos] = false;

        // Mulai tumbuh
        StartCoroutine(TumbuhkanTanaman(cellPos));
    }

    IEnumerator TumbuhkanTanaman(Vector3Int cellPos)
    {
        yield return new WaitForSeconds(5f);

        if (tanamanGrid.ContainsKey(cellPos))
        {
            Destroy(tanamanGrid[cellPos]);
            Vector3 worldPos = grid.GetCellCenterWorld(cellPos);
            GameObject tanaman = Instantiate(tanamanPrefab, worldPos, Quaternion.identity);
            tanamanGrid[cellPos] = tanaman;
            siapPanen[cellPos] = true;
        }
    }

    public void PanenTanaman()
    {
        Vector3Int cellPos = grid.WorldToCell(transform.position + new Vector3(0, -0.5f, 0));

        if (tanamanGrid.ContainsKey(cellPos) && siapPanen[cellPos])
        {
            Destroy(tanamanGrid[cellPos]);
            tanamanGrid.Remove(cellPos);
            siapPanen.Remove(cellPos);

            // Tambah koin
            int koin = PlayerPrefs.GetInt("koin", 0);
            PlayerPrefs.SetInt("koin", koin + 1);
            PlayerPrefs.Save();

            Debug.Log("Panen berhasil! Koin sekarang: " + (koin + 1));
        }
        else
        {
            Debug.Log("Tidak ada tanaman siap panen.");
        }
    }
}
