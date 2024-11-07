using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{

    public int WalkCnt = 0; //�����J�E���g
    bool check;

    int WallCount; //�ǌ��J�E���g



    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        check = true;

        WallCount = GameObject.FindGameObjectsWithTag("Wall").Length;
        Debug.Log(WallCount);

        
        //PlayerCube�̏����ʒu��PlayerPosition.cs����PlayerPos��
        Transform myTransform = this.transform;
        myTransform.position = PlayerPosition.PlayerPos;

        //�����Ă��������PlayerPosition.cs����PlayerWorldAng��
        myTransform.eulerAngles = PlayerPosition.PlayerWorldAng;


    }

    // Update is called once per frame

    void Update()

    {
        check = true;

        Vector3 NextPosition = GameObject.Find("CheckCube").transform.position;
        //Debug.Log("nextpos" + NextPosition + "check: " + check);



        if (Input.GetKeyDown(KeyCode.UpArrow)) //�O�ɐi��
        {
            for (int i = 1; i < WallCount; i++)
            {
                Vector3 FirstWallPos = GameObject.Find("WallCubePrefab").transform.position;
                if (NextPosition == FirstWallPos)
                {
                    check = false; break;
                }
                Vector3 WallPosition = GameObject.Find("WallCubePrefab (" + i + ")").transform.position;
                if (WallPosition == NextPosition) //�ǂ̍��W�̂ǂꂩ�ƈړ��悪��v������false
                {
                    check = false;
                }
            }

            if (check == true) //�ړ��悪��Ȃ�P�}�X�ړ�
            {
                transform.Translate(0, 0, 1);
                WalkCnt += 1;
            }
        }



        if (Input.GetKeyDown(KeyCode.RightArrow)) //�E����
        {
            transform.Rotate(0, 90, 0);

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) //������
        {
            transform.Rotate(0, -90, 0);
        }


        //20����������퓬�V�[����
        if (WalkCnt == 20)
        { 
           SceneManager.LoadScene("BattleScene");
        }



        Vector3 ApplePosition = GameObject.Find("apple").transform.position;
        Transform myTransform = this.transform;
        Vector3 MyTransform = myTransform.position;
        //�������ݒn���ь�̈ʒu�Ɠ����Ȃ�
        if (MyTransform == ApplePosition)
        {
            //���ݒn�������ʒu(0,0,0)��
            Transform mTransform = this.transform;
            Vector3 worldPos = mTransform.position;
            worldPos.x = 0.0f;
            worldPos.y = 0.0f;
            worldPos.z = 0.0f;
            mTransform.position = worldPos;


            //�����l(0,0,0)
            Vector3 v = new Vector3(0.0f, 0.0f, 0.0f);


            //�����Ă�����������l��
            myTransform.eulerAngles = v;


            //�������ݒn��(0,0,0)�Ȃ�
            if (mTransform.position == v)
            {
                //�����ɑJ�ڂ����PlayerPosition��Update()�������Ȃ�����ReStart�������ʒu����J�n�ɂȂ�Ȃ��H
                Invoke(nameof(LoadClearScene), 0.025f);
            }
        }

    }
    private void LoadClearScene() //Clear�V�[���֑J��
    {
        SceneManager.LoadScene("ClearScene");
    }
}
       

   


