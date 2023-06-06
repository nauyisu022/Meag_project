using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject passwordBox;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(passwordBox);
    }

    // Update is called once per frame
    void Update()
    {
        ChangeCameraPos();
    }
    void ChangeCameraPos()
    {
        if (SceneManager.Instance.cameraPos == 0)
            transform.position = new Vector3(0f, 10f, 0f);
        else if (SceneManager.Instance.cameraPos == 1)
        {
            transform.position = new Vector3(50f, 10f, 0f);
        }
            
    }
}
