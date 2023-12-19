using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManagerData
{
    static MissionManagerData m_instance;
    public static MissionManagerData Instance
    {
        get {
            if (m_instance == null)
                m_instance = new MissionManagerData();
            return m_instance;
        }
    }

    public IMission[] selectedMissions;

    public void Initialize()
    {
        if (selectedMissions == null)
        {
            selectedMissions = new IMission[3];
        }
    }
}
