using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class PassMouseEvent : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    //��������
    public void OnPointerDown(PointerEventData eventData)
    {
        PassEvent(eventData, ExecuteEvents.pointerDownHandler);
    }

    //����̧��
    public void OnPointerUp(PointerEventData eventData)
    {
        PassEvent(eventData, ExecuteEvents.pointerUpHandler);
    }

    //�������
    public void OnPointerClick(PointerEventData eventData)
    {
        PassEvent(eventData, ExecuteEvents.submitHandler);
        PassEvent(eventData, ExecuteEvents.pointerClickHandler);
    }

    /// <summary>
    /// ��������¼����ݵ��²� UI �� GameObject
    /// </summary>
    private static void PassEvent<T>(PointerEventData data, ExecuteEvents.EventFunction<T> function)
        where T : IEventSystemHandler
    {
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(data, results);
        var current = data.pointerCurrentRaycast.gameObject;
        foreach (var t in results.Where(t => current != t.gameObject))
        {
            ExecuteEvents.Execute(t.gameObject, data, function);
            //RaycastAll��ugui���Լ����������ֻ����Ӧ͸��ȥ�������һ����Ӧ������ExecuteEvents.Execute��ֱ��break���С�
        }
    }
}
