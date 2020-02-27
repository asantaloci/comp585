using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void GotoMainScene()
    {
        SceneManager.LoadScene("adoption-center-dialogue");
    }

    public void GotoRoomScene()
    {
        SceneManager.LoadScene("room");
    }

    public void GotoInterview()
    {
        SceneManager.LoadScene("adoption-interview");
    }
}
