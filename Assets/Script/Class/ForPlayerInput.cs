using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//獲取方向鍵介面
public interface IArrows{
    Vector2 LoadArrows();
}

public class ForPlayerInput : IArrows
{
    private InputDatas inputdatas;//使用InputDatas介面
    private SendInputwithvary sendInput;//使用SendInputwithvary介面

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
            return sendInput.Move(Arrows);//根據Leg和Ray方向決定輸出
        }
    }

    private void UseAdjust(){
        this.sendInput = new InputAdjust();//使用InputAdjust的輸入調整器
        this.sendInput.BasicLegSet = 0.9f;
        this.sendInput.RayZoneSet = 75;
    }

}
