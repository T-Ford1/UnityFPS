using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Button))]
public class PlayScript : MonoBehaviour {

    [SerializeField]
    private int loadingScreenIndex;
    [SerializeField]
    private int gameSceneIndex;

    private Button b;

	// Use this for initialization
	void Start () {
        b = GetComponent<Button>();
        b.onClick.AddListener(() => OnPlayGame());
	}

    void OnPlayGame()
    {
        SceneManager.LoadScene(loadingScreenIndex);
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(loadingScreenIndex));

        StartCoroutine(AsynchronousLoad(gameSceneIndex));
    }

    IEnumerator AsynchronousLoad(int sceneIndex)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(sceneIndex);
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
