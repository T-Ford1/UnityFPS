using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public MatchSettings matchSettings;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("more than one game manager in scene");
        }
        else
        {
            instance = this;
        }
    }


    #region Player tracking

    private const string PLAYER_ID_PREFIX = "Player ";

    private static Dictionary<string, Player> players = new Dictionary<string, Player>();

    public static void RegisterPlayer(string _netID, Player _player) 
    {
        string _playerID = PLAYER_ID_PREFIX + _netID;
        players.Add(_playerID, _player);
        _player.name = _playerID;
    }

    public static void UnRegisterPlayer(string _netID)
    {
        players.Remove(_netID);
    }

    //void OnGUI()
    //{
    //    GUILayout.BeginArea( new Rect(200, 200, 200, 500));

    //    GUILayout.BeginVertical();

    //    foreach(string _playerID in players.Keys)
    //    {
    //        GUILayout.Label(_playerID + "  -  " + players[_playerID].name);
    //    }
    //    GUILayout.EndVertical();
    //    GUILayout.EndArea();
    //}

    
    public static Player GetPlayer(string _playerID)
    {
        /*
        Player _player;
        if(players.TryGetValue(_playerID, out _player))
  {
      return _player;
  }
        return null;
        */
        return players[_playerID];
    }

    #endregion

}
