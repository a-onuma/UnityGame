using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    //PlayerCube�̈ʒu�c���p�I�u�W�F�N�g
    //static�ł��̈ʒu�ƌ��������c���Ă����āAPlayerController�ɓn�����ƂŒl�ێ�
    //GameOver�����ReStart�ł������ʒu�ɖ߂�����(�ۑ�)



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
