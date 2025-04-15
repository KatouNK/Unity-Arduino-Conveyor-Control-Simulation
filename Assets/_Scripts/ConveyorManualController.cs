using UnityEngine;

public class ConveyorManualController : MonoBehaviour
{
    public ConveyorBelt belt;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            belt.direction = new Vector3(0, 0, -1);
            Debug.Log("Manual: Conveyor ke kiri");
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            belt.direction = new Vector3(0, 0, 1);
            Debug.Log("Manual: Conveyor ke kanan");
        }
    }
}