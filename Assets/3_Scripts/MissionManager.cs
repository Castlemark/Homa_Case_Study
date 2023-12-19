using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class MissionManager : Singleton<MissionManager>
{
    public event Action<IMission[]> MissionsRefilledEvent;
    public event Action<IMission[]> MissionsUpdatedEvent;
    public event Action<IMission> MissionCompletedEvent;

    [SerializeField] List<IMission> missionList;

    void Awake()
    {
        MissionManagerData.Instance.Initialize();
        RefillMissions();

        MissionsRefilledEvent?.Invoke(MissionManagerData.Instance.selectedMissions);
    }

    private void RefillMissions()
    {
        if (MissionManagerData.Instance.selectedMissions.All((mission) => mission != null) 
        && MissionManagerData.Instance.selectedMissions.Any((mission) => !mission.Completed))
        {
            return;
        }

        for (int i = 0; i < MissionManagerData.Instance.selectedMissions.Length; i++)
        {
            int randomIndex = Random.Range(0, missionList.Count);
            IMission instantiatedMission = Instantiate(missionList[randomIndex]);
            MissionManagerData.Instance.selectedMissions[i] = instantiatedMission;
        }
    }

    public void UpdateMission(IMissionTrackable missionTrackable)
    {
        foreach (IMission mission in MissionManagerData.Instance.selectedMissions)
        {
            if (mission.MissionTrackable.ID == missionTrackable.ID && !mission.Completed)
            {
                mission.SetProgress(1);

                if (mission.Completed) { MissionCompletedEvent?.Invoke(mission); }
            }
        }

        MissionsUpdatedEvent?.Invoke(MissionManagerData.Instance.selectedMissions);
    }
}
