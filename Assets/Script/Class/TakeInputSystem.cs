using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//InputSystem���ѥ\�श��
public interface InputDatas{
    //�ϥΩ�����
    void GamePlayerActive(bool type);
    //�H�U�Q��Lclass���
    Vector2 Arrows{get;}
}
//�t�d�ޱ�inputSystem
public class TakeInputSystem : InputDatas
{
    private Vector2 move;
    private InputSystem inputSystem;

    public TakeInputSystem(){
        inputSystem = new InputSystem();//��l�ơAinputSystem�@�w�n���榹��{���X
    }

    public void GamePlayerActive(bool type){
        SetGamePlayer(type);
    }

    //������a��J��Vector2�y��
    public Vector2 Arrows{
        get{
            move = inputSystem.GamePlayer.Move.ReadValue<Vector2>();
            return move;
        }
    }

    //inputSystem���}���\��
    private void SetGamePlayer(bool type){
        if(type){
            inputSystem.GamePlayer.Enable();//�ϥ�inputSystem.GamePlayer
        }else{
            inputSystem.GamePlayer.Disable();//����inputSystem.GamePlayer
        }
    }
    
}
