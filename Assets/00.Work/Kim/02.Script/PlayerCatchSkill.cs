using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerCatchSkill : MonoBehaviour
{
    [SerializeField] private float arrivalTime;
    //끌고 오는 속도임. 값을 높일 수록 더 빠르게 옴 ㅇㅇ
    [SerializeField] private float comeSpeed;
    [SerializeField] private int maxRange;
    [SerializeField][Range(1, 14)] float range;
    [SerializeField] LayerMask whatIsEnemy;

    private DamageCaster damageCaster;
    private SpriteRenderer sp;
    private TrailRenderer trailRenderer;
    private Animator animator;
    private Vector2 defaultKnockbackPower;
    Enemy enemy;
    Transform playerVisual;
    Player player;

    private float startXPos;
    public bool isCatchEnemy { get; private set; }

    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
        trailRenderer = GetComponentInChildren<TrailRenderer>();
        animator = GetComponent<Animator>();
        player = GameManager.Instance.Player;
        playerVisual = player.transform.Find("Visual");
        damageCaster = player.transform.GetComponentInChildren<DamageCaster>();

        defaultKnockbackPower = damageCaster.knockbackPower;
    }

    private void Start()
    {
        startXPos = transform.position.x;

        transform.DOMoveX(transform.position.x + maxRange * Mathf.Sign(playerVisual.rotation.y), arrivalTime).SetEase(Ease.Linear);
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

        if (enemy != null)
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
            enemy.AnimatorCompo.speed = 0;

            damageCaster.knockbackPower = Vector2.zero;

            isCatchEnemy = true;

            await Task.Delay(500);

            PullEnemy();
        }
    }

    private void PullEnemy()
    {
        float ChkplayerAndskill = transform.position.x - player.transform.position.x > 0 ? 180 : 0;
        print(ChkplayerAndskill);
        transform.rotation = Quaternion.Euler(0, ChkplayerAndskill, 0);

        enemy.transform.parent = transform;
        enemy.transform.localPosition = Vector2.zero;

        float dis = Vector2.Distance(player.transform.position, enemy.transform.position);
        transform.DOMove(new Vector2(player.transform.position.x + 1.5f, player.transform.position.y), dis / comeSpeed)
            .OnComplete(async () =>
            {
                await Task.Delay(1000);
                enemy.transform.parent = null;
                enemy.AnimatorCompo.speed = 1f;
                damageCaster.knockbackPower = defaultKnockbackPower;
                enemy.GetComponent<Rigidbody2D>().gravityScale = 4;

                isCatchEnemy = false;

                sp.DOFade(0, 0.5f).OnComplete(() => Destroy(transform.gameObject));
            });
    }
}

