using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement; //scene遷移に必要

public class BattleDirector : MonoBehaviour
{
    GameObject MainText;
    GameObject PlayerHpText;
    GameObject PlayerMpText;
    GameObject EnemyHpText;

    public static int TurnCnt; //ターン数カウント

    private static int PlayerHp;
    private static int PlayerMp;
    private int CostMp;
    private int PlayerStrength;
    private int PlayerIntelligence;

    private static int EnemyHp;
    private int EnemyStrength;

    //Enemyが受けるダメージ
    private int EnemyDamage;
    private int EnemyMPDamage;

    //Playerが受けるダメージ
    private int PlayerDamage;

  

    private void Start()
    {
        TurnCnt = 0;

        PlayerHp = PlayerStatus.hp;
        PlayerMp = PlayerStatus.mp;
        PlayerStrength = PlayerStatus.strength;
        PlayerIntelligence = PlayerStatus.intelligence;
        CostMp = PlayerStatus.costMp;

        EnemyHp = EnemyStatus.hp;
        EnemyStrength = EnemyStatus.strength;



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
                Invoke(nameof(LoadDungeonScene), 1.0f);
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
                    Invoke(nameof(LoadDungeonScene), 1.0f);
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
        if(rnd == 0)
        {
            Debug.Log("Random" + rnd);
            this.MainText.GetComponent<TextMeshProUGUI>().text = "うまく逃げ切れた！";
            Invoke(nameof(LoadDungeonScene), 1.0f);
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
                    
                    Invoke(nameof(LoadGameOverScene), 1.0f);

                }
            }
        }
    }


     private void LoadDungeonScene() //Dungeonシーンへ遷移
    {
        SceneManager.LoadScene("DungeonScene");
    }

    
    private void LoadGameOverScene() //GameOverシーンへ遷移
    {
        SceneManager.LoadScene("GameOverScene");
    }

}
