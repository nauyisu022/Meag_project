using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    // 拼图碎片类
    public Vector3 initPosition; // 记录拼图的初始位置
    public Vector3 correctPosition; // 记录拼图的正确位置
    public Vector3 currentPosition; // 记录拼图的当前位置

    // 定义一个阈值
    float threshold = 0.3f;

    public bool IsCorrect()
    {
        // 计算正确位置和当前位置之间的距离
        float distance = Vector3.Distance(correctPosition, currentPosition);
        // 如果距离小于或等于阈值，返回true，否则返回false
        return distance <= threshold;
    }
}
