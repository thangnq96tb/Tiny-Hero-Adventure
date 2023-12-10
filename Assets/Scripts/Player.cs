using System;
using UnityEngine;

namespace TinyHero
{
    public enum Player_ID
    {
        MASK_DUDE,
        NINJA_FROG,
        PINK_MAN,
        VIRTUAL_GUY
    }
    
    [Serializable]
    public class Player
    {
        public Player_ID m_Id;
        public string name = "Mask Dude";

        public Player()
        {
            m_Id = Player_ID.MASK_DUDE;
            name = "Mask Dude";
        }


        public GameObject GetReviveVfx()
        {
            return GameDataManager.Instance.GetPlayerUI(m_Id).m_ReviveVfx;
        }

        public GameObject GetDieVfx()
        {
            return GameDataManager.Instance.GetPlayerUI(m_Id).m_DieVfx;
        }
    }
}