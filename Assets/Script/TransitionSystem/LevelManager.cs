using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public Slider ProgressBar;
    public GameObject transitionContainer;

    [SerializeField] private SceneTransition[] transitions;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        transitions = transitionContainer.GetComponentsInChildren<SceneTransition>();
    }

    public void LoadScene(string sceneName, string transitionName)
    {
        StartCoroutine(LoadSceneAsync(sceneName, transitionName));
    }

    private IEnumerator LoadSceneAsync(string sceneName, string transitionName)
    {
        SceneTransition transition = transitions.First(t => t.name == transitionName);

        AsyncOperation scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;

        yield return transition.AnimateTransitionIn();

        ProgressBar.gameObject.SetActive(true);

        do
        {
            ProgressBar.value = scene.progress;
            yield return null;
        } while (scene.progress < 0.9f);

        yield return new WaitForSeconds(1f);

        scene.allowSceneActivation = true;

        ProgressBar.gameObject.SetActive(false);

        yield return transition.AnimatorTransitionOut();
    }
}