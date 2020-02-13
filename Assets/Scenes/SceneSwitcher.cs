using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void GotoMainScene()
    {
        SceneManager.LoadScene("adoption-center");
    }

    public void GotoMenuScene()
    {
        SceneManager.LoadScene("house");
    }
}
