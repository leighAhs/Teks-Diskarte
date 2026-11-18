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
    public TeksCardsData[] teksCardData;
}

[System.Serializable]
public class GamePlayerData
{
    public string name;
    public int currentTotalCards;
    public List<GameObject> currentCards;
    public List<GameObject> totalCards;
}

[System.Serializable]
public class TeksCardsData
{
    public string cardHolderName;
    public string cardRarity;
    public string teksAbility;
    public int attackCount;
    public int blockCount;
    public int healCount;
}