using UnityEngine;
using UnityEngine.SceneManagement;

public class ReStartButtonController : MonoBehaviour
{
   public void ReStartButton()
    {
        SceneManager.LoadScene("StartScene");
    }
}
