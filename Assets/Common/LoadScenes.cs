using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    public void LoadDungeonScene() //Dungeon�V�[���֑J��
    {
        SceneManager.LoadScene("DungeonScene");
    }
    public void LoadBattleScene() //Battle�V�[���֑J��
    {
        SceneManager.LoadScene("BattleScene");
    }
    public void LoadGameOverScene() //GameOver�V�[���֑J��
    {
        SceneManager.LoadScene("GameOverScene");
    }
    public void LoadClearScene() //Clear�V�[���֑J��
    {
        SceneManager.LoadScene("ClearScene");
    }
}
