
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoadingScreen : MonoBehaviour {

    [SerializeField]
    private static int LOAD_SCENE_INDEX = 1;
    [SerializeField]
    private static int GAME_SCENE_INDEX = 2;

    private Slider _slider;

    public static void LoadNewScene()
    {
        SceneManager.LoadScene(LOAD_SCENE_INDEX);
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(LOAD_SCENE_INDEX));
    }

    public static void LoadNewScene(int _sceneIndex)
    {
        GAME_SCENE_INDEX = _sceneIndex;
        SceneManager.LoadScene(LOAD_SCENE_INDEX);
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(LOAD_SCENE_INDEX));
    }

    // Use this for initialization
    void Start () {
        _slider = GetComponent<Slider>();
	}

    private AsyncOperation ao;

    private void Update()
    {
        if(ao == null)
        {
            ao = SceneManager.LoadSceneAsync(GAME_SCENE_INDEX);
            ao.allowSceneActivation = false;
            return;
        }

        if (_slider != null)
        {
            _slider.value = Mathf.Clamp01(ao.progress / 0.9f);
        }

        // Loading completed
        if (ao.progress == 0.9f)
        {
            if (Input.anyKeyDown)
            {
                ao.allowSceneActivation = true;

            }
        }
    }
}
