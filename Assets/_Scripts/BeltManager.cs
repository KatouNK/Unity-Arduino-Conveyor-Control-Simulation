using System.Collections;
using UnityEngine;

public class BeltManager : MonoBehaviour
{
    public GameObject boxPrefab;
    public GameObject cardboardPrefab;
    public Transform spawnPoint;
    public ConveyorBelt horizontalConveyor;

    private GameObject currentItem;
    private bool isSpawning = false;

    void Start()
    {
        StartCoroutine(SpawnItemRoutine());
    }

    IEnumerator SpawnItemRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f); // jeda antar spawn

            int random = Random.Range(0, 2);

            if (random == 0)
            {
                currentItem = Instantiate(boxPrefab, spawnPoint.position, Quaternion.identity);
                horizontalConveyor.direction = new Vector3(0, 0, -1); // kiri
            }
            else
            {
                currentItem = Instantiate(cardboardPrefab, spawnPoint.position, Quaternion.identity);
                horizontalConveyor.direction = new Vector3(0, 0, 1); // kanan
            }

            // Optional: tambahkan log untuk debug
            Debug.Log($"Spawned: {currentItem.name}, Conveyor arah: {horizontalConveyor.direction}");
        }
    }
}