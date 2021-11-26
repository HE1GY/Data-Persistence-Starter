using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Text _score;


    private void Start()
    {
        if (MyManager.instance)
        {
            _score.text = $"Best Score : { MyManager.instance.bestName} : {MyManager.instance.bestScore}";
        }
    }
    public void RefreshbestPoint(int point)
    {
        if (MyManager.instance)
        {
            if (point > MyManager.instance.bestScore) 
            {
                MyManager.instance.bestScore = point;
                MyManager.instance.bestName=MyManager.instance.currName;
                MyManager.instance.SaveNameAndScore(MyManager.instance.bestName, MyManager.instance.bestScore);
            }
            _score.text = $"Best Score : { MyManager.instance.bestName} : {MyManager.instance.bestScore}";
        }      
    }
}
