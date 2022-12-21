using UnityEngine;
using NSInputData;

public class UnityInput : InputDatas
{
    //����unity��J�S���վ�\��A�����ݭn���ѡA�Ӽg�Ź�@
    public void GamePlayerActive(bool type){
        
    }

    public Vector2 Arrows{
        get{
            return new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        }
    }

}
