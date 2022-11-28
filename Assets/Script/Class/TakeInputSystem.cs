using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//InputSystem提供功能介面
public interface InputDatas{
    //使用或關閉
    void GamePlayerActive(bool type);
    //以下被其他class獲取
    Vector2 Arrows();
}
//負責操控inputSystem
public class TakeInputSystem : InputDatas
{
    private InputSystem inputSystem;

    public TakeInputSystem(){
        inputSystem = new InputSystem();//初始化，inputSystem一定要執行此行程式碼
    }

    public void GamePlayerActive(bool type){
        SetGamePlayer(type);
    }

    //獲取玩家輸入的Vector2座標
    public Vector2 Arrows(){
        return inputSystem.GamePlayer.Move.ReadValue<Vector2>();
    }

    //inputSystem的開關功能
    private void SetGamePlayer(bool type){
        if(type){
            inputSystem.GamePlayer.Enable();//使用inputSystem.GamePlayer
        }else{
            inputSystem.GamePlayer.Disable();//停用inputSystem.GamePlayer
        }
    }
    
}
