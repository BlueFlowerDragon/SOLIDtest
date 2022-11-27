using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 Arrows;

    private InputDatas inputdatas;//�ϥ�InputDatas����
    private SendInputwithvary sendInput;//�ϥ�SendInputwithvary����

    void Awake()
    {
        this.inputdatas = new TakeInputSystem();//�ϥ�inputdatas�A�D��TakeInputSystem
        this.inputdatas.GamePlayerActive(true);//��TakeInputSystem�Ұ�GamePlayer
        UseAdjust();//
    }

    void FixedUpdate(){
        Arrows = this.inputdatas.Arrows;//�qinputdatas��Vector2��
        if(sendInput != null){//���w�ˤ�V��վ㾹
            Debug.Log("Player Arrows with Adjust:" + this.sendInput.Move(Arrows));
        }else{//���w�ˤ�V��վ㾹
            Debug.Log("Player Arrows without Adjust:" +Arrows);
        }
    }

    private void UseAdjust(){
        this.sendInput = new InputAdjust();//�ϥ�InputAdjust����J�վ㾹
        this.sendInput.BasicLegSet = 0.9f;
        this.sendInput.RayZoneSet = 75;
    }
}
