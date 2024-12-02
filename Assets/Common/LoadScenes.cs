using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    public void LoadDungeonScene() //Dungeonシーンへ遷移
    {
        SceneManager.LoadScene("DungeonScene");
    }
    public void LoadBattleScene() //Battleシーンへ遷移
    {
        SceneManager.LoadScene("BattleScene");
    }
    public void LoadGameOverScene() //GameOverシーンへ遷移
    {
        SceneManager.LoadScene("GameOverScene");
    }
    public void LoadClearScene() //Clearシーンへ遷移
    {
        SceneManager.LoadScene("ClearScene");
    }
}
