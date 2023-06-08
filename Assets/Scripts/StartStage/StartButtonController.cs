using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonController : MonoBehaviour
{
    public GameObject aS;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGameButton()
    {
        aS.GetComponent<AudioSource>().Play();
        Invoke("ChangeScene", 2.0f);
    }
    void ChangeScene()
    {
        GameManager.Instance.LoadScene("Stage0");
    }
}
