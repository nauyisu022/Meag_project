using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartBaGuaZhen : MonoBehaviour
{
    //PositionLoader对象的引用
    public GameObject positionLoader;
    //网格物体数组
    public GameObject[] children;
    //拼图碎片物体数组
    public GameObject[] pieces;

    //游戏是否成功
    public bool isSuccess;
    //当前选中的拼图碎片物体
    public GameObject selectedPiece;

    void Start()
    {
        Debug.Log("Start...");

        //初始化游戏是否成功为false
        isSuccess = false;
        //初始化当前选中的拼图碎片物体为null
        selectedPiece = null;

        //获取PositionLoader对象和其子物体的引用
        positionLoader = GameObject.Find("八卦阵位置指示");
        //获取PositionLoader对象的RectTransform组件
        RectTransform rectTransform = positionLoader.GetComponent<RectTransform>();
        foreach (Transform child in positionLoader.transform)
        {
            Debug.Log(child.gameObject.name);
        }
        /*
        children = new GameObject[positionLoader.transform.childCount];
        Vector3 firstPosition = positionLoader.transform.GetChild(0).gameObject.transform.position; // 获取第一个子物体的位置
        for (int i = 0; i < children.Length; i++)
        {
            children[i] = positionLoader.transform.GetChild(i).gameObject;
            Vector3 currentPosition = children[i].transform.position; // 获取当前子物体的位置
            if (!Vector3.Equals(currentPosition, firstPosition)) // 比较当前位置和第一个位置是否相同
            {
                Debug.Log("Different position found: " + children[i].name); // 如果不同，输出提示信息
            }
        }*/
        Debug.Log(children.Length);
        //打印positionLoader对象是否为空
        Debug.Log("positionLoader is null: " + (positionLoader == null));


        //遍历所有拼图碎片物体和网格物体
        for (int i = 0; i < 9; i++)
        {
            //获取Piece脚本
            Piece piece = pieces[i].GetComponent<Piece>();
            //根据拼图碎片物体在场景中的位置，设置当前位置属性
            piece.currentPosition = pieces[i].transform.position;
            piece.initPosition = pieces[i].transform.position;

            //通过positionLoader对象的transform属性来获取它的第i个子物体的位置
            /*GameObject child = positionLoader.transform.GetChild(i).gameObject;
            //打印子物体是否为空
            Debug.Log("child is null: " + (child == null));*/
            /*Vector3 child_Position = positionLoader.transform.GetChild(i).transform.position;
            //加上锚点和中心点的偏移量
            child_Position -= new Vector3(rectTransform.rect.width * rectTransform.pivot.x, rectTransform.rect.height * rectTransform.pivot.y, 0);
            //打印子物体的位置
            Debug.Log(child_Position);*/

            //设置正确位置属性
            piece.correctPosition = children[i].GetComponent<GridPosition>().targetPosition;

            //打印拼图碎片物体在场景中的位置
            Debug.Log("Current position of " + pieces[i].name + ": " + piece.currentPosition);
            //打印对应的网格位置
            Debug.Log("Correct position of " + pieces[i].name + ": " + piece.correctPosition);
        }

    }

    void Update()
    {
        //遍历所有拼图碎片物体，检查它们的Piece脚本中的当前位置是否和正确位置相同。如果都相同，则表示游戏成功，将isSuccess变量设置为true，并显示相应的提示信息。
        CheckSuccess();

        //如果游戏没有成功，则处理用户的输入事件。使用Raycast函数或其他方法，检测用户点击了哪个拼图碎片物体，然后将其选中并高亮显示。再次点击时，检测用户点击了哪个网格位置，然后将选中的拼图碎片物体移动到该位置，并更新其Piece脚本中的当前位置信息。如果用户没有点击任何有效的位置，则取消选中并恢复原样。
        if (!isSuccess)
        {
            HandleInput();

        }
    }

    //检查游戏是否成功的方法
    void CheckSuccess()
    {
        //遍历所有拼图碎片物体
        for (int i = 0; i < pieces.Length; i++)
        {
            //获取Piece脚本
            Piece piece = pieces[i].GetComponent<Piece>();

            //如果有一个拼图碎片物体的当前位置和正确位置不同，则返回
            if (!piece.IsCorrect())
            {
                return;
            }
        }
        //如果所有拼图碎片物体的当前位置和正确位置都相同，则表示游戏成功
        isSuccess = true;
        SceneManager.Instance.puzzleIsCorrect = true;
        //显示提示信息
        Debug.Log("You win!");
    }

    //处理用户输入事件的方法
    void HandleInput()
    {
        //如果用户点击了鼠标左键
        if (Input.GetMouseButtonDown(0))
        {
            //创建一个射线，从摄像机发射到鼠标点击的屏幕位置
            Ray ray = GameObject.Find("拼图Camera").GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            //如果射线碰到了任何物体
            if (Physics.Raycast(ray, out hit))
            {
                //获取碰撞物体的标签
                string tag = hit.collider.gameObject.tag;
                //如果碰撞物体是拼图碎片
                if (tag == "Piece")
                {
                    //如果当前没有选中任何拼图碎片物体，则将碰撞物体设为选中，并高亮显示
                    if (selectedPiece == null)
                    {
                        selectedPiece = hit.collider.gameObject;
                        selectedPiece.GetComponent<SpriteRenderer>().color = Color.yellow;
                    }
                    //否则，如果当前已经选中了一个拼图碎片物体，并且它和碰撞物体不是同一个，则取消选中，并恢复原样
                    else if (selectedPiece != hit.collider.gameObject)
                    {
                        selectedPiece.GetComponent<SpriteRenderer>().color = Color.white;
                        selectedPiece = null;
                    }
                }
                //否则，如果碰撞物体是网格位置
                else if (tag == "Grid")
                {
                    //如果当前已经选中了一个拼图碎片物体，则将其移动到碰撞物体的位置，并更新其Piece脚本中的当前位置信息，然后取消选中，并恢复原样
                    if (selectedPiece != null)
                    {
                        //获取碰撞物体的位置
                        Vector3 gridPosition = hit.collider.gameObject.transform.position;
                        //让选中的拼图碎片物体再往z轴移动-0.1
                        gridPosition -= new Vector3(0, 0, 0.2f);
                        //移动选中的拼图碎片物体到新的位置 
                        selectedPiece.transform.position = gridPosition;
                        selectedPiece.GetComponent<Piece>().currentPosition = selectedPiece.transform.position;
                        //记录正确的目标位置
                        Vector3 ccPosition = selectedPiece.GetComponent<Piece>().currentPosition;
                        Debug.Log(ccPosition);
                        selectedPiece.GetComponent<SpriteRenderer>().color = Color.white;
                        selectedPiece = null;
                        //Debug.Log("碰撞后Current position of " + pieces[i].name + ": " + piece.currentPosition);
                    }
                }
            }
            //否则，如果射线没有碰到任何物体
            else
            {
                //如果当前已经选中了一个拼图碎片物体，则取消选中，并恢复原样
                if (selectedPiece != null)
                {
                    selectedPiece.GetComponent<SpriteRenderer>().color = Color.white;
                    selectedPiece = null;
                }
            }
        }
        CheckError();
    }

    //检查拼图是否错误的方法
    bool CheckError()
    {
        //遍历所有拼图碎片物体
        for (int i = 0; i < pieces.Length; i++)
        {
            //获取Piece脚本
            Piece piece = pieces[i].GetComponent<Piece>();

            //如果有一个拼图碎片物体的当前位置和正确位置不同，则继续检查
            if (!piece.IsCorrect())
            {
                //定义一个布尔变量，用来记录是否所有拼图碎片物体都已经被移动到网格上
                bool allOnGrid = true;
                //遍历所有拼图碎片物体
                for (int j = 0; j < pieces.Length; j++)
                {
                    //获取Piece脚本
                    Piece piece2 = pieces[j].GetComponent<Piece>();
                    //如果有一个拼图碎片物体的当前位置和初始位置相同，则表示它还没有被移动到网格上，将布尔变量设为false，并跳出循环
                    if (piece2.currentPosition == piece2.initPosition)
                    {
                        allOnGrid = false;
                        break;
                    }
                }
                //如果所有拼图碎片物体都已经被移动到网格上，则表示拼图错误，输出提示信息，并将所有拼图碎片物体还原到初始位置，返回false
                if (allOnGrid)
                {
                    Debug.Log("拼图错误，请重新拼图。");
                    for (int k = 0; k < pieces.Length; k++)
                    {
                        //获取Piece脚本
                        Piece piece3 = pieces[k].GetComponent<Piece>();
                        //将拼图碎片物体移动到初始位置，并更新其Piece脚本中的当前位置信息
                        pieces[k].transform.position = piece3.initPosition;
                        piece3.currentPosition = piece3.initPosition;
                    }
                    return false;
                }
                //否则，表示拼图还没有完成，返回false
                else
                {
                    return false;
                }
            }
        }
        //如果所有拼图碎片物体的当前位置和正确位置都相同，则表示拼图正确，返回true
        return true;
    }
}
