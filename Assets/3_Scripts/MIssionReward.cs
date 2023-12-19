using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Mission Reward")]
public class MIssionReward : ScriptableObject
{
    [SerializeField] private Sprite rewardSprite;
    [SerializeField] private string id;

    public Sprite RewardSprite { get => rewardSprite; }
    public string ID { get => id; }
}
