using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public Dungeon dungeon;
    public LoadScenes loadScenes;
    public Find find;

    GameObject WalkCountDownText;

    public int WalkCntDown = 20; //歩数カウント

    void Start()
    {
        dungeon.WallCount = GameObject.FindGameObjectsWithTag("Wall").Length;

        //Battleまでの残り歩数
        this.WalkCountDownText = GameObject.Find("WalkCountDownText");
        this.WalkCountDownText.GetComponent<TextMeshProUGUI>().text = WalkCntDown.ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) //前に進む
        {
            dungeon.PositionCheck(); //移動先が空かどうかチェック

            if (dungeon.check == true) //移動先が空なら１マス移動
            {
                transform.Translate(0, 0, 1);
                WalkCntDown -= 1;
                this.WalkCountDownText.GetComponent<TextMeshProUGUI>().text = WalkCntDown.ToString();
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

        if (WalkCntDown == 0) //20歩歩いたら戦闘シーンへ
        {
            loadScenes.LoadBattleScene();
        }

        Vector3 ApplePosition = find.find("apple");
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
                Invoke(nameof(LoadClear), 0.02f);
            }
        }
    }
    private void LoadClear() //Clearシーンへ遷移
    {
        loadScenes.LoadClearScene();
    }
}




