using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "GameSceneSetting")]
public class GameSceneSetting : ScriptableObject
{
    static GameSceneSetting GameDate;

    public static GameSceneSetting data
    {
        get
        {
            if (GameDate == null)
            {
                GameDate = Resources.Load<GameSceneSetting>("GameSceneSetting");
            }
            return GameDate;
        }
    }
    public GamePlayerData[] gamePlayerData;
}

[System.Serializable]
public class GamePlayerData
{
    public string name;
    public int currentTotalCards;
    public List<GameObject> currentCards;
    public List<GameObject> totalCards;
}