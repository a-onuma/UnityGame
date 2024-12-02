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

    public int WalkCntDown = 20; //�����J�E���g

    void Start()
    {
        dungeon.WallCount = GameObject.FindGameObjectsWithTag("Wall").Length;

        //Battle�܂ł̎c�����
        this.WalkCountDownText = GameObject.Find("WalkCountDownText");
        this.WalkCountDownText.GetComponent<TextMeshProUGUI>().text = WalkCntDown.ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) //�O�ɐi��
        {
            dungeon.PositionCheck(); //�ړ��悪�󂩂ǂ����`�F�b�N

            if (dungeon.check == true) //�ړ��悪��Ȃ�P�}�X�ړ�
            {
                transform.Translate(0, 0, 1);
                WalkCntDown -= 1;
                this.WalkCountDownText.GetComponent<TextMeshProUGUI>().text = WalkCntDown.ToString();
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

        if (WalkCntDown == 0) //20����������퓬�V�[����
        {
            loadScenes.LoadBattleScene();
        }

        Vector3 ApplePosition = find.find("apple");
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
                Invoke(nameof(LoadClear), 0.02f);
            }
        }
    }
    private void LoadClear() //Clear�V�[���֑J��
    {
        loadScenes.LoadClearScene();
    }
}




