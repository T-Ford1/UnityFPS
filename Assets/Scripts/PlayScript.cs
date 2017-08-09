using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Button))]
public class PlayScript : MonoBehaviour {

    private Button b;

	// Use this for initialization
	void Start () {
        b = GetComponent<Button>();
        b.onClick.AddListener(() => OnPlayGame());
	}

    public void OnPlayGame()
    {
        LoadingScreen.LoadNewScene();
    }
}
