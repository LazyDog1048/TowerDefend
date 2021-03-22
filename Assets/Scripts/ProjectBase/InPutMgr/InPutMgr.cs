﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//inputMagr
//input类
//事件中心
//公共mono
public class InPutMgr : BaseManager<InPutMgr>
{
    private bool isStart = false;
    public float Horizontal;
    public  InPutMgr()
    {
        MonoMgr.GetInstance().AddUpdateListener(InputUpdate);  
    }

    public void StartOrEnd(bool isStart)
    {
        this.isStart = isStart;
    }

    private void CheckKeyCode(KeyCode key)
    {        
        if (Input.GetKey(key))
            EventCenter.GetInstance().EventTrigger("KeyPress", key);
        if (Input.GetKeyDown(key))
            EventCenter.GetInstance().EventTrigger("KeyDown", key);
        if (Input.GetKeyUp(key))
            EventCenter.GetInstance().EventTrigger("KeyUp", key);     
    }
    private void GetAxis()
    {  
        Vector2 move = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        EventCenter.GetInstance().EventTrigger("MoveInput", move);
    }

    public void InputUpdate()
    {
        if (!isStart)
            return;
        CheckKeyCode(KeyCode.Space);
        CheckKeyCode(KeyCode.Mouse0);
        CheckKeyCode(KeyCode.Escape);
        //移动放在最下面
        CheckKeyCode(KeyCode.W);    
        CheckKeyCode(KeyCode.A);
        CheckKeyCode(KeyCode.S);
        CheckKeyCode(KeyCode.D);
        CheckKeyCode(KeyCode.J);
        GetAxis();
    }  

}
