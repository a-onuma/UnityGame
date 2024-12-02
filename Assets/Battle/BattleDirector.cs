using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement; //scene�J�ڂɕK�v

public class BattleDirector : MonoBehaviour
{
    GameObject MainText;
    GameObject PlayerHpText;
    GameObject PlayerMpText;
    GameObject EnemyHpText;

    public LoadScenes loadScenes;

    public static int TurnCnt; //�^�[�����J�E���g

    int PlayerHp;
    int PlayerMp;
    int CostMp;
    int PlayerStrength;
    int PlayerIntelligence;

    private static int EnemyHp;
    private int EnemyStrength;

    //Enemy���󂯂�_���[�W
    private int EnemyDamage;
    private int EnemyMPDamage;

    //Player���󂯂�_���[�W
    private int PlayerDamage;

    [SerializeField] PlayerStatus playerStatus;
    [SerializeField] EnemyStatus enemyStatus;

    void Start()
    {
        TurnCnt = 0;

        //PlayerStatus
        PlayerHp = playerStatus.hp;
        PlayerMp = playerStatus.mp;
        PlayerStrength = playerStatus.strength;
        PlayerIntelligence = playerStatus.intelligence;
        CostMp = playerStatus.costMp;

        //EnemyStatus
        EnemyHp = enemyStatus.hp;
        EnemyStrength = enemyStatus.strength;

        //Damege
        EnemyDamage = PlayerStrength * 10;
        EnemyMPDamage = PlayerIntelligence * 10;
        PlayerDamage = EnemyStrength * 10;

        //text�ݒ�
        this.MainText = GameObject.Find("MainText");
        this.PlayerHpText = GameObject.Find("PlayerHpText");
        this.PlayerMpText = GameObject.Find("PlayerMpText");
        this.EnemyHpText = GameObject.Find("EnemyHpText");

        //�����\��
        this.MainText.GetComponent<TextMeshProUGUI>().text = "�s����I�����Ă�������\n\n(�{�^�����N���b�N)";
        this.PlayerHpText.GetComponent<TextMeshProUGUI>().text = "HP:" + PlayerHp.ToString();
        this.PlayerMpText.GetComponent<TextMeshProUGUI>().text = "MP:" + PlayerMp.ToString();
        this.EnemyHpText.GetComponent<TextMeshProUGUI>().text = "HP:" + EnemyHp.ToString();
    }

    public void PlayerAttack()//AttackButton�������Ăяo�� �G�_���[�W�v�Z
    {
        if (TurnCnt % 2 == 0)
        {
            TurnCnt++;
            EnemyHp -= EnemyDamage;
            Debug.Log("EnemyHP" + EnemyHp + " " + "turn" + TurnCnt); // ���O���o��
            if (EnemyHp <= 0)
            {
                this.EnemyHpText.GetComponent<TextMeshProUGUI>().text = "HP:0";
                this.MainText.GetComponent<TextMeshProUGUI>().text = "Player�̏����I";
                Invoke(nameof(LoadDungeon), 1.0f);
            }
            else
            {
                this.EnemyHpText.GetComponent<TextMeshProUGUI>().text = "HP:" + EnemyHp.ToString();
                this.MainText.GetComponent<TextMeshProUGUI>().text = "Player�̍U���I\n\n(Space�L�[�Ői��)";
            }
        }
    }
    public void PlayerMPAttack()//MPAttackButton�������Ăяo���@�G�_���[�W�v�Z
    {
        if (TurnCnt % 2 == 0)
        {
            if (PlayerMp >= CostMp)
            {
                TurnCnt++;
                EnemyHp -= EnemyMPDamage;
                PlayerMp -= CostMp;

                Debug.Log("EnemyHP" + EnemyHp + " " + "PlayerMp" + PlayerMp + "turn" + TurnCnt); // ���O���o��
                this.PlayerMpText.GetComponent<TextMeshProUGUI>().text = "MP:" + PlayerMp.ToString();
                this.EnemyHpText.GetComponent<TextMeshProUGUI>().text = "HP:" + EnemyHp.ToString();
                if (EnemyHp <= 0)
                {
                    this.EnemyHpText.GetComponent<TextMeshProUGUI>().text = "HP:0";
                    this.MainText.GetComponent<TextMeshProUGUI>().text = "Player�̏����I";
                    Invoke(nameof(LoadDungeon), 1.0f);
                }
                else
                {
                    this.EnemyHpText.GetComponent<TextMeshProUGUI>().text = "HP:" + EnemyHp.ToString();
                    this.MainText.GetComponent<TextMeshProUGUI>().text = "Player��MP�U���I\n\n(Space�L�[�Ői��)";
                }
            }
            else
            {
                this.EnemyHpText.GetComponent<TextMeshProUGUI>().text = "HP:" + EnemyHp.ToString();
                this.MainText.GetComponent<TextMeshProUGUI>().text = "MP������Ȃ��I\n\n(�{�^�����N���b�N)";
            }
        }
    }

    public void Escape() //EscapeButton�������Ăяo�� 1/3�̊m����DungeonScene�ɖ߂�
    {
        TurnCnt++;

        int rnd = Random.Range(0, 3);
        if (rnd == 0)
        {
            Debug.Log("Random" + rnd);
            this.MainText.GetComponent<TextMeshProUGUI>().text = "���܂������؂ꂽ�I";
            Invoke(nameof(LoadDungeon), 1.0f);
        }
        else
        {
            Debug.Log("Random" + rnd);
            this.MainText.GetComponent<TextMeshProUGUI>().text = "�������Ȃ��I\n\n(Space�L�[�Ői��)";
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //Space�L�[�������Ăяo���@Player�_���[�W�v�Z
        {
            if (TurnCnt % 2 == 1)
            {
                TurnCnt++;
                PlayerHp -= PlayerDamage;
                Debug.Log("PlayerHP" + PlayerHp + " " + "turn" + TurnCnt); // ���O���o��
                this.PlayerHpText.GetComponent<TextMeshProUGUI>().text = "HP:" + PlayerHp.ToString();
                if (PlayerHp > 0)
                {
                    this.MainText.GetComponent<TextMeshProUGUI>().text = "Enemy�̍U���I\n\n(�{�^�����N���b�N)";
                }
                else
                {
                    this.MainText.GetComponent<TextMeshProUGUI>().text = "Player�̔s�k�I";
                    Invoke(nameof(LoadGameOver), 1.0f);
                }
            }
        }
    }
    private void LoadDungeon() //Dungeon�V�[���֑J��
    {
        loadScenes.LoadDungeonScene();
    }
    private void LoadGameOver() //GameOver�V�[���֑J��
    {
        loadScenes.LoadGameOverScene();
    }
}
