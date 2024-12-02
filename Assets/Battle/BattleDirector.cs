using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement; //scene遷移に必要

public class BattleDirector : MonoBehaviour
{
    GameObject MainText;
    GameObject PlayerHpText;
    GameObject PlayerMpText;
    GameObject EnemyHpText;

    public LoadScenes loadScenes;

    public static int TurnCnt; //ターン数カウント

    int PlayerHp;
    int PlayerMp;
    int CostMp;
    int PlayerStrength;
    int PlayerIntelligence;

    private static int EnemyHp;
    private int EnemyStrength;

    //Enemyが受けるダメージ
    private int EnemyDamage;
    private int EnemyMPDamage;

    //Playerが受けるダメージ
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

        //text設定
        this.MainText = GameObject.Find("MainText");
        this.PlayerHpText = GameObject.Find("PlayerHpText");
        this.PlayerMpText = GameObject.Find("PlayerMpText");
        this.EnemyHpText = GameObject.Find("EnemyHpText");

        //初期表示
        this.MainText.GetComponent<TextMeshProUGUI>().text = "行動を選択してください\n\n(ボタンをクリック)";
        this.PlayerHpText.GetComponent<TextMeshProUGUI>().text = "HP:" + PlayerHp.ToString();
        this.PlayerMpText.GetComponent<TextMeshProUGUI>().text = "MP:" + PlayerMp.ToString();
        this.EnemyHpText.GetComponent<TextMeshProUGUI>().text = "HP:" + EnemyHp.ToString();
    }

    public void PlayerAttack()//AttackButton押下時呼び出し 敵ダメージ計算
    {
        if (TurnCnt % 2 == 0)
        {
            TurnCnt++;
            EnemyHp -= EnemyDamage;
            Debug.Log("EnemyHP" + EnemyHp + " " + "turn" + TurnCnt); // ログを出力
            if (EnemyHp <= 0)
            {
                this.EnemyHpText.GetComponent<TextMeshProUGUI>().text = "HP:0";
                this.MainText.GetComponent<TextMeshProUGUI>().text = "Playerの勝利！";
                Invoke(nameof(LoadDungeon), 1.0f);
            }
            else
            {
                this.EnemyHpText.GetComponent<TextMeshProUGUI>().text = "HP:" + EnemyHp.ToString();
                this.MainText.GetComponent<TextMeshProUGUI>().text = "Playerの攻撃！\n\n(Spaceキーで進む)";
            }
        }
    }
    public void PlayerMPAttack()//MPAttackButton押下時呼び出し　敵ダメージ計算
    {
        if (TurnCnt % 2 == 0)
        {
            if (PlayerMp >= CostMp)
            {
                TurnCnt++;
                EnemyHp -= EnemyMPDamage;
                PlayerMp -= CostMp;

                Debug.Log("EnemyHP" + EnemyHp + " " + "PlayerMp" + PlayerMp + "turn" + TurnCnt); // ログを出力
                this.PlayerMpText.GetComponent<TextMeshProUGUI>().text = "MP:" + PlayerMp.ToString();
                this.EnemyHpText.GetComponent<TextMeshProUGUI>().text = "HP:" + EnemyHp.ToString();
                if (EnemyHp <= 0)
                {
                    this.EnemyHpText.GetComponent<TextMeshProUGUI>().text = "HP:0";
                    this.MainText.GetComponent<TextMeshProUGUI>().text = "Playerの勝利！";
                    Invoke(nameof(LoadDungeon), 1.0f);
                }
                else
                {
                    this.EnemyHpText.GetComponent<TextMeshProUGUI>().text = "HP:" + EnemyHp.ToString();
                    this.MainText.GetComponent<TextMeshProUGUI>().text = "PlayerのMP攻撃！\n\n(Spaceキーで進む)";
                }
            }
            else
            {
                this.EnemyHpText.GetComponent<TextMeshProUGUI>().text = "HP:" + EnemyHp.ToString();
                this.MainText.GetComponent<TextMeshProUGUI>().text = "MPが足りない！\n\n(ボタンをクリック)";
            }
        }
    }

    public void Escape() //EscapeButton押下時呼び出し 1/3の確率でDungeonSceneに戻る
    {
        TurnCnt++;

        int rnd = Random.Range(0, 3);
        if (rnd == 0)
        {
            Debug.Log("Random" + rnd);
            this.MainText.GetComponent<TextMeshProUGUI>().text = "うまく逃げ切れた！";
            Invoke(nameof(LoadDungeon), 1.0f);
        }
        else
        {
            Debug.Log("Random" + rnd);
            this.MainText.GetComponent<TextMeshProUGUI>().text = "逃げられない！\n\n(Spaceキーで進む)";
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //Spaceキー押下時呼び出し　Playerダメージ計算
        {
            if (TurnCnt % 2 == 1)
            {
                TurnCnt++;
                PlayerHp -= PlayerDamage;
                Debug.Log("PlayerHP" + PlayerHp + " " + "turn" + TurnCnt); // ログを出力
                this.PlayerHpText.GetComponent<TextMeshProUGUI>().text = "HP:" + PlayerHp.ToString();
                if (PlayerHp > 0)
                {
                    this.MainText.GetComponent<TextMeshProUGUI>().text = "Enemyの攻撃！\n\n(ボタンをクリック)";
                }
                else
                {
                    this.MainText.GetComponent<TextMeshProUGUI>().text = "Playerの敗北！";
                    Invoke(nameof(LoadGameOver), 1.0f);
                }
            }
        }
    }
    private void LoadDungeon() //Dungeonシーンへ遷移
    {
        loadScenes.LoadDungeonScene();
    }
    private void LoadGameOver() //GameOverシーンへ遷移
    {
        loadScenes.LoadGameOverScene();
    }
}
