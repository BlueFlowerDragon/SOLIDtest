using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�i���e�X��V�䤶���A�i�L��
public interface SendInputwithvary : SendInput{
    float BasicLegSet{set;} 
    float RayZoneSet{set;} 
}

//�򥻰e�X��V�䤶��
public interface SendInput{
    Vector2 Move(Vector2 IN);
}

//�t�d���a��J��V���ƪ��B�z�A�̫��X���K���
public class InputAdjust : SendInputwithvary
{
    //�]�w
    private float BasicLeg = 0.6f;//�]�w�̤p���סA������קC��value�ɳ̫��X(0,0)
    private float RayZone = 60;//�]�w�F�ӫסA50~75
    
    public Vector2 Move(Vector2 IN){
        return Vector2convert(IN);;//�ھ�Leg�MRay��V�M�w��X
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
        if(Leg < BasicLeg){//���פ����A��X(0,0)
            return new Vector2(0,0);
        }
        int Horizontal,Vertical;
        float Ray = Mathf.Atan2((X),(Y))*180/Mathf.PI;//��X��V
        if(Ray > (90 - RayZone) && Ray < (90 + RayZone)){//�w�q��XHorizontal = 1 ������
            Horizontal = 1;
        }else if(Ray > (-90 - RayZone) && Ray < (-90 + RayZone)){//�w�q��XHorizontal = -1 ������
            Horizontal = -1;
        }else{
            Horizontal = 0;
        }
        if(Ray > (180 - RayZone) || Ray < (-180 + RayZone)){//�w�q��XVertical = -1 ������
            Vertical = -1;
        }else if(Ray > (-RayZone) && Ray < RayZone){//�w�q��XVertical = 1 ������
            Vertical = 1;
        }else{
            Vertical = 0;
        }
        return new Vector2(Horizontal,Vertical);
    }

    

}
