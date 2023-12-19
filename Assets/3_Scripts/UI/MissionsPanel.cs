using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MissionsPanel : MonoBehaviour
{
    [SerializeField] private List<MissionTexts> missionTexts;

    void Awake()
    {
        MissionManager.Instance.MissionsRefilledEvent += UpdateMissions;
        MissionManager.Instance.MissionsUpdatedEvent += UpdateMissions;
    }

    private void UpdateMissions(IMission[] missions)
    {
        int min = Mathf.Min(missionTexts.Count, missions.Length);
        for (int i = 0; i < min; i++)
        {
            Tuple<int, int> progress = missions[i].GetProgress();
            string progressText = $"{progress.Item1}/{progress.Item2}";
            missionTexts[i].SetTextsContent(missions[i].GetDescription(), progressText);
        }
    }

    [Serializable]
    struct MissionTexts
    {
        public TMP_Text Description;
        public TMP_Text Progress;

        public void SetTextsContent(string description, string progress)
        {
            Description.text = description;
            Progress.text = progress;
        }
    }
}
