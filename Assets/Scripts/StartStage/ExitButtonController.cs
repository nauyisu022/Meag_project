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
        // �ڱ༭����ֹͣ����
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // ������ʱ�˳���Ϸ
        Application.Quit();
#endif
    }
}
