using UnityEngine;

public class WelcomeManager : MonoBehaviour {
    public GameObject menuUI;
	public void ShowMenu()
    {
        gameObject.SetActive(false);
        menuUI.SetActive(true);
    }
}
