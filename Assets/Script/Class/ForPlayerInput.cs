using UnityEngine;
using NSArrows;
using NSInputData;

public class ForPlayerInput : IArrows
{
    private InputDatas inputdatas;//use InputDatas Interface
    private SendInputWitHvary sendInput;//use XXX Interface

    public ForPlayerInput(){
        this.inputdatas = new TakeInputSystem();
        this.inputdatas.GamePlayerActive(true);
        UseAdjust();
    }

	public Vector2 LoadArrows(){
        Vector2 Arrows = this.inputdatas.Arrows;
        if(sendInput == null){
            return Arrows;
        }else{
            return sendInput.Move(Arrows);//Take Leg and Ray,output direction
        }
    }

    private void UseAdjust(){
        this.sendInput = new InputAdjust();//use InputAdjust redress
        this.sendInput.BasicLegSet = PlayerPrefs.GetFloat("Leg", 0.6f);//need fixed
        this.sendInput.RayZoneSet = PlayerPrefs.GetInt("RayZone", 55);//need fixed
    }

}
