using UnityEngine;

public class Sphere : Shape // INHERITANCE
{
    [SerializeField]
    private int points = 5;

    public override void DestroyOnClick() // POLYMORPHISM
    {
        if (CheckColor())
        {
            GameManager.Instance.AddPoints(points); //sphere give points if it is of the right color
        }
        else 
        {
            GameManager.Instance.SubtractPoints(points);         //subtract points otherwise
        }

        base.DestroyOnClick();
    }
}
