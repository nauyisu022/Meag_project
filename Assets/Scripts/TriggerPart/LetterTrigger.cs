using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterTrigger : BagBaseItem
{
    string _tag = null;
    string _name = null;
    string _description = null;
    string checkText1 = null;
    string checkText2 = null;
    Sprite image1 = null;
    Sprite image2 = null;
    void Awake()
    {
        Init();
        updateItemInfo(_tag, _name, _description, checkText1, image1, false);   // 这里是不需要更新到UI那边的，因为还没触发UI显示
    }
    void Init()
    {
        _tag = "手写信";
        _name = "手写信";
        _description = "手写信";

        checkText1 = "一封破旧的信，似乎已经被遗忘在岁月的尘埃之中。";
        checkText2 = "哦不！这是她刚分手后写给我的生日祝福信！它不仅是一份祝福，更是一个勇往直前的诺言，一个我们各自为战，追求美好未来的信仰。它象征了一种纯粹的爱，一种即使我们不能在一起，但我依然希望你能保持热爱，坚持自我，向着你的未来奔跑的爱，高中的回忆涌上心头......";
        image1 = Resources.Load<Sprite>("手写信");
        image2 = Resources.Load<Sprite>("手写信");
        needScaleUp= true;
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
