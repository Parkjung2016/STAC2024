using UnityEngine;

public class ParallaxRolling : MonoBehaviour
{
    [SerializeField]
    private Transform cameraTransform;      

    private Vector3 cameraStartPosition;    
    private float distance;             

    private Material[] materials;               
    private float[] layerMoveSpeed;         

    private GameObject player;

    [SerializeField]
    [Range(0.01f, 1.0f)]
    private float parallaxSpeed;            

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").gameObject;
        cameraStartPosition = cameraTransform.position;

        int backgroundCount = transform.childCount;
        GameObject[] backgrounds = new GameObject[backgroundCount];

        materials = new Material[backgroundCount];
        layerMoveSpeed = new float[backgroundCount];

        for (int i = 0; i < backgroundCount; ++i)
        {
            backgrounds[i] = transform.GetChild(i).gameObject;
            materials[i] = backgrounds[i].GetComponent<Renderer>().material;
        }

        CalculateMoveSpeedByLayer(backgrounds, backgroundCount);
    }

    private void CalculateMoveSpeedByLayer(GameObject[] backgrounds, int count)
    {
        float farthestBackDistance = 0;
        for (int i = 0; i < count; ++i)
        {
            if ((backgrounds[i].transform.position.z - cameraTransform.position.z) > farthestBackDistance)
            {
                farthestBackDistance = backgrounds[i].transform.position.z - cameraTransform.position.z;
            }
        }

        for (int i = 0; i < count; ++i)
        {
            layerMoveSpeed[i] = 1 - (backgrounds[i].transform.position.z - cameraTransform.position.z) / farthestBackDistance;
        }
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, player.transform.position.y + 2);
    }

    private void LateUpdate()
    {
        distance = cameraTransform.position.x - cameraStartPosition.x;

        transform.position = new Vector3(cameraTransform.position.x, transform.position.y, 0);

        for (int i = 0; i < materials.Length; ++i)
        {
            float speed = layerMoveSpeed[i] * parallaxSpeed;
            materials[i].SetTextureOffset("_MainTex", new Vector2(distance, 0) * speed);
        }
    }
}
