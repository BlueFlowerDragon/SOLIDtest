using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private IArrows iarrows;//使用iarrows介面

    void Awake()
    {
        this.iarrows = new ForPlayerInput();//使用iarrows，挑選ForPlayerInput
    }

    void FixedUpdate(){
        Debug.Log(iarrows.LoadArrows());//從iarrows取Vector2值
    }
}
