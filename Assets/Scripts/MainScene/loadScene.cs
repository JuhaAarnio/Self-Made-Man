
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour {

    public string loadedScene = "";

    public void LoadDesiredScene(string sceneName)
    {
        SceneManager.LoadScene(loadedScene);
    }
	
}
