using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//進階送出方向鍵介面，可微調
public interface SendInputwithvary : SendInput{
    float BasicLegSet{set;} 
    float RayZoneSet{set;} 
}

//基本送出方向鍵介面
public interface SendInput{
    Vector2 Move(Vector2 IN);
}

//負責玩家輸入方向件資料的處理，最後輸出成八方位
public class InputAdjust : SendInputwithvary
{
    //設定
    private float BasicLeg = 0.6f;//設定最小長度，當收到長度低於此value時最後輸出(0,0)
    private float RayZone = 60;//設定靈敏度，50~75
    
    public Vector2 Move(Vector2 IN){
        return Vector2convert(IN);;//根據Leg和Ray方向決定輸出
    }

    public float BasicLegSet{
        set{
            BasicLeg = value;
        }
    }
    public float RayZoneSet{
        set{
            if(value > 75){
                RayZone = 75;
            }else if(value < 50){
                RayZone = 50;
            }else{
                RayZone = value;
            }
        }
    }

    private Vector2 Vector2convert(Vector2 TakeVector2){
        float X = TakeVector2.x;
        float Y = TakeVector2.y;
        float Leg = Mathf.Sqrt(Mathf.Pow(X,2) + Mathf.Pow(Y,2));
        if(Leg < BasicLeg){//長度不足，輸出(0,0)
            return new Vector2(0,0);
        }
        int Horizontal,Vertical;
        float Ray = Mathf.Atan2((X),(Y))*180/Mathf.PI;//算出方向
        if(Ray > (90 - RayZone) && Ray < (90 + RayZone)){//定義輸出Horizontal = 1 的條件
            Horizontal = 1;
        }else if(Ray > (-90 - RayZone) && Ray < (-90 + RayZone)){//定義輸出Horizontal = -1 的條件
            Horizontal = -1;
        }else{
            Horizontal = 0;
        }
        if(Ray > (180 - RayZone) || Ray < (-180 + RayZone)){//定義輸出Vertical = -1 的條件
            Vertical = -1;
        }else if(Ray > (-RayZone) && Ray < RayZone){//定義輸出Vertical = 1 的條件
            Vertical = 1;
        }else{
            Vertical = 0;
        }
        return new Vector2(Horizontal,Vertical);
    }

    

}
