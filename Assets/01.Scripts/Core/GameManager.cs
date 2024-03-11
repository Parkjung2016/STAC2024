using cherrydev;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] private Player _player;
    public Transform PlayerTrm => _player.transform;
    public Player Player => _player;

    private Camera _mainCam;

    public Camera MainCam
    {
        get
        {
            if (_mainCam == null)
            {
                _mainCam = Camera.main;
            }

            return _mainCam;
        }
    }


    [SerializeField] private PoolingListSO _poolingList;
    [SerializeField] private Transform _poolingTrm;

    public DialogBehaviour DialogBehaviour { get; private set; }

    private void Awake()
    {
        DialogBehaviour = FindObjectOfType<DialogBehaviour>();
        PoolManager.Instance = new PoolManager(_poolingTrm);
        foreach (PoolingPair pair in _poolingList.list)
        {
            PoolManager.Instance.CreatePool(pair.prefab, pair.type, pair.count);
        }

        DOTween.Init(recycleAllByDefault: true, useSafeMode: true, LogBehaviour.Verbose).SetCapacity(400, 100);
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneList.GameScene.ToString());
    }
}