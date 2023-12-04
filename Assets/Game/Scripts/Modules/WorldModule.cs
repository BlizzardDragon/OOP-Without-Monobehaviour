using FrameworkUnity.OOP.Custom_DI;
using FrameworkUnity.OOP.Custom_DI.Internal;
using UnityEngine;

namespace ShootEmUp
{
    public class WorldModule : GameModule
    {
        [Service]
        [SerializeField] 
        private LevelBounds _levelBounds;
    
        [Listener]
        [SerializeField] 
        private LevelBackground _levelBackground;
    }
}