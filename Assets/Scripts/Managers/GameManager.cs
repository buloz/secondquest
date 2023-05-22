using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField]
    private GameState defaultState;

    public GameState GameState { get; private set; }

    public LevelManager LevelManager;

    public PlayerManager PlayerManager;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        GameState = Instantiate(defaultState); 

        LevelManager.GameState = GameState;
        PlayerManager.GameState = GameState;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
