using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum IngredientType
{
    Lettuce,
    Patty,
    Cheese,
    Onion,
    Tomato,
    Pickles
}

public class OrderManager : MonoBehaviour
{
    [SerializeField] Sprite[] ingredientSprites = new Sprite[6];
    [SerializeField] float orderRefreshTimer = 30f;
    float timer;

    public void Start()
    { 
        IngredientType[] ingredients = generateOrder();
        displayIngredients(ingredients);
    }

    public void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            IngredientType[] ingredients = generateOrder();
            displayIngredients(ingredients);
        }
    }

    public IngredientType[] generateOrder()
    { // generate the order to display
        // pick a number between 1 and 5
        int numIngredients = Random.Range(1, 6);
        // create array of randomly chosen ingredients
        IngredientType[] ingredients = new IngredientType[numIngredients]; 
        for(int i = 0; i < numIngredients; i++)
        {
            ingredients[i] = (IngredientType)Random.Range(0, 6);
        }
        timer = orderRefreshTimer;
        return ingredients;
    }

    public void displayIngredients(IngredientType[] ingredients)
    {
        // get the child sprites in order area --> only 5
        Image[] sprites = GetComponentsInChildren<Image>(true);
        int spriteIndex = 1; // exclude order area
        foreach (IngredientType i in ingredients)
        { // for each ingredient in the order, display the appropriate sprite
            switch (i)
            {
                case IngredientType.Lettuce:
                    sprites[spriteIndex].sprite = ingredientSprites[0];
                    break;
                case IngredientType.Patty:
                    sprites[spriteIndex].sprite = ingredientSprites[1];
                    break;
                case IngredientType.Cheese:
                    sprites[spriteIndex].sprite = ingredientSprites[2];
                    break;
                case IngredientType.Onion:
                    sprites[spriteIndex].sprite = ingredientSprites[3];
                    break;
                case IngredientType.Tomato:
                    sprites[spriteIndex].sprite = ingredientSprites[4];
                    break;
                case IngredientType.Pickles:
                    sprites[spriteIndex].sprite = ingredientSprites[5];
                    break;
            }
            sprites[spriteIndex].gameObject.SetActive(true); // set visible
            spriteIndex++;
        }
        for(int i = spriteIndex; i < 6; i++)
        { // set unused sprites invisible
            sprites[spriteIndex].gameObject.SetActive(false);
        }
    }
}
