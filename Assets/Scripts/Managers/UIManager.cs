using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Button playerOne;
    //[SerializeField] Button playerTwo;


    void Start()
    {
        playerOne.onClick.AddListener(PlayerSelectOne);
    }

    private void PlayerSelectOne()
    {
        ScenesManager.Instance.LoadScene(ScenesManager.Scene.CourtOne);
    }

    /*
    private void PlayerSelectTwo()
    {

    }
    */
    
}
