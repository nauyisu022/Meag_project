using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectOnClick : MonoBehaviour, IPointerClickHandler
{
    //当鼠标点击，即鼠标按下与松开均在该物体上时，触发以下函数
    public void OnPointerClick(PointerEventData eventData)
    {
        //你要触发的代码
        this.gameObject.SetActive(false);
    }

}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class MouseHitScreen : MonoBehaviour
//{
//    void Start()
//    {

//    }

//    void Update()
//    {
//        if (Input.GetMouseButtonDown(0))
//        {
//            //从摄像机发出射线的点
//            Camera camera = CameraShift.currentCamera;
//            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
//            RaycastHit hit;
//            if (Physics.Raycast(ray, out hit))
//            {
//                print("鼠标点击了物体" + hit);
//            }
//        }
//    }
//}

