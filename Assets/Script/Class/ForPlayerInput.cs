using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�����V�䤶��
public interface IArrows{
    Vector2 LoadArrows();
}

public class ForPlayerInput : IArrows
{
    private InputDatas inputdatas;//�ϥ�InputDatas����
    private SendInputwithvary sendInput;//�ϥ�SendInputwithvary����

    public ForPlayerInput(){
        this.inputdatas = new TakeInputSystem();
        this.inputdatas.GamePlayerActive(true);
        UseAdjust();
    }

	public Vector2 LoadArrows(){
        Vector2 Arrows = inputdatas.Arrows();
        if(sendInput == null){
            return Arrows;
        }else{
            return sendInput.Move(Arrows);//�ھ�Leg�MRay��V�M�w��X
        }
    }

    private void UseAdjust(){
        this.sendInput = new InputAdjust();//�ϥ�InputAdjust����J�վ㾹
        this.sendInput.BasicLegSet = 0.9f;
        this.sendInput.RayZoneSet = 75;
    }

}
