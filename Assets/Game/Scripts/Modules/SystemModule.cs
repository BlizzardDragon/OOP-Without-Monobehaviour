using FrameworkUnity.OOP.Custom_DI;
using FrameworkUnity.OOP.Custom_DI.Internal;

namespace ShootEmUp
{
    public class SystemModule : GameModule
    {
        [Service]
        [Listener]
        private FixedUpdater _fixedUpdater = new();

        private SceneLoader _sceneLoader = new();

        public void Restart() => _sceneLoader.Restart();
    }
}