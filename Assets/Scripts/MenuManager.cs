using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public void LoadScene(int number) {
        string sceneName = "Scene" + number;
        SceneManager.LoadScene(sceneName);
    }
}
