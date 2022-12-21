using UnityEngine;


public interface SendInputWitHvary : SendInput{
    float BasicLegSet{set;} 
    float RayZoneSet{set;} 
}


public interface SendInput{
    Vector2 Move(Vector2 IN);
}

//Player's Arrows Input to int Eight-direction control
public class InputAdjust : SendInputWitHvary
{
    //Setting
    public float BasicLeg = 0.6f;//need fixed
    private float RayZone = 60;
    
    public Vector2 Move(Vector2 IN){
        return Vector2convert(IN);//Take Leg and Ray,output direction
    }

    public float RayZoneSet{
        set{
            RayZone = Mathf.Min(Mathf.Max(value,50),75);
        }
    }

    public float BasicLegSet{
        set{
            BasicLeg = value;
        }
    }

    private Vector2 Vector2convert(Vector2 TakeVector2){
        float X = TakeVector2.x;
        float Y = TakeVector2.y;
        float Leg = Mathf.Sqrt(Mathf.Pow(X,2) + Mathf.Pow(Y,2));
        if(Leg < BasicLeg){//no enough length,output (0,0)
            return Vector2.zero;
        }

        int Horizontal,Vertical;
        float Ray = Mathf.Atan2((X),(Y))*180f/Mathf.PI;//count angle


        if(Ray > (90f - RayZone) && Ray < (90f + RayZone)){//definition how Horizontal = 1 
            Horizontal = 1;
        }else if(Ray > (-90f - RayZone) && Ray < (-90f + RayZone)){//definition how Horizontal = -1
            Horizontal = -1;
        }else{
            Horizontal = 0;
        }
        if(Ray > (180f - RayZone) || Ray < (-180f + RayZone)){//definition how Vertical = -1 
            Vertical = -1;
        }else if(Ray > (-RayZone) && Ray < RayZone){//definition how Vertical = 1 
            Vertical = 1;
        }else{
            Vertical = 0;
        }
        return new Vector2(Horizontal,Vertical);
    }

    

}
