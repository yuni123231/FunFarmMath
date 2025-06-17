using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;
using System.Collections.Generic;

public class PlayerActionController : MonoBehaviour
{
    public GameObject bibitPrefab;             // Prefab bibit kecil
    public GameObject tanamanPrefab;           // Prefab tanaman besar
    public Grid grid;                          // Objek Grid (parent dari Tilemap)
    public Tilemap tanahTilemap;               // Tilemap tempat menanam (misal: foreground)

    private Dictionary<Vector3Int, GameObject> tanamanGrid = new Dictionary<Vector3Int, GameObject>();
    private Dictionary<Vector3Int, bool> siapPanen = new Dictionary<Vector3Int, bool>();

    // Dipanggil saat tombol Tanam ditekan
    public void TanamBibit()
    {
        Vector3Int cellPos = grid.WorldToCell(transform.position);

        // Cek jika bukan tile tanah, return
        if (!tanahTilemap.HasTile(cellPos))
        {
            Debug.Log("Bukan tile tanah, tidak bisa menanam.");
            return;
        }

        // Cek jika sudah ada tanaman di sini
        if (tanamanGrid.ContainsKey(cellPos)) return;

        // Hitung posisi di tengah tile
        Vector3 worldPos = grid.GetCellCenterWorld(cellPos);

        // Instantiate bibit
        GameObject bibit = Instantiate(bibitPrefab, worldPos, Quaternion.identity);
        tanamanGrid[cellPos] = bibit;
        siapPanen[cellPos] = false;

        // Mulai tumbuh
        StartCoroutine(TumbuhkanTanaman(cellPos));
    }

    // Proses pertumbuhan setelah 5 detik
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

    // Dipanggil saat tombol Panen ditekan
    public void PanenTanaman()
    {
        Vector3Int cellPos = grid.WorldToCell(transform.position);

        if (tanamanGrid.ContainsKey(cellPos) && siapPanen[cellPos])
        {
            Destroy(tanamanGrid[cellPos]);
            tanamanGrid.Remove(cellPos);
            siapPanen.Remove(cellPos);

            Debug.Log("Panen berhasil!");
        }
        else
        {
            Debug.Log("Tidak ada tanaman siap panen di sini.");
        }
    }
}
