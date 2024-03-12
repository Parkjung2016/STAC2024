using Cinemachine.Utility;
using UnityEditor;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float _projectileSpeed;
    [SerializeField]
    private float _intersection;

    private Transform _playerTrm;
    private Camera _mainCam;
    private float _projectileDir;
    private Vector3 originPos;

    private void Awake()
    {
        _playerTrm = GameObject.FindWithTag("Test").transform;
        _mainCam = Camera.main;
        originPos = transform.position;
    }

    private void Start()
    {
        Vector3 mousePos = _mainCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 
            -_mainCam.transform.position.z));

        Vector3 dir = (_playerTrm.position - mousePos).normalized;
        Vector3 Cross = Vector3.Cross(_playerTrm.forward, dir);

        if (Vector3.Dot(_playerTrm.up,
            Cross) > 0)
        {
            _projectileDir = -1;
        }
        else
        {
            _projectileDir = 1;
        }

        //print($"{mousePos.normalized}, {_playerTrm.up} \n {Vector3.Dot(new Vector3(_playerTrm.up.x, 0), new Vector3(mousePos.x, 0).normalized)}");
    }

    private void Update()
    {
        if (Vector3.Distance(originPos, transform.position) <= _intersection)
        {
            transform.position += new Vector3((_projectileSpeed * Time.deltaTime) * _projectileDir, 0);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Edited later TryGetComponent.
        if (collision.CompareTag("Enemy"))
        {
            // hit event
            print($"hit{collision.gameObject}");
        }
    }
}