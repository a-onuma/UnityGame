using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    //PlayerCubeの位置把握用オブジェクト
    //staticでこの位置と向きだけ残しておいて、PlayerControllerに渡すことで値維持
    //GameOverからのReStartでも初期位置に戻したい(課題)



    public static Vector3 PlayerPos;
    public static Vector3 PlayerWorldAng;



    void Update()
    {
        PositionCheck();
    }


    void PositionCheck()
    {
        Transform myTransform = this.transform;
        Vector3 worldPos = myTransform.position;
        PlayerPos = worldPos;
        //Debug.Log(PlayerPos);

        Vector3 worldAngle = myTransform.eulerAngles;
        PlayerWorldAng = worldAngle;
        //Debug.Log(PlayerWorldAng);
    }

}
