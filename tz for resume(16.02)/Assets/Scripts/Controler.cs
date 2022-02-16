using UnityEngine;
using TMPro;

public class Controler : MonoBehaviour
{


    [SerializeField] TMP_Text Text;
    [SerializeField] GameObject RestartPanel;
    private byte points;
    private GameObject closestFood;
    private GameObject[] foods = new GameObject[4];

    private void Start()
    {
        points = 0;
        RestartPanel.SetActive(false);
    }

    private void Update()
    {
        foods = GameObject.FindGameObjectsWithTag("circle"); // fill array
        closestFood = FindClosestFood();

        Text.text = "points: " + points;

        if(points == 5)
        {
            RestartPanel.SetActive(true);
        }
    }

    GameObject FindClosestFood()
    {
        float distance = Mathf.Infinity;  // maximum distance
        Vector3 position = transform.position; // position of player

        foreach/*for everything in array*/ (GameObject/*class*/ closest/*local var (result)*/ in foods/*array*/)
        {
            Vector3 delta = closest.transform.position - this.transform.position; // lenght difference 
            float curFoodDistance = delta.sqrMagnitude; // distance to new food

            if (curFoodDistance < distance) // if closer
            {
                closestFood = closest; // replace result food
                distance = curFoodDistance;// replace distance to closest food
            }
        }
        return closestFood;
    }

    private void OnMouseOver()
    {
        transform.Translate((closestFood.transform.position - transform.position)*Time.deltaTime); // move to circle
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        points++;
    }
}
