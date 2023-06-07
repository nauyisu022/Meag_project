using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    // µ¥ÀýÄ£Ê½
    public static CameraManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public List<GameObject> cameras = new List<GameObject>();
    public int curIndex=0;
    public GameObject currentCamera = null;

    public GameObject switchCamera(string camName)
    {
        for (int i = 0; i < cameras.Count; i++)
        {
            GameObject cam = cameras[i];
            if (cam.name == camName)
            {
                cam.SetActive(true);
                curIndex = i;
                GameObject oldCamera = currentCamera;
                currentCamera.SetActive(false);
                currentCamera= cam;
                return oldCamera;
            }
        }
        throw new Exception($"The camera: '{camName}' is not found.");
    }

    public GameObject switchCamera(int camIndex)
    {
        print($"Switch to {camIndex}");
        if (camIndex < 0 || camIndex >= cameras.Count)
        {
            throw new Exception($"The camera: '{camIndex}' is not found.");
        }
        return switchCamera(cameras[camIndex].name);
    }

    private void Start()
    {
        foreach(GameObject cam in cameras)
        {
            cam.SetActive(false);
        }
        cameras[curIndex].SetActive(true);
        currentCamera = cameras[curIndex];
    }

}
