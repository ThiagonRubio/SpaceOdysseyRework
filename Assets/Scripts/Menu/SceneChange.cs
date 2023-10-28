using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string sceneName;

    public void ChangeToDesiredScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
