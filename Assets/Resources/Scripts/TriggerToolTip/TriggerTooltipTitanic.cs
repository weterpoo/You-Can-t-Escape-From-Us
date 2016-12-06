using UnityEngine;
using System.Collections;

public class TriggerTooltipTitanic : TriggerTooltip 
{
    public int counter = 0;
    bool done = false;
    bool lock_state = true;
    GameObject nums;
    int[] digits = { 0, 0, 0, 0 };
    int position = 0;

    // Use this for initialization
    new protected void Start()
    {
        base.Start();

        string[] newTags =
        {
        "barrels",
        "drawer",
        "bed",
        "painting",
        "window",
        "interactable",
        "door",
        "radio",
        "chair",
        "record"
        };

        setTags(newTags);

        nums = GameObject.Find("numbers");
    }

    protected override void hitOptional(RaycastHit hit)
    {
        string hit_mark = hit.collider.tag;
        Debug.Log(GameObject.FindWithTag(hit_mark));

        switch (hit_mark)
        {
            case "drawer":
                activate_tooltip(hit_mark, "The RMS Titanic was the world’s largest passenger ship when it entered service, measuring 269 metres (882 feet) in length, and the largest man-made moving object on Earth. The largest passenger vessel is now the MS Allure of the Seas, at 362 metres.");
                break;
            case "barrels":
                activate_tooltip(hit_mark, "The ship burned around 600 tonnes of coal a day – hand shovelled into its furnaces by a team of 176 men. Almost 100 tonnes of ash were ejected into the sea each day.");
                break;
            case "candles":
                activate_tooltip(hit_mark, "The ship's interiors were loosely inspired by those at the Ritz hotel in London. Facilities on board included a gym, pool, Turkish bath, a kennel for first class dogs, and a squash court. It even had its own on board newspaper – the Atlantic Daily Bulletin.");
                break;
            case "chair":
                activate_tooltip(hit_mark, "Only 16 wooden lifeboats and four collapsible boats were carried, enough to accommodate 1,178 people, only one-third of Titanic's total capacity, but more than legally required.");
                break;
            case "record":
                activate_tooltip(hit_mark, "There were 246 injuries and two deaths recorded during the ship’s 26-month construction in Belfast.");
                break;
            case "painting":
                activate_tooltip(hit_mark, "The Titanic used 825 tons of coal per day and 10,000 lamp bulbs throughout its journey. Over 14000 gallons of drinking water was used every 24 hours, 1000 bottles of wine were taken on board, and 40000 fresh eggs were kept in the ship's provisions. It was built to harbor over 3500 passengers and 2200 crew members.");
                break;
            case "door":
                unlock_attempt();
                break;

        }
    }

    // Update is called once per frame
    new protected void Update()
    {
        if (lock_state)
        {
            base.Update();
        }
        else
        {
            TextMesh numbs = nums.GetComponent<TextMesh>();
            if (!done)
            {
                if (Input.GetButtonDown("Cancel"))
                {
                    done = true;
                    lock_state = true;
                }
                if (Input.GetButtonDown("Fire3"))
                {
                    position = (position + 1) % 4;
                }
                if (Input.GetButtonDown("Fire2"))
                {
                    position = (position - 1) % 4;
                    if (position < 0)
                    {
                        position += 4;
                    }
                }
                if (Input.GetButtonDown("Fire1"))
                {
                    digits[position] = (digits[position] + 1) % 10;
                }
                numbs.text = digits[0] + "" + digits[1] + digits[2] + digits[3];
            }
        }

    }

    protected void activate_tooltip(string target_name, string tag)
    {
        GameObject obj = GameObject.FindWithTag("tooltip");
        GameObject tooltip_copy = Instantiate(obj);
        uitext newtxt = tooltip_copy.GetComponent<uitext>();
        newtxt.text = tag;
        //tooltip_copy.SendMessage("setText", tag);
        GameObject target = GameObject.FindWithTag(target_name);
        Debug.Log(target_name);
        tooltip_copy.transform.rotation = transform.rotation;
        //tooltip_copy.transform.Rotate(0, 180, 0);
        tooltip_copy.transform.position = transform.position + transform.forward * (float)1.5;
        counter++;
    }


    void unlock_attempt()
    {
        lock_state = false;
        done = false;
    }

}