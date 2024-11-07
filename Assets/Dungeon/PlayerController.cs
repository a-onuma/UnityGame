using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{

    public int WalkCnt = 0; //歩数カウント
    bool check;

    int WallCount; //壁個数カウント



    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        check = true;

        WallCount = GameObject.FindGameObjectsWithTag("Wall").Length;
        Debug.Log(WallCount);

        
        //PlayerCubeの初期位置をPlayerPosition.cs内のPlayerPosに
        Transform myTransform = this.transform;
        myTransform.position = PlayerPosition.PlayerPos;

        //向いている方向をPlayerPosition.cs内のPlayerWorldAngに
        myTransform.eulerAngles = PlayerPosition.PlayerWorldAng;


    }

    // Update is called once per frame

    void Update()

    {
        check = true;

        Vector3 NextPosition = GameObject.Find("CheckCube").transform.position;
        //Debug.Log("nextpos" + NextPosition + "check: " + check);



        if (Input.GetKeyDown(KeyCode.UpArrow)) //前に進む
        {
            for (int i = 1; i < WallCount; i++)
            {
                Vector3 FirstWallPos = GameObject.Find("WallCubePrefab").transform.position;
                if (NextPosition == FirstWallPos)
                {
                    check = false; break;
                }
                Vector3 WallPosition = GameObject.Find("WallCubePrefab (" + i + ")").transform.position;
                if (WallPosition == NextPosition) //壁の座標のどれかと移動先が一致したらfalse
                {
                    check = false;
                }
            }

            if (check == true) //移動先が空なら１マス移動
            {
                transform.Translate(0, 0, 1);
                WalkCnt += 1;
            }
        }



        if (Input.GetKeyDown(KeyCode.RightArrow)) //右向く
        {
            transform.Rotate(0, 90, 0);

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) //左向く
        {
            transform.Rotate(0, -90, 0);
        }


        //20歩歩いたら戦闘シーンへ
        if (WalkCnt == 20)
        { 
           SceneManager.LoadScene("BattleScene");
        }



        Vector3 ApplePosition = GameObject.Find("apple").transform.position;
        Transform myTransform = this.transform;
        Vector3 MyTransform = myTransform.position;
        //もし現在地が林檎の位置と同じなら
        if (MyTransform == ApplePosition)
        {
            //現在地を初期位置(0,0,0)に
            Transform mTransform = this.transform;
            Vector3 worldPos = mTransform.position;
            worldPos.x = 0.0f;
            worldPos.y = 0.0f;
            worldPos.z = 0.0f;
            mTransform.position = worldPos;


            //初期値(0,0,0)
            Vector3 v = new Vector3(0.0f, 0.0f, 0.0f);


            //向いてる方向を初期値に
            myTransform.eulerAngles = v;


            //もし現在地が(0,0,0)なら
            if (mTransform.position == v)
            {
                //すぐに遷移するとPlayerPositionのUpdate()が動かないためReStart時初期位置から開始にならない？
                Invoke(nameof(LoadClearScene), 0.025f);
            }
        }

    }
    private void LoadClearScene() //Clearシーンへ遷移
    {
        SceneManager.LoadScene("ClearScene");
    }
}
       

   


