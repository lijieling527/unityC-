using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSences : MonoBehaviour
{
    public string sceneToLoad;
    public Text collectedIngredientsText;
    public Text UncollectedIngredientsText;
    public GameObject GameObject;

    public Sprite questionMarkSprite;
    public Image[] ingredientSlots;
    public Sprite[] ingredientSprites;
    public List<string> objetfoods = new List<string> { "¦Ëµ«1", "¦Ëµ«2", "­»Û£1", "­»Û£2", "½Þ¦×1", "½Þ¦×2" };
    public Image Error;
    void Start()
    {
        // PlayerPrefs.SetString("ReturnScene", SceneManager.GetActiveScene().name);

        for (int i = 0; i < ingredientSlots.Length; i++)
        {
            ingredientSlots[i].sprite = questionMarkSprite;
        }
        // UpdateCollectedIngredients();
        Error.gameObject.SetActive(false);

    }

    void UpdateCollectedIngredients()
    {
        List<string> ingredients = collectfood.Instance.GetCollectedIngredients();
        // collectedIngredientsText.text = "¦¬¶°¨ìªº­¹§÷:\n" + string.Join("\n", ingredients);
        List<string> Uningredients = collectfood.Instance.GetUnCollectedIngredients();
        // UncollectedIngredientsText.text = "¨S¦³¦¬¶°¨ìªº­¹§÷:\n" + string.Join("\n", Uningredients);
        int size = ingredients.Count;
        // foreach (string ingredient in ingredients)
        List<string> newingredients;
        // foreach (string ingredient in ingredients)
        newingredients = DisplayCollectedIngredient(ingredients);
        collectfood.Instance.OnIngredientsChanged(newingredients);

        //Debug.Log("1"+collectfood.Instance.GetCollectedIngredients()[0]);
        //Debug.Log("2"+collectfood.Instance.GetUnCollectedIngredients()[0]);

        foreach (Transform child in GameObject.transform)
        {
            // Debug.Log(123456789);
            Button ingredientButton = child.GetComponent<Button>();
            if (ingredientButton != null)
            {
                string ingredientName = child.name.Replace("1", "");
                string ingredientName2 = child.name.Replace("2", "");

                // Debug.Log(ingredientName);
                // Debug.Log(child.name);
                if (collectfood.Instance.HasCollected(ingredientName) || collectfood.Instance.HasCollected(ingredientName2))
                {
                    ingredientButton.gameObject.SetActive(false);

                }

                if (collectfood.Instance.NotHasCollected(ingredientName) || collectfood.Instance.NotHasCollected(ingredientName2))
                {
                    ingredientButton.gameObject.SetActive(false);

                }

            }
        }

    }
    public List<string> DisplayCollectedIngredient(List<string> ingredients)
    {
        //for (int i = 0; i < ingredientSlots.Length; i++)
        //{
        //    if (ingredientSlots[i].sprite == questionMarkSprite)
        //    {
        //        ingredientSlots[i].sprite = GetIngredientSprite(ingredient);
        //        break;
        //    }
        //}
        List<string> ingredientsToRemove = collectfood.Instance.GetUnCollectedIngredients();

        foreach (string ingredient in ingredients)
        {
            if (!objetfoods.Contains(ingredient))
            {
                Debug.Log("NO");
                ingredientsToRemove.Add(ingredient);
                StartCoroutine(ShowAndHideErrorImage());
            }
        }

        // Remove the collected ingredients
        foreach (string ingredient in ingredientsToRemove)
        {
            ingredients.Remove(ingredient);
        }
        collectfood.Instance.OnUNIngredientsChanged(ingredientsToRemove);
        int i = 0;
        foreach (string ingredient in ingredients)
        {
            if (objetfoods.Contains(ingredient))
            {
                ingredientSlots[i].sprite = GetIngredientSprite(ingredient);
            }
            i++;
        }
        return ingredients;
    }
    private IEnumerator ShowAndHideErrorImage()
    {
        // Show the image
        Error.gameObject.SetActive(true);

        // Wait for 5 seconds
        yield return new WaitForSeconds(5f);

        // Hide the image
        Error.gameObject.SetActive(false);
    }
    private Sprite GetIngredientSprite(string ingredient)
    {
        switch (ingredient)
        {
            case "¦Ëµ«1":
                return ingredientSprites[0];
            case "¦Ëµ«2":
                return ingredientSprites[1];
            case "½µ1":
                return ingredientSprites[2];
            case "½µ2":
                return ingredientSprites[3];
            case "½Þ¦×1":
                return ingredientSprites[4];
            case "½Þ¦×2":
                return ingredientSprites[5];
            case "­»Û£1":
                return ingredientSprites[6];
            case "­»Û£2":
                return ingredientSprites[7];
            case "¶À¥Ê1":
                return ingredientSprites[8];
            case "¶À¥Ê2":
                return ingredientSprites[9];
            default:
                return questionMarkSprite;
        }
    }
    // Update is called once per frame
    void Update()
    {
        UpdateCollectedIngredients();
    }

    public void Choose¦Ëµ«1()
    {
        SceneManager.LoadScene("bamboo_shoots1(meatballs)");
    }
    public void Choose¦Ëµ«2()
    {
        SceneManager.LoadScene("bamboo_shoots2(meatballs)");
    }
    public void Choose­»Û£1 ()
    {
        SceneManager.LoadScene("mushroom1(meatballs)");
    }
    public void Choose­»Û£2()
    {
        SceneManager.LoadScene("mushroom2(meatballs)");
    }
    public void Choose½Þ¦×1()
    {
        SceneManager.LoadScene("pork1(meatballs)");
    }
    public void Choose½Þ¦×2()
    {
        SceneManager.LoadScene("pork2(meatballs)");
    }
    public void Choose¶À¥Ê1()
    {
        SceneManager.LoadScene("cucumber1(meatballs)");
    }
    public void Choose¶À¥Ê2()
    {
        SceneManager.LoadScene("cucumber2(meatballs)");
    }
    public void Choose½µ1()
    {
        SceneManager.LoadScene("green_onin1(meatballs)");
    }
    public void Choose½µ2()
    {
        SceneManager.LoadScene("green_onin2(meatballs)");
    }
    


    public void CloseChoose()
    {
        //string returnScene = PlayerPrefs.GetString("ReturnScene", "MainScene");
        //SceneManager.LoadScene(returnScene);
        SceneManager.LoadScene("taiwan(meatballs)");
    }
    public void CloseChoose_topineapple_cake()
    {
        //string returnScene = PlayerPrefs.GetString("ReturnScene", "MainScene");
        //SceneManager.LoadScene(returnScene);
        SceneManager.LoadScene("taiwan(pineapple_cake)");
    }

}
