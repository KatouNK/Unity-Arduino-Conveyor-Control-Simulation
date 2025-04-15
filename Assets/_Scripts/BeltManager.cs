using System.Collections;
using UnityEngine;

public class BeltManager : MonoBehaviour
{
    public GameObject boxPrefab;
    public GameObject cardboardPrefab;
    public Transform spawnPoint;
    public ConveyorBelt horizontalConveyor;

    private bool canSpawn = true;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            if (canSpawn)
            {
                canSpawn = false;
                SpawnItem();
            }

            yield return null;
        }
    }

    void SpawnItem()
    {
        int random = Random.Range(0, 2);

        GameObject prefabToSpawn;
        Vector3 direction;

        ItemTracker.ItemType itemType;

        if (random == 0)
        {
            prefabToSpawn = boxPrefab;
            direction = new Vector3(0, 0, -1);
            itemType = ItemTracker.ItemType.Luggage;
        }
        else
        {
            prefabToSpawn = cardboardPrefab;
            direction = new Vector3(0, 0, 1);
            itemType = ItemTracker.ItemType.Cardboard;
        }

        GameObject item = Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity);
        horizontalConveyor.direction = direction;

        ItemTracker tracker = item.AddComponent<ItemTracker>();
        tracker.itemType = itemType;
        tracker.beltManager = this;

        Debug.Log($"Spawned: {item.name}, Conveyor arah: {direction}");
    }

    public void NotifyItemArrived()
    {
        StartCoroutine(SpawnDelay());
    }

    IEnumerator SpawnDelay()
    {
        yield return new WaitForSeconds(1f); // delay sebelum spawn baru
        canSpawn = true;
    }
}