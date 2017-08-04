using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Button))]
public class PlayScript : MonoBehaviour {

    [SerializeField]
    private string loadingScreenName;
    [SerializeField]
    private string gameSceneName;

    private Button b;

	// Use this for initialization
	void Start () {
        b = GetComponent<Button>();
        b.onClick.AddListener(() => OnButtonClick());
	}

    void OnButtonClick()
    {
        Scene _load = SceneManager.CreateScene(loadingScreenName);
        SceneManager.LoadScene(loadingScreenName);
        SceneManager.SetActiveScene(_load);

        Scene _game = SceneManager.CreateScene(gameSceneName);
        SceneManager.LoadScene(gameSceneName);
        SceneManager.SetActiveScene(_game);

        //AsynchronousLoad();
    }

    IEnumerator AsynchronousLoad(string scene)
    {
        yield return null;

        AsyncOperation ao = SceneManager.LoadSceneAsync(scene);
        ao.allowSceneActivation = false;

        while (!ao.isDone)
        {
            // [0, 0.9] > [0, 1]
            float progress = Mathf.Clamp01(ao.progress / 0.9f);
            Debug.Log("Loading progress: " + (progress * 100) + "%");

            // Loading completed
            if (ao.progress == 0.9f)
            {
                Debug.Log("Press a key to start");
                if (Input.anyKey)
                    ao.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
