using UnityEngine;

public class ItemTracker : MonoBehaviour
{
    public enum ItemType { Luggage, Cardboard }
    public ItemType itemType;

    public BeltManager beltManager; // drag dari manager saat spawn

    private bool hasArrived = false;

    void OnCollisionEnter(Collision collision)
    {
        if (hasArrived) return;

        if (collision.gameObject.CompareTag("Conveyor_Left") && itemType == ItemType.Luggage)
        {
            hasArrived = true;
            Debug.Log("✅ Luggage masuk ke JALUR KIRI yang benar!");
            beltManager.NotifyItemArrived();
        }
        else if (collision.gameObject.CompareTag("Conveyor_Right") && itemType == ItemType.Cardboard)
        {
            hasArrived = true;
            Debug.Log("✅ Cardboard masuk ke JALUR KANAN yang benar!");
            beltManager.NotifyItemArrived();
        }
        else if (collision.gameObject.CompareTag("Conveyor_Left") || collision.gameObject.CompareTag("Conveyor_Right"))
        {
            hasArrived = true;
            Debug.Log($"❌ {itemType} SALAH JALUR!");
            // Tidak panggil NotifyItemArrived → tidak spawn baru
        }
    }

    }
