using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoPuzzle : SceneBaseItem
{
    //int count = 0;
    public override void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log(count);
        if(SceneManager.Instance.puzzleCnt == 0)
        {
            CameraManager.Instance.switchCamera("拼图Camera");
            SceneManager.Instance.puzzleCnt++;
        }
            
        //if (count > 0)
        //CameraManager.Instance.switchCamera("拼图Camera");
        //count++;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
