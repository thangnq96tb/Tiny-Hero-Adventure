using System.Collections.Generic;
using TinyHero;
using UnityEngine;
using System;

[Serializable]
public class PlayerUI
{
    public Player_ID m_Id;
    public GameObject m_ReviveVfx;
    public GameObject m_DieVfx;
}

[CreateAssetMenu(fileName = "PlayersInfo", menuName = "ScriptableObjects/PlayersInfo", order = 1)]
public class SCR_PlayersInfo : ScriptableObject
{
    public List<PlayerUI> m_PlayerUIs;
}
