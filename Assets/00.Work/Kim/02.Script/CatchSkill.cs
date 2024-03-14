using UnityEngine;

public class CatchSkill : MonoBehaviour
{
    [SerializeField] GameObject handPF;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Instantiate(handPF, new Vector2(transform.position.x, transform.position.y), transform.rotation);
        }
    }
}
