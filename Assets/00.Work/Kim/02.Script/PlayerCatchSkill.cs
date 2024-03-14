using DG.Tweening;
using System.Threading.Tasks;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using Sequence = DG.Tweening.Sequence;


public class PlayerCatchSkill : PoolableMono
{
    [SerializeField] private float arrivalTime;
    [SerializeField] private float comeSpeed;
    [SerializeField] private int explosionDamage;
    [SerializeField] private int maxRange;
    [SerializeField] [Range(1, 14)] float range;
    [SerializeField] LayerMask whatIsEnemy;
    [SerializeField] private GameObject _explosion;
    private SpriteRenderer sp;
    private TrailRenderer trailRenderer;
    private Animator animator;
    Enemy enemy;
    Player player;

    private float startXPos;
    private bool isHitEnemy = true;

    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
        trailRenderer = GetComponentInChildren<TrailRenderer>();
        animator = GetComponent<Animator>();
        player = GameManager.Instance.Player;
    }

    private void Start()
    {
        startXPos = transform.position.x;
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
            if ((SkillManager.Instance.GetSkill(PlayerSkill.EnemyAttract) as EnemyAttractSkill).Explosion)
            {
                Instantiate(_explosion, transform.position, Quaternion.identity);
                enemy.HealthCompo.ApplyDamage(explosionDamage, Vector2.zero, Vector2.zero, player);
            }

            transform.DOKill();
            animator.SetTrigger("isCatch");
            enemy.GetComponent<Rigidbody2D>().gravityScale = 0;
            await Task.Delay(500);

            PullEnemy();
        }
    }

    private void PullEnemy()
    {
        float ChkplayerAndskill = transform.position.x - player.Visual.position.x > 0 ? 0 : 180;
        transform.rotation = Quaternion.Euler(0, ChkplayerAndskill, 0);

        enemy.transform.parent = transform;

        float dis = Vector2.Distance(player.Visual.position, enemy.transform.position);
        transform.DOMove(
                new Vector2(player.Visual.position.x + 1.5f * Mathf.Sign(player.Visual.rotation.y),
                    player.Visual.position.y), dis / comeSpeed)
            .OnComplete(async () =>
            {
                enemy.GetComponent<Rigidbody2D>().gravityScale = 4;
                await Task.Delay(1000);
                enemy.transform.parent = null;
                sp.DOFade(0, 0.5f).OnComplete(() =>
                {
                    player.DamageCasterCompo.CanKnockBack = true;

                    PoolManager.Instance.Push(this);
                });
            });
    }

    public override void ResetPooingItem()
    {
        sp.DOFade(1, 0);
        player.DamageCasterCompo.CanKnockBack = false;
        transform.DOMoveX(transform.position.x + maxRange * Mathf.Sign(player.Visual.rotation.y), arrivalTime)
            .SetEase(Ease.Linear);
    }
}