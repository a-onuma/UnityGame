using UnityEngine;

public class Config : MonoBehaviour
{
    void Start()
    {
        Application.targetFrameRate = 60;

        //PlayerCube‚Ì‰ŠúˆÊ’u‚ğPlayerPosition.cs“à‚ÌPlayerPos‚É
        Transform myTransform = this.transform;
        myTransform.position = PlayerPosition.PlayerPos;

        //Œü‚¢‚Ä‚¢‚é•ûŒü‚ğPlayerPosition.cs“à‚ÌPlayerWorldAng‚É
        myTransform.eulerAngles = PlayerPosition.PlayerWorldAng;
    }
}
