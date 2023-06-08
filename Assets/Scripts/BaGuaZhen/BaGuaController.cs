using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaGuaController : MonoBehaviour
{

    public static BaGuaController Instance { get; private set; }

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


    public void itemClickFunc(string itemTag, GameObject obj)
    {
        print($"itemTag: {itemTag}");
        print($"obj: {obj}");
        // 存储被选中的物品的标签
        _selectedItemTag = itemTag;
        // 设置一个标志来表示选中了一个物品
        _hasSelectedItem = true;
    }


    public Vector3[] currentPosition; // 存储物品的当前位置
    public Vector3[] correctPosition; // 存储物品的正确位置
    public GameObject[] prefabs; // 存储物品的预制件
    public char[] prefabNames; // 存储预制件的名字

    private string _selectedItemTag; // 存储选中的物品的标签
    private bool _hasSelectedItem; // 存储是否选中了一个物品
    public bool BaGua_isSuccess; // 存储是否摆放成功

    // 定义一个计算距离误差阈值
    public float distance_threshold = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        // 初始化当前位置为零
        for (int i = 0; i < currentPosition.Length; i++)
        {
            currentPosition[i] = Vector3.zero;
        }
        // 从"八卦物体摆放位置"的子物体中初始化正确位置
        GameObject parent = GameObject.Find("八卦物体摆放位置");
        for (int i = 0; i < correctPosition.Length; i++)
        {
            correctPosition[i] = parent.transform.GetChild(i).position;
        }
        // 初始化标志为false
        _hasSelectedItem = false;
        BaGua_isSuccess = false;
    }

    // Update is called once per frame
    void Update()
    {
        // 如果选中了一个物品并且点击了一次鼠标
        if (_hasSelectedItem && Input.GetMouseButtonDown(0))
        {
            // 创建一条从摄像机到鼠标位置的射线
            Ray ray = GameObject.Find("宿舍Camera").GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            // 如果射线碰到了任何物体
            if (Physics.Raycast(ray, out hit))
            {
                print("in hit");
                // 获取碰撞物体的标签
                string tag = hit.collider.gameObject.tag;
                // 如果碰撞物体是一个网格位置
                if (tag == "Grid")
                {
                    Debug.Log("Select Position Success");

                    // 根据选中的物品的标签获取其索引
                    int index = -1;
                    for (int i = 0; i < prefabNames.Length; i++)
                    {
                        if (prefabNames[i] == _selectedItemTag[0])
                        {
                            index = i;
                        }
                    }

                    // 获取碰撞物体的位置
                    Vector3 gridPosition = hit.collider.gameObject.transform.position;
                    // 获取预制件的rotation和scale
                    Quaternion rotation = prefabs[index].transform.rotation;
                    Vector3 scale = prefabs[index].transform.localScale;
                    // 根据选中的物品的预制件在该位置实例化一个物体并存储在一个变量中，并使用预制件的rotation和scale
                    GameObject newItem = Instantiate(prefabs[index], gridPosition, rotation);
                    newItem.transform.localScale = scale;
                    // 更新选中的物品在数组中的当前位置
                    currentPosition[index] = gridPosition;
                    // 销毁场景中之前的同一个物品的实例
                    /*
                    GameObject oldItem = GameObject.Find(_selectedItemTag);
                    if (oldItem != null)
                    {
                        Destroy(oldItem);
                    }*/
                    _hasSelectedItem = false;
                }
            }
            else print("Fail to hit!");
        }
        /*
        // 如果选中了一个物品并且鼠标松开了
        if (_hasSelectedItem && Input.GetMouseButtonUp(0))
        {
            print("in select");
            // 设置标志为没有选中任何物品
            _hasSelectedItem = false;
            // 调用CheckSuccess方法来检查是否摆放成功
            CheckSuccess();
        }*/
        CheckSuccess();
    }

    bool CheckSuccess()
    {
        // 遍历所有的物品，比较它们的当前位置和正确位置是否相同
        for (int i = 0; i < currentPosition.Length; i++)
        {
            // 如果有任何一个位置不相同，返回false并退出循环
            if (!PositionIsCorrect(currentPosition[i], correctPosition[i]))
            {
                return false;
            }
        }
        // 如果所有位置都相同，设置_isSuccess为true并返回true
        BaGua_isSuccess = true;
        return true;
    }

    bool PositionIsCorrect(Vector3 currentP, Vector3 correctP)
    {
        // 计算正确位置和当前位置之间的距离
        float distance = Vector3.Distance(currentP, correctP);
        // 如果距离小于或等于阈值，返回true，否则返回false
        return distance <= distance_threshold;
    }
}
