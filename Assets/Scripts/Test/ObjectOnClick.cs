using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectOnClick : MonoBehaviour, IPointerClickHandler
{
    //�������������갴�����ɿ����ڸ�������ʱ���������º���
    public void OnPointerClick(PointerEventData eventData)
    {
        //��Ҫ�����Ĵ���
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
//            //��������������ߵĵ�
//            Camera camera = CameraShift.currentCamera;
//            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
//            RaycastHit hit;
//            if (Physics.Raycast(ray, out hit))
//            {
//                print("�����������" + hit);
//            }
//        }
//    }
//}

