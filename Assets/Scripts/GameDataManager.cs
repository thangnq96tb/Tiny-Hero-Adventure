using TinyHero;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : Singleton<GameDataManager>
{
    private readonly SCR_PlayersInfo m_PlayersInfo;

    public GameDataManager()
    {
        m_PlayersInfo = Resources.Load<SCR_PlayersInfo>("PlayersInfo");
    }

    public PlayerUI GetPlayerUI(Player_ID id)
    {
        return m_PlayersInfo.m_PlayerUIs.Find((x) => x.m_Id == id);
    }

}
