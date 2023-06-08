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
        // �洢��ѡ�е���Ʒ�ı�ǩ
        _selectedItemTag = itemTag;
        // ����һ����־����ʾѡ����һ����Ʒ
        _hasSelectedItem = true;
    }


    public Vector3[] currentPosition; // �洢��Ʒ�ĵ�ǰλ��
    public Vector3[] correctPosition; // �洢��Ʒ����ȷλ��
    public GameObject[] prefabs; // �洢��Ʒ��Ԥ�Ƽ�
    public char[] prefabNames; // �洢Ԥ�Ƽ�������

    private string _selectedItemTag; // �洢ѡ�е���Ʒ�ı�ǩ
    private bool _hasSelectedItem; // �洢�Ƿ�ѡ����һ����Ʒ
    public bool BaGua_isSuccess; // �洢�Ƿ�ڷųɹ�

    // ����һ��������������ֵ
    public float distance_threshold = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        // ��ʼ����ǰλ��Ϊ��
        for (int i = 0; i < currentPosition.Length; i++)
        {
            currentPosition[i] = Vector3.zero;
        }
        // ��"��������ڷ�λ��"���������г�ʼ����ȷλ��
        GameObject parent = GameObject.Find("��������ڷ�λ��");
        for (int i = 0; i < correctPosition.Length; i++)
        {
            correctPosition[i] = parent.transform.GetChild(i).position;
        }
        // ��ʼ����־Ϊfalse
        _hasSelectedItem = false;
        BaGua_isSuccess = false;
    }

    // Update is called once per frame
    void Update()
    {
        // ���ѡ����һ����Ʒ���ҵ����һ�����
        if (_hasSelectedItem && Input.GetMouseButtonDown(0))
        {
            // ����һ��������������λ�õ�����
            Ray ray = GameObject.Find("����Camera").GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            // ��������������κ�����
            if (Physics.Raycast(ray, out hit))
            {
                print("in hit");
                // ��ȡ��ײ����ı�ǩ
                string tag = hit.collider.gameObject.tag;
                // �����ײ������һ������λ��
                if (tag == "Grid")
                {
                    Debug.Log("Select Position Success");

                    // ����ѡ�е���Ʒ�ı�ǩ��ȡ������
                    int index = -1;
                    for (int i = 0; i < prefabNames.Length; i++)
                    {
                        if (prefabNames[i] == _selectedItemTag[0])
                        {
                            index = i;
                        }
                    }

                    // ��ȡ��ײ�����λ��
                    Vector3 gridPosition = hit.collider.gameObject.transform.position;
                    // ��ȡԤ�Ƽ���rotation��scale
                    Quaternion rotation = prefabs[index].transform.rotation;
                    Vector3 scale = prefabs[index].transform.localScale;
                    // ����ѡ�е���Ʒ��Ԥ�Ƽ��ڸ�λ��ʵ����һ�����岢�洢��һ�������У���ʹ��Ԥ�Ƽ���rotation��scale
                    GameObject newItem = Instantiate(prefabs[index], gridPosition, rotation);
                    newItem.transform.localScale = scale;
                    // ����ѡ�е���Ʒ�������еĵ�ǰλ��
                    currentPosition[index] = gridPosition;
                    // ���ٳ�����֮ǰ��ͬһ����Ʒ��ʵ��
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
        // ���ѡ����һ����Ʒ��������ɿ���
        if (_hasSelectedItem && Input.GetMouseButtonUp(0))
        {
            print("in select");
            // ���ñ�־Ϊû��ѡ���κ���Ʒ
            _hasSelectedItem = false;
            // ����CheckSuccess����������Ƿ�ڷųɹ�
            CheckSuccess();
        }*/
        CheckSuccess();
    }

    bool CheckSuccess()
    {
        // �������е���Ʒ���Ƚ����ǵĵ�ǰλ�ú���ȷλ���Ƿ���ͬ
        for (int i = 0; i < currentPosition.Length; i++)
        {
            // ������κ�һ��λ�ò���ͬ������false���˳�ѭ��
            if (!PositionIsCorrect(currentPosition[i], correctPosition[i]))
            {
                return false;
            }
        }
        // �������λ�ö���ͬ������_isSuccessΪtrue������true
        BaGua_isSuccess = true;
        return true;
    }

    bool PositionIsCorrect(Vector3 currentP, Vector3 correctP)
    {
        // ������ȷλ�ú͵�ǰλ��֮��ľ���
        float distance = Vector3.Distance(currentP, correctP);
        // �������С�ڻ������ֵ������true�����򷵻�false
        return distance <= distance_threshold;
    }
}
