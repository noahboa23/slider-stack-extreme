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
    Pickles,
    TopBun,
    Moldy
}

public class OrderManager : MonoBehaviour
{
    [SerializeField] Sprite[] ingredientSprites = new Sprite[6];
    [SerializeField] float orderRefreshTimer = 30f;
    [SerializeField] UIManager uim;

    public float timer;
    public static IngredientType[] currentOrder;
    public static List<IngredientType> currentStack = new List<IngredientType>();
    public static List<IngredientType> orderItemsNeeded;
    public int score;

    public ExplosionReset explosion;

    public void Start()
    {
        score = 0;
        currentOrder = GenerateOrder();
        DisplayIngredients(currentOrder);
        orderItemsNeeded = new List<IngredientType>(currentOrder);
    }

    public void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            currentStack.Clear();
            explosion.reset = true;
            currentOrder = GenerateOrder();
            DisplayIngredients(currentOrder);
            orderItemsNeeded = new List<IngredientType>(currentOrder);
        }
        uim.UpdateScoreText(score);
        uim.UpdateTimerText((int)timer);
    }

    public IngredientType[] GenerateOrder()
    { // generate the order to display
        // pick a number between 1 and 5
        int numIngredients = Random.Range(1, 6);
        // create array of randomly chosen ingredients
        IngredientType[] ingredients = new IngredientType[numIngredients];
        for (int i = 0; i < numIngredients; i++)
        {
            ingredients[i] = (IngredientType)Random.Range(0, 6);
        }
        timer = orderRefreshTimer;
        return ingredients;
    }

    public void DisplayIngredients(IngredientType[] ingredients)
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
        for (int i = spriteIndex; i < sprites.Length; i++)
        { // set unused sprites invisible 
            sprites[i].gameObject.SetActive(false);
        }
    }

    public void UpdateCurrentStack(IngredientType i)
    {
        currentStack.Add(i);
        UpdateScore(i);
    }

    public void UpdateScore(IngredientType i)
    {
        // if moldy, score penalty
        if (i == IngredientType.Moldy)
        {
            score -= 100;
            return;
        }
        if (i == IngredientType.TopBun)
        {// top bun forces reset
            if (orderItemsNeeded.Count == 0)
            { // if got all ingridients, get bonus
                score += 100;
            }
            explosion.reset = true;
            currentStack.Clear();
            currentOrder = GenerateOrder();
            DisplayIngredients(currentOrder);
            orderItemsNeeded = new List<IngredientType>(currentOrder);
            return;
        }

        bool notNeeded = true;
        for (int j = 0; j < orderItemsNeeded.Count; j++)
        { // check if item is in order
            if (orderItemsNeeded[j] == i)
            {
                score += 10;
                orderItemsNeeded.RemoveAt(j);
                notNeeded = false;
                break;
            }
        }
        if (notNeeded)
        { // wrong item penalty
            score -= 10;
        }
        
        //Debug.Log("Score: " + score);
    }
}

