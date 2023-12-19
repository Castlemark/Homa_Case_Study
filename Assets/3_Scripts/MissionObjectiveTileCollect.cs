using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tile Collect Mission Objective")]
public class MissionObjectiveTileCollect : IMission
{
    public override event Action<IMissionTrackable> OnGamePlayUpdatedEvent;

    [SerializeField] private TowerTile towerTile;
    [SerializeField] private int amountToCollect;
    [SerializeField] private MissionRewardAndAmount missionRewardAndAmount;
    private int amountCollected;
    private bool completed = false;

    public override MissionRewardAndAmount Reward => missionRewardAndAmount;
    public override IMissionTrackable MissionTrackable => towerTile;
    public override bool Completed => completed;


    public override string GetDescription()
    {
        return $"Collect {towerTile.Name} tiles";
    }

    public override Tuple<int, int> GetProgress()
    {
        return new Tuple<int, int>(amountCollected, amountToCollect);
    }

    public override void SetProgress(int amount)
    {
        amountCollected = Mathf.Min(amountCollected + amount, amountToCollect);
        Debug.Log($"progres: {amountCollected}/{amountToCollect}");

        if (amountCollected == amountToCollect) { completed = true; }
    }
}
