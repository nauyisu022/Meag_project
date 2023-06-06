using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public bool passwordIsCorrect = false;
    public bool jumpToClassroom = false;
    public int cameraPos = 0;//0代表宿舍，1代表教室
    public static SceneManager Instance { get; private set; }

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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ClassroomStart();
        ClassroomOver();
    }
    void ClassroomStart()
    {
        if(jumpToClassroom == true)
        {
            GameManager.Instance.stage1IsStart = true;
            cameraPos = 1;
        }
    }
    void ClassroomOver()
    {
        if(passwordIsCorrect == true)
        {
            GameManager.Instance.stage1IsOver = true;
            cameraPos = 0;
            //GameManager.Instance.LoadScene("")
        }

    }
}
