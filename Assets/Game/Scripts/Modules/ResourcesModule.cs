using FrameworkUnity.OOP.Custom_DI;
using FrameworkUnity.OOP.Custom_DI.Internal;

namespace ShootEmUp
{
    public class ResourcesModule :GameModule
    {
        [Service]
        [Listener]
        private ScoreManager _scoreManager = new();
    }
}