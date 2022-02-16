using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] Transform Circle;
    [SerializeField] float SpawnMinX, SpawnMaxX, SpawnMinY, SpawnMaxY;

    private void Awake()
    {
        for (int i = 0; i < 5; i++)
        {
            Transform circle = Instantiate(Circle, new Vector3(Random.Range(SpawnMinX, SpawnMaxX), Random.Range(SpawnMinY, SpawnMaxY), 0f), Quaternion.identity);
            circle.tag = "circle";
        }
    }
}