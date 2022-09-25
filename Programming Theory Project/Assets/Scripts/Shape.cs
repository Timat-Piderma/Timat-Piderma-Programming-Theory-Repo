using UnityEngine;

public class Shape : MonoBehaviour
{
    public int colorID { get; private set; } // ENCAPSULATION
    private Color color;
    private Vector3 currentVelocity;
    public static float zBoundary { get; private set; } // ENCAPSULATION
    public static float xBoundary { get; private set; } // ENCAPSULATION

    private void Awake() //gives a velocity and a color to the shape
    {
        zBoundary = 5f;
        xBoundary = 8.7f;
        RandomizeVelocity();
        SetColor();
    }

    private void OnMouseOver() //detect if the shape has been clicked
    {
        if (Input.GetMouseButtonDown(0))
        {
            DestroyOnClick();
        }
    }

    public void Update() //checks if the shape is inside the boundaries and moves it
    {
        if (transform.position.x > xBoundary && currentVelocity.x > 0)
        {
            currentVelocity.x *= -1;
        }
        else if (transform.position.x < -xBoundary && currentVelocity.x < 0)
        {
            currentVelocity.x *= -1;
        }

        if (transform.position.z > zBoundary && currentVelocity.z > 0)
        {
            currentVelocity.z *= -1;
        }
        else if (transform.position.z < -zBoundary && currentVelocity.z < 0)
        {
            currentVelocity.z *= -1;
        }

        Move();
    }

    public virtual void DestroyOnClick() // ABSTRACTION
    {
        //gamemanager.punti
        Destroy(gameObject);
    }

    public void Move() // ABSTRACTION
    {
        transform.position = transform.position + currentVelocity * Time.deltaTime;
    }

    public void RandomizeVelocity() // ABSTRACTION
    {
        currentVelocity = Random.insideUnitSphere;
        currentVelocity.y = 0;
        currentVelocity *= 5.0f;
    }

    public void SetColor() // ABSTRACTION
    {
        colorID = Random.Range(1, 4);
        if (colorID == 1) color = Color.red;
        if (colorID == 2) color = Color.yellow;
        if (colorID == 3) color = Color.blue;

        var var = GetComponentInChildren<MeshRenderer>();
        var.material.color = color;
    }

    protected bool CheckColor() // ABSTRACTION
    {
        if (colorID == GameManager.Instance.colorID) return true;
        else return false;

    }
}
