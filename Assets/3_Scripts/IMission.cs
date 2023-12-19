using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IMission : ScriptableObject
{
    public abstract event Action<IMissionTrackable> OnGamePlayUpdatedEvent;

    public abstract MissionRewardAndAmount Reward { get; }
    public abstract IMissionTrackable MissionTrackable { get; }
    public abstract bool Completed { get; }

    public abstract string GetDescription();
    public abstract Tuple<int, int> GetProgress();
    public abstract void SetProgress(int amount);

    [Serializable]
    public struct MissionRewardAndAmount
    {
        public MIssionReward MissionReward;
        public int amount;
    }
}
