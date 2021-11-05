using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public float sceneChangeCountdown;
    public bool isChangingScene;
    public bool canSceneChange;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        sceneChangeCountdown = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (isChangingScene == true)
        {
            sceneChangeCountdown -= Time.deltaTime;
        }
        if(sceneChangeCountdown <= 0)
        {
            SceneManager.LoadScene(1);
        }
    }
    public void SceneChange()
    {
        anim.SetTrigger("IsNewGame");
        isChangingScene = true;
    }

    public void QuitGame()
    {
        Debug.Log("Bye Bye!");
        Application.Quit();
    }
}
