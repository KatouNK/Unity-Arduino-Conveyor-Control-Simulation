using UnityEngine;
using System.IO.Ports;
using System;

public class ConveyorManualController : MonoBehaviour
{
    public ConveyorBelt belt;
    public string portName = "COM8"; // Ganti dengan port Arduino Anda
    public int baudRate = 9600;
    private SerialPort serialPort;
    public Camera[] cameras;
    private int currentCameraIndex = 0;

    void Start()
    {
        ActivateCamera(currentCameraIndex);
        OpenSerialConnection();
    }

    void OpenSerialConnection()
    {
        try
        {
            string[] ports = SerialPort.GetPortNames();

            if (!Array.Exists(ports, port => port == portName))
            {
                Debug.LogError($"Error: Port {portName} tidak ditemukan. Port tersedia: {string.Join(", ", ports)}");
                return;
            }

            serialPort = new SerialPort(portName, baudRate);
            serialPort.Open();
            serialPort.ReadTimeout = 50;
            Debug.Log("Serial connection opened.");
        }
        catch (Exception e)
        {
            Debug.LogError("Error opening serial connection: " + e.Message);
        }
    }

    void Update()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            try
            {
                string data = serialPort.ReadLine().Trim(); // Baca dan bersihkan data
                Debug.Log("Received: " + data);

                // Respon objek berdasarkan data dari Arduino
                if (data == "KIRI")
                {
                    belt.direction = new Vector3(0, 0, -1);
                    Debug.Log("Manual: Conveyor ke kiri");
                }

                else if (data == "KANAN")
                {
                    belt.direction = new Vector3(0, 0, 1);
                    Debug.Log("Manual: Conveyor ke kanan");
                }
                else if (data == "CAMERA") // tekan C untuk ganti kamera
                {
                    currentCameraIndex++;
                    if (currentCameraIndex >= cameras.Length)
                        currentCameraIndex = 0;

                    ActivateCamera(currentCameraIndex);
                }
            }
            catch (Exception e)
            {
                Debug.LogError("Error opening serial connection: " + e.Message);
            }
        }
        
       
    }
    
    void ActivateCamera(int index)
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].enabled = (i == index);
        }
    }
    void OnApplicationQuit()
    {
        if (serialPort != null)
        {
            serialPort.Close();
            serialPort.Dispose();
            serialPort = null;
        }

    }
    
    
}

    

