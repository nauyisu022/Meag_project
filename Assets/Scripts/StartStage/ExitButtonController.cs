using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        // 在编辑器中停止播放
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // 在运行时退出游戏
        Application.Quit();
#endif
    }
}
