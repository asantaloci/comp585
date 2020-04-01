using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
      public void GotoLogin()
    {
        Authentication.LogoutPlayer();
        SceneManager.LoadScene("logIn");
    }
    public void GotoAdoptionCenter()
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
      public void GotoBlank()
    {
        SceneManager.LoadScene("setting");
    }
}
