using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListButtonController : MonoBehaviour
{
    public GameObject text;

    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Show()
    {
        text.SetActive(true);
        Invoke("Unshow", 5.0f);
    }
    void Unshow()
    {
        text.SetActive(false);
    }
}
