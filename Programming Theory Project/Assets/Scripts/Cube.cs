using UnityEngine;

public class Cube : Shape // INHERITANCE
{
    [SerializeField]
    private Shape shapePrefab;
    [SerializeField]
    private int prefabNumber;


    public override void DestroyOnClick() // POLYMORPHISM
    {
        if (CheckColor())
        {
            InstantiatePrefab(); //cube instatiates prefab only if it is of the right color
        }

        base.DestroyOnClick();
    }

    private void InstantiatePrefab() // ABSTRACTION
    {
        for(int i = 0; i<prefabNumber; i++)
        {
            GameObject.Instantiate(shapePrefab, transform.position, Quaternion.identity);
        }
    }

    
}
