using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityInput : InputDatas
{
    
    //內建unity輸入沒有調整功能，介面需要提供，而寫空實作
    public void GamePlayerActive(bool type){
        
    }

    public Vector2 Arrows{
        get{
            return new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        }
    }

}
