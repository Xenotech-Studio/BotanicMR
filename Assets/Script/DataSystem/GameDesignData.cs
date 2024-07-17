using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataSystem
{
    public class GameDesignData : ReadableData
    {
        public override string Path => System.IO.Path.Combine(Application.dataPath, "Resources/GameDesignData.json");

        public static GameDesignData Instance
        {
            get => _instance ??= new GameDesignData().DeSerialization<GameDesignData>();
            set => _instance = value;
        }
        private static GameDesignData _instance;
    }
}
