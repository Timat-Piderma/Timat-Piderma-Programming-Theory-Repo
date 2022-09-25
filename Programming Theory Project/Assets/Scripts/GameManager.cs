using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Shape cubePrefab;
    [SerializeField]
    private Shape spherePrefab;

    [SerializeField]
    private int cubeNumber;
    [SerializeField]
    private int sphereNumber;

    public static GameManager Instance { get; private set; } // ENCAPSULATION

    private int score = 0;

    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text colorText;

    public int colorID { get; private set; } // ENCAPSULATION

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        ChooseColor();
        InstantiatePrefabs();
    }

    private void ChooseColor() // ABSTRACTION
    {
        colorID = Random.Range(1, 4);
        if (colorID == 1)
        {
            colorText.text = "RED";
            colorText.color = Color.red;
        }
        if (colorID == 2)
        {
            colorText.text = "YELLOW";
            colorText.color = Color.yellow;
        }
        if (colorID == 3)
        {
            colorText.text = "BLUE";
            colorText.color = Color.blue;
        }
    }

    public void AddPoints(int value) // ABSTRACTION
    {
        score += value;
        scoreText.text = score.ToString();
    }

    public void SubtractPoints(int value) // ABSTRACTION
    {
        
        if (score - value < 0) score = 0;
        else score -= value;

        scoreText.text = score.ToString();
    }

    private void InstantiatePrefabs() // ABSTRACTION
    {

        for (int i = 0; i < cubeNumber; i++)
        {
            Instantiate(cubePrefab, new Vector3(Random.Range(-Shape.xBoundary, Shape.xBoundary), 0, Random.Range(-Shape.zBoundary, Shape.zBoundary)), Quaternion.identity);
        }

        for (int i = 0; i < sphereNumber; i++)
        {
            Instantiate(spherePrefab, new Vector3(Random.Range(-Shape.xBoundary, Shape.xBoundary), 0, Random.Range(-Shape.zBoundary, Shape.zBoundary)), Quaternion.identity);
            }
    }
} 
