using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    [SerializeField] GameObject uiManager;         //Don't even need this right? Why do I need the SM attached to ScenesManager object?

    public static ScenesManager scenesManager;
    public static UIManager uIManager;

    private void Awake()
    {
        scenesManager = this;
    }

    /*      What should I destroy when the game ain't running/on QuitGema button?
    private void OnDestroy()
    {
        if (SceneManager.sceneCountInBuildSettings == 4);
    }
    */

    public enum Scene       //Constants to access the right scens to load, ordered & named as in the BuildIndex
    {
        CourtOne,
        CourtTwo,
        CourtThree
    }

    public void LoadScene(Scene scene)      //Gets the Scene I want to load, to pass it into the scene that I want
    {
        SceneManager.LoadScene(scene.ToString());      
    }

    public void LoadNewGame()
    {
        SceneManager.LoadScene(Scene.CourtOne.ToString());
        uIManager.Awake();
    }

    public void LoadNextScene()     //TODO, If buildindex > 3 then pause the scene, show Game result, display restart button
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
