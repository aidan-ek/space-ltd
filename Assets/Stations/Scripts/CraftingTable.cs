using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class CraftingTable : MonoBehaviour
{
    private Dictionary<int, string[]> recipes = new Dictionary<int, string[]>();

    //stores the number of each item you have
    public static string[] materials = new string[5];
    public static GameObject[] itemSlots = new GameObject[5];

    public GameObject itemSlot;

    void Awake()
    {
        recipes[0] = new string[5] {"", "", "PlasmaWisp", "Scrap", "Scrap"};
        recipes[1] = new string[5] {"AstralAlgae", "PlasmaWisp", "PlasmaWisp", "Scrap", "Scrap"};
        recipes[2] = new string[5] {"LivingStar", "Scrap", "Scrap", "Scrap", "Scrap"};
        recipes[3] = new string[5] {"", "", "", "CosmicIngot", "PlasmaWisp"};
        recipes[4] = new string[5] {"", "", "", "CosmicIngot", "RawPlasma"};
        recipes[5] = new string[5] {"", "", "", "RawPlasma", "RawPlasma"};

        //Instantiate each item slot
        for (int i=0; i<5; i++)
        {
            itemSlots[i] = Instantiate(itemSlot, gameObject.transform.position, Quaternion.identity);
            itemSlots[i].transform.parent = gameObject.transform;
        }

        //position Item Slots in pentagon shape
        itemSlots[0].transform.position += new Vector3(0, 1, 0);
        itemSlots[1].transform.position += new Vector3(2, 0.3f, 0);
        itemSlots[2].transform.position += new Vector3(1, -1, 0);
        itemSlots[3].transform.position += new Vector3(-1, -1, 0);
        itemSlots[4].transform.position += new Vector3(-2, 0.3f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // gets the names of all materials in crafting table
        for (int i = 0; i < 5; i++)
        {
            if (itemSlots[i])
            {
                if (itemSlots[i].transform.childCount > 0)
                {
                    materials[i] = itemSlots[i].transform.GetChild(0).name.Replace("(Clone)", "");
                }
                else
                {
                    materials[i] = "";
                }
            }
        }
        Array.Sort(materials);

        int craftedItemID = RecipeBook(materials);
        if (craftedItemID != -1 && Input.GetKeyDown(KeyCode.Return)) {
            GameObject clone = Instantiate(gameObject.transform.GetChild(craftedItemID).gameObject);
            clone.name = gameObject.transform.GetChild(craftedItemID).name;
            clone.transform.position = gameObject.transform.position + new Vector3(0, -0.1f, 0);
            clone.SetActive(true);

            for (int i = 0; i < 5; i++)
            {
                if (itemSlots[i].transform.childCount > 0) {
                    Destroy(itemSlots[i].transform.GetChild(0).gameObject);
                }
            }
        }
    }

    int RecipeBook(string[] mats)
    {
        foreach (KeyValuePair<int, string[]> entry in recipes)
        {
            if (entry.Value.SequenceEqual(mats))
            {
                return entry.Key;
            }
        }
        return -1;
    }
}
