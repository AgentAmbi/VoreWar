﻿using OdinSerializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class SpawnerInfo
{
    [OdinSerialize]
    internal bool Enabled;
    [OdinSerialize]
    internal int MaxArmies;
    [OdinSerialize]
    internal int MinArmySize;
    [OdinSerialize]
    internal int MaxArmySize;
    [OdinSerialize]
    internal float spawnRate;
    [OdinSerialize]
    internal float scalingFactor;
    [OdinSerialize]
    internal int Team;
    [OdinSerialize]
    internal int SpawnAttempts;
    [OdinSerialize]
    internal int TurnOrder;
    [OdinSerialize]
    internal bool AddOnRace;
    [OdinSerialize]
    internal bool UsingCustomType;
    [OdinSerialize]
    internal Config.MonsterConquestType ConquestType;

    internal Config.MonsterConquestType GetConquestType()
    {
        return UsingCustomType ? ConquestType : Config.MonsterConquest;
    }


    public SpawnerInfo(bool enabled, int maxArmies, float spawnRate, float scalingFactor, int team, int spawnAttempts, bool addOnRace, int minArmySize, int maxArmySize, int turnOrder)
    {
        Enabled = enabled;
        MaxArmies = maxArmies;
        this.spawnRate = spawnRate;
        this.scalingFactor = scalingFactor;
        Team = team;
        SpawnAttempts = spawnAttempts;
        AddOnRace = addOnRace;
        MinArmySize = minArmySize;
        MaxArmySize = maxArmySize;
        TurnOrder = turnOrder;
    }

    public void SetSpawnerType(Config.MonsterConquestType conquestType)
    {
        ConquestType = conquestType;
        UsingCustomType = true;
    }

   
}

