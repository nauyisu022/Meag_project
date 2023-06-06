using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShift : MonoBehaviour
{
    public List<Camera> cameras = new List<Camera>();
    public Camera currentCamera=null;
    public int curIndex=0;
    public bool isRendered = false;


    private void Start()
    {
    }
    private void Update() 
    {
        int cameraAmount = cameras.Count;
        if (cameraAmount == 0)
        {
            return;
        }
        if (!isRendered)
        {
            foreach(Camera c in cameras)
            {
                c.enabled= false;
            }
            cameras[curIndex].enabled = true;
            isRendered = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            int lastIndex = curIndex;
            curIndex++;
            if(curIndex>=cameras.Count)
            {
                curIndex= 0;
            }
            cameras[lastIndex].enabled = false;
            cameras[curIndex].enabled= true;
        }
    }
}
