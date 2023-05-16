using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBtn : MonoBehaviour
{
    public void OnStartBtn()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OnQuitBtn()
    {
        Application.Quit();
    }
}
