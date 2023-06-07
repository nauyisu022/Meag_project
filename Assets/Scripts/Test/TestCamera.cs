using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCamera : MonoBehaviour
{
    public int x = 0;
    public void switchCam()
    {
        int size = CameraManager.Instance.cameras.Count;
        x++;
        if (x >= size)
        {
            x = 0;
        }
        CameraManager.Instance.switchCamera(x);
    }
}
