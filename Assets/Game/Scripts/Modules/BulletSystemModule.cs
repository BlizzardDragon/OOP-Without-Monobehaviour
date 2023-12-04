using FrameworkUnity.OOP.Custom_DI;
using FrameworkUnity.OOP.Custom_DI.Internal;
using ShootEmUp;
using UnityEngine;

public class BulletSystemModule : GameModule
{
    [Service]
    [Listener]
    [SerializeField]
    private BulletPool _pool;

    [Service]
    private BulletSpawner _spawner = new();
    
    [Service]
    private BulletDeactivator _deactivator = new();
    
    [Service]
    private BulletCollisionHandler _collisionHandler = new();
    
    [Listener]
    private BulletDeactivatorController _deactivatorController = new();
    
    [Listener]
    private BulletRemoveObserver _removeObserver = new();
    
    [Listener]
    private BulletSpawnerObserver _spawnerObserver = new();
    
    [Listener]
    private BulletBoundaryChecker _boundaryChecker = new();
}
