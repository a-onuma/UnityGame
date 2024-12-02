using UnityEngine;

public class Dungeon : MonoBehaviour
{
    public Find find;

    private int WallCnt; //壁個数カウント
    public bool check; //目の前が空いているならtrue

    public int WallCount
    {
        get
        {
            return WallCnt;
        }
        set
        {
            WallCnt = value;
        }
    }
    public void PositionCheck()
    {
        check = true;
        Vector3 NextPosition = find.find("CheckCube");
        //Debug.Log("nextpos" + NextPosition + "check: " + check);

        for (int i = 1; i < WallCount; i++)
        {
            Vector3 FirstWallPos = find.find("WallCubePrefab");
            if (NextPosition == FirstWallPos)
            {
                check = false; break;
            }
            Vector3 WallPosition = find.find("WallCubePrefab (" + i + ")");
            if (WallPosition == NextPosition) //壁の座標のどれかと移動先が一致したらfalse
            {
                check = false;
            }
        }
    }
}