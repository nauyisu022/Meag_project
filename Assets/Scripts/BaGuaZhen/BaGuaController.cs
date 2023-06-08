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

    public void itemClickFunc(string itemTag, GameObject obj) {
        print("in itemClickFunc");
        print($"itemTag: {itemTag}");
        print($"obj: {obj}");
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
