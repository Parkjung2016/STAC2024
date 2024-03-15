using System;
using Cinemachine.Utility;
using UnityEditor;
using UnityEngine;

public class Projectile : PoolableMono
{
    [SerializeField] private float _projectileSpeed = 3;
    [SerializeField] private float _intersection = 30;
    [SerializeField] private int _damage = 5;
    [SerializeField] private GameObject _explosionPF;
    [SerializeField] private float _castRadius;
    [SerializeField] private LayerMask _whatIsEnemy;
    private Player _player;
    private float _projectileDir;
    private Vector3 originPos;

    private Collider2D[] _hitResult = new Collider2D[1];

    private void Awake()
    {
        _player = GameManager.Instance.Player;
    }

    private void Update()
    {
        if (CastDamage())
        {
            Instantiate(_explosionPF, _hitResult[0].transform.position + Vector3.up * 1, Quaternion.identity);
            PoolManager.Instance.Push(this);
        }

        if (Vector3.Distance(originPos, transform.position) <= _intersection)
        {
            transform.position += new Vector3((_projectileSpeed * Time.deltaTime) * _projectileDir, 0);
        }
        else
        {
            PoolManager.Instance.Push(this);
        }
    }


    public bool CastDamage()
    {
        int cnt = Physics2D.OverlapCircleNonAlloc(transform.position, _castRadius, _hitResult, _whatIsEnemy);

        for (int i = 0; i < cnt; ++i)
        {
            Vector2 direction = (_hitResult[i].transform.position - transform.position).normalized;
            if (_hitResult[i].TryGetComponent<IDamageable>(out IDamageable health))
            {
                health.ApplyDamage(_damage, direction, Vector3.zero, _player);
            }
        }

        return cnt > 0;
    }

    public override void ResetPooingItem()
    {
        _projectileDir = Mathf.Sign(_player.transform.rotation.y);

        Vector3 scale = transform.localScale;
        transform.localScale = new Vector3(scale.x * _projectileDir * -1, scale.y, scale.z);
    }

    public void Init()
    {
        originPos = transform.position;
    }
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _castRadius);
    }
#endif
}