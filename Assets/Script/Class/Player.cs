using UnityEngine;
using NSArrows;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Vector2 Move = Vector2.zero;
    private IArrows iarrows;//use iarrows interface
    

    private void Awake(){
        this.iarrows = new ForPlayerInput();//use iarrows ,select ForPlayerInput
        var tester = 10;
        Debug.Log(tester);
        tester = 55;
        Debug.Log(tester);
    }

    private void FixedUpdate(){
        Move = iarrows.LoadArrows();
    }

    private void OnGUI(){
        GUI.Label(new Rect(10,10,600,50),"Player Move:" + Move);
    }
}
