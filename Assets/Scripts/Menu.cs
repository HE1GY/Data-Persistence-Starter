using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;


public class Menu : MonoBehaviour
{
    [SerializeField] private Text _bestScore;
    [SerializeField] private Text _inputName;
    

    public void CheckName()
    {
        print(MyManager.instance.bestName);
        print(_inputName.text);
        if (MyManager.instance.bestName == _inputName.text)
        {
            
            _bestScore.text = "Best Score:" + MyManager.instance.bestScore;
        }    
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        MyManager.instance.currName = _inputName.text;
    }
    public void Quite()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    public void DeleteRecorde()
    {
        MyManager.instance.ResetRecords();
    }
}
