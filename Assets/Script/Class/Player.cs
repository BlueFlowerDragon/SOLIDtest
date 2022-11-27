using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 Arrows;

    private InputDatas inputdatas;//使用InputDatas介面
    private SendInputwithvary sendInput;//使用SendInputwithvary介面

    void Awake()
    {
        this.inputdatas = new TakeInputSystem();//使用inputdatas，挑選TakeInputSystem
        this.inputdatas.GamePlayerActive(true);//請TakeInputSystem啟動GamePlayer
        UseAdjust();//
    }

    void FixedUpdate(){
        Arrows = this.inputdatas.Arrows;//從inputdatas取Vector2值
        if(sendInput != null){//有安裝方向鍵調整器
            Debug.Log("Player Arrows with Adjust:" + this.sendInput.Move(Arrows));
        }else{//未安裝方向鍵調整器
            Debug.Log("Player Arrows without Adjust:" +Arrows);
        }
    }

    private void UseAdjust(){
        this.sendInput = new InputAdjust();//使用InputAdjust的輸入調整器
        this.sendInput.BasicLegSet = 0.9f;
        this.sendInput.RayZoneSet = 75;
    }
}
