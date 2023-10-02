using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class CraftingTable : MonoBehaviour
{
    private Dictionary<string, string[]> recipes = new Dictionary<string, string[]>();

    //stores the number of each item you have
    public static string[] materials = new string[5];
    public static GameObject[] itemSlots = new GameObject[5];

    public GameObject itemSlot;

    void Awake()
    {
        recipes["OxygenSynthesizer"] = new string[5] {"", "", "PlasmaWisp", "Scrap", "Scrap"};
        recipes["SeedIncubator"] = new string[5] {"AstralAlgae", "PlasmaWisp", "PlasmaWisp", "Scrap", "Scrap"};
        recipes["MetalRefiner"] = new string[5] {"Scrap", "Scrap", "Scrap", "Scrap", "LivingStar"};
        recipes["Luminary"] = new string[5] {"", "", "", "CosmicIngot", "PlasmaWisp"};
        recipes["Thruster"] = new string[5] {"", "", "", "CosmicIngot", "RawPlasma"};
        recipes["Starfuel"] = new string[5] {"", "", "", "RawPlasma", "RawPlasma"};

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
    }

    string RecipeBook(string[] mats)
    {
        foreach (KeyValuePair<string, string[]> entry in recipes)
        {
            if (entry.Value.SequenceEqual(mats))
            {
                return entry.Key;
            }
        }
        return null;
    }
}
