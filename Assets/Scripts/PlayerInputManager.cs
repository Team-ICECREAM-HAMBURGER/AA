using UnityEngine;

public class PlayerInputManager : GCSingletonImplementer<PlayerInputManager> {
    [SerializeField] private bool useWebController;

    private Camera _mainCamera;
    private Vector2 _playerPosition;
    
    public IInputProvider CurrentInputProvider { get; private set; }
    
    
    private void Init() {
        this._mainCamera = Camera.main;
        this._playerPosition = this.transform.position;
        
        this.CurrentInputProvider = (this.useWebController) ? 
            new InputProviderWebStrategy() : new InputProviderPCStrategy(this._mainCamera, this._playerPosition);
    }

    private void Awake() {
        Init();
    }
}