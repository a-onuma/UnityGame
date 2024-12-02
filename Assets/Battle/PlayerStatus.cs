using UnityEngine;

[CreateAssetMenu(menuName = "Player_Status")]
public class PlayerStatus : ScriptableObject
{
    public int hp = 1000;
    public int mp = 100;
    public int strength = 10;
    public int intelligence = 30;
    public int costMp = 30;
}

