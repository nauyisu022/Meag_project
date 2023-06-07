using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockTrigger : FatherTrigger
{
    int curState = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChangeState();
    }
    public new void ChangeState()
    {
        //ªÒµ√µÿ«Ú“«£∫0-1
        if(SceneManager.Instance.rockInBag == true)
        {
            curState = 1;
        }

    }
}
