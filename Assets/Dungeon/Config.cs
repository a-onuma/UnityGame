using UnityEngine;

public class Config : MonoBehaviour
{
    void Start()
    {
        Application.targetFrameRate = 60;

        //PlayerCube�̏����ʒu��PlayerPosition.cs����PlayerPos��
        Transform myTransform = this.transform;
        myTransform.position = PlayerPosition.PlayerPos;

        //�����Ă��������PlayerPosition.cs����PlayerWorldAng��
        myTransform.eulerAngles = PlayerPosition.PlayerWorldAng;
    }
}
