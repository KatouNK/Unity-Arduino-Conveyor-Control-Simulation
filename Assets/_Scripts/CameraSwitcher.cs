using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera[] cameras;
    private int currentCameraIndex = 0;

    void Start()
    {
        ActivateCamera(currentCameraIndex);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) // tekan C untuk ganti kamera
        {
            currentCameraIndex++;
            if (currentCameraIndex >= cameras.Length)
                currentCameraIndex = 0;

            ActivateCamera(currentCameraIndex);
        }
    }

    void ActivateCamera(int index)
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].enabled = (i == index);
        }
    }
}