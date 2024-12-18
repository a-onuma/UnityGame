using UnityEngine;

public class Config : MonoBehaviour
{
    void Start()
    {
        Application.targetFrameRate = 60;

        //PlayerCubeの初期位置をPlayerPosition.cs内のPlayerPosに
        Transform myTransform = this.transform;
        myTransform.position = PlayerPosition.PlayerPos;

        //向いている方向をPlayerPosition.cs内のPlayerWorldAngに
        myTransform.eulerAngles = PlayerPosition.PlayerWorldAng;
    }
}
