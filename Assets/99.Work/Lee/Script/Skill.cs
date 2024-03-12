using UnityEngine;

namespace LJS
{
    // This script manages player skills
    public class Skill : MonoBehaviour
    {
        [SerializeField]
        private GameObject _projectile;
        [SerializeField]
        private Transform _attackPoint;

        private void Projectile()
        {
            Instantiate(_projectile, _attackPoint.position, Quaternion.identity);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Projectile();
            }
        }
    }
}

