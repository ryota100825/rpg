using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{

    public void startbutton()
    { //自分の好きな関数名でok

        SceneManager.LoadScene("Main");

    }
    //　ゲーム終了ボタンを押したら実行する
    public void GameEnd()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
    }
}