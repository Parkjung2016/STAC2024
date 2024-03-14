using DG.Tweening;
using System.Threading.Tasks;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using Sequence = DG.Tweening.Sequence;

public enum HandSkill
{
    Original,
    Conbine
}

public class PlayerCatchSkill : MonoBehaviour
{
    [SerializeField] private float arrivalTime;
    //끌고 오는 속도임. 값을 높일 수록 더 빠르게 옴 ㅇㅇ
    [SerializeField] private float comeSpeed;
    [SerializeField] private int maxRange;
    [SerializeField] private HandSkill handskill;
    [SerializeField][Range(1, 14)] float range;
    [SerializeField] LayerMask whatIsEnemy;

    [Header("FusionSkill")]
    [SerializeField] private GameObject explosion;

    private SpriteRenderer sp;
    private TrailRenderer trailRenderer;
    private Animator animator;
    Enemy enemy;
    Transform playerTrm;

    private float startXPos;
    private bool isHitEnemy = true;

    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
        trailRenderer = GetComponentInChildren<TrailRenderer>();
        animator = GetComponent<Animator>();
        playerTrm = GameManager.Instance.Player.transform.Find("Visual");
    }

    private void Start()
    {
        startXPos = transform.position.x;

        transform.DOMoveX(transform.position.x + maxRange * Mathf.Sign(playerTrm.rotation.y), arrivalTime).SetEase(Ease.Linear);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Hand(collision);
    }

    private void Update()
    {
        float currentDis = transform.position.x - startXPos;

        if (currentDis > range)
        {
            sp.DOFade(0, 0.5f);
            trailRenderer.material.DOFade(0, 0.5f).OnComplete(() => Destroy(gameObject));
        }

        if(enemy != null)
            enemy.StopImmediately(false);
    }

    private async void Hand(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            enemy = col.GetComponent<Enemy>();  

            transform.DOKill();
            animator.SetTrigger("isCatch");
            enemy.GetComponent<Rigidbody2D>().gravityScale = 0;

            if (handskill == HandSkill.Conbine)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
            }

            await Task.Delay(500);

            PullEnemy();

        }
    }

    private void PullEnemy()
    {
        float ChkplayerAndskill = transform.position.x - playerTrm.position.x > 0 ? 0 : 180;
        transform.rotation = Quaternion.Euler(0, ChkplayerAndskill, 0);

        enemy.transform.parent = transform;

        float dis = Vector2.Distance(playerTrm.position, enemy.transform.position);
        transform.DOMove(new Vector2(playerTrm.position.x + 1.5f, playerTrm.position.y), dis / comeSpeed)
            .OnComplete(async () =>
            {
                enemy.GetComponent<Rigidbody2D>().gravityScale = 4;
                await Task.Delay(1000);
                enemy.transform.parent = null;
                sp.DOFade(0, 0.5f).OnComplete(() => Destroy(transform.gameObject));
            });
    }
}

