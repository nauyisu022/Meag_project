using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShift : MonoBehaviour
{
    public List<GameObject> cameras = new List<GameObject>();
    public static Camera currentCamera=null;
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
            foreach(GameObject c in cameras)
            {
                c.SetActive(false);
            }
            cameras[curIndex].SetActive(true);
            currentCamera = cameras[curIndex].GetComponent<Camera>();
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
            cameras[lastIndex].SetActive(false);
            cameras[curIndex].SetActive(true);
            currentCamera = cameras[curIndex].GetComponent<Camera>();
        }
    }
}
