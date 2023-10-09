using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersManager : MonoBehaviour
{
    //This is where I'd insta ntiate the amount of players based on which onClick event happend in "SelectPlayers" - GamesManager???
    
    public static GamesManager Instance;

    [SerializeField] public List<Car> _players;


    void Awake()
    {
        //Instance = this;
    }
    

}
