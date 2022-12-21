using UnityEngine;
using UnityEngine.InputSystem;
using NSInputData;

//�t�d�ޱ�inputSystem
public class TakeInputSystem : InputDatas
{
    private InputSystem inputSystem;

    public TakeInputSystem(){
        inputSystem = new InputSystem();//��l�ơAinputSystem�@�w�n���榹��{���X
    }

    public void GamePlayerActive(bool bulb){
        SetGamePlayer(bulb);
    }

    //������a��J��Vector2�y��
    public Vector2 Arrows => inputSystem.GamePlayer.Move.ReadValue<Vector2>();
    //return inputSystem.GamePlayer.Move.ReadValue<Vector2>();
    

    //inputSystem���}���\��
    private void SetGamePlayer(bool bulb){
        if(bulb){
            inputSystem.GamePlayer.Enable();//�ϥ�inputSystem.GamePlayer
        }else{
            inputSystem.GamePlayer.Disable();//����inputSystem.GamePlayer
        }
    }
    
}
