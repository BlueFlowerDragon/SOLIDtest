using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private IArrows iarrows;//�ϥ�iarrows����

    void Awake()
    {
        this.iarrows = new ForPlayerInput();//�ϥ�iarrows�A�D��ForPlayerInput
    }

    void FixedUpdate(){
        Debug.Log(iarrows.LoadArrows());//�qiarrows��Vector2��
    }
}
