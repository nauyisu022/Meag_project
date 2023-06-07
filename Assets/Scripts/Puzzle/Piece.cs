using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    // 拼图碎片类
    public Vector3 correctPosition; // 记录拼图的正确位置
    public Vector3 currentPosition; // 记录拼图的当前位置

    public bool IsCorrect()
    {
        return correctPosition == currentPosition;
    }
}
