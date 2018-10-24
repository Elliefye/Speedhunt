using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class minigameData : MonoBehaviour {

    public bool minigameOpen = false, isGuilty, gameOver = false, button = false;
    public GameObject minigame;
    public Text firstName, occupation, crime, title, correct, timer, scoreDisplay, traitText;
    public Text[] traits = new Text[3];
    public RawImage female, male;
    public Button guilty, notGuilty, quit;
    public int score = 0, level;
    private int threshold, time;
    string[] firstNamesFemale = new string[] { "Sarah", "Joanne", "Joyce", "Anna", "Kaylee", 
    "Mickayla", "Nicole", "Tracy", "Emma", "Jacklyn", "Evelynn", "Olivia", "Sophia", "Isabella",
    "Mia", "Charlotte", "Abigail", "Amelia", "Harper", "Ella", "Aria", "Avery", "Scarlett",
    "Mila", "Lily", "Chloe", "Layla", "Riley", "Elizabeth", "Addison", "Natalie", "Savannah" };
    string[] firstNamesMale = new string[] { "John", "Justin", "Alex", "Michael", "Robert", 
    "Christian", "Luke", "Paul", "Noah", "Liam", "Benjamin", "Elijah", "Alexander", "Ethan",
    "Logan", "Sebastian", "Carter", "Jayden", "Wyatt", "Grayson", "Gabriel", "Owen", "Levi", 
    "Lincoln", "Leo", "Jaxon", "Muhammad", "Isaiah", "Samuel", "Henry", "Jacob", "Jason", "Watt" };
    string[] lastNames = new string[] { "Faulkner", "Johnson", "Wolfe", "Black", "Robertson", 
    "Smith", "Yullker", "Fornell", "Nahf", "Wheelwright", "Cantor", "Boggs", "Wolk", "Le blanc",
    "De lorenzo", "Micallef", "Braudel", "Lovison", "Motimaya", "Bonhoeffer", "Thurber", "Sase",
    "Seoh", "Mcneill", "Foley", "Flemming", "Ghildyal", "Bashevis", "Lyons", "Lowenstein", "Hansen",
    "Ettner", "Bodrock", "Judd", "Tam", "Revlin", "Grusby", "Inniss", "Conklin", "Esslemont", "Malova",
    "Barrant", "Dottin", "Campos", "Magruder", "Serfling", "Touborg", "Casacchia", "Merrill", "Saph",
    "Larsen", "Hyatt", "Burner", "Ebbitt", "Randolph", "Munoz-porras", "Jaccarino", "Chun", "Hulbert" };
    string[] occupationsGood = new string[] { "baker", "doctor", "makeup artist", "blogger", 
    "youtuber", "mechanic", "programmer", "designer", "lawyer", "psychologist", "farmer", 
    "managing director", "fork-lift driver", "shop assistant", "illustrator", "historian", "decorator",
    "cleaner", "policeman", "security guard", "magician", "builder", "ustoms officer", "nurse",
    "taxi driver", "lorry driver", "fitness instructor", "school crossing warden", "craftsperson" };
    string[] occupationsEvil = new string[] { "pimp", "hacker", "slaver", 
    "assassin", "prostitute", "satanist", "drug dealer" };
    string[] crimes = new string[] { "shoplifting", "mass murder", "vandalism", "selling drugs", 
    "insulting the government", "brawling", "terrorism", "promoting a sexual performance by a child",
    "bail jumping", "rape", "false advertising", "tax evasion", "bribe receiving", "car theft",
    "prostitution", "assault", "blackmail", "kidnapping", "burglary", "desecration", "diabolism", "extortion",
    "smuggling", "necromancy", "witchcraft", "poisoning the president", "robbery", "theft", "treason",
    "feeding dogs chocolate", "being a criminal mastermind" };
    string[] traitsGood = new string[] { "gentle", "loves animals", "loves children", "honest", 
    "loyal", "respectful", "compassionate", "generous", "wise", "lively", "rational", "responsible",
    "outgoing" };
    string[] traitsEvil = new string[] { "evil", "addicted to cocaine", "loves shooting people for fun", 
    "abusive", "unstable", "insane", "likes torture", "possibly a vampire", "foolish", "likes staring at people",
    "untrustworthy", "traitorous", "sneaky", "no self discipline" };

    private void Start()
    {
        if(!button)
        {
            //Text[] traitsTemp = new Text[Game.current.minigameLevel + 2];
            level = 1;//Game.current.minigameLevel;        
            threshold = level * 2 + 3;
        }       
    }

    void Update()
    {
        if(!button)
        {
            if (minigameOpen == true)
            {
                time = 30;
                activateMinigame();
                assignTraits();
                pulseTitle();
                StartCoroutine(waitForResponse());
                minigameOpen = false;
            }

            if (gameOver)
            {
                StopAllCoroutines();
                setToolsActive(false);
                female.gameObject.SetActive(false);
                male.gameObject.SetActive(false);
                scoreDisplay.text = "";
                title.text = "NO MORE CRIMINALS";
                var main = minigame.GetComponent<minigameData>();
                occupation.gameObject.SetActive(true);
                occupation.text = "You earned $" + main.score*10 + "!";
                crime.gameObject.SetActive(true);
                crime.text = "Come back tomorrow for more judging.";
                Game.current.cash += main.score*10;
            }
            else
            {
                var main = minigame.GetComponent<minigameData>();
                scoreDisplay.text = "Score: " + main.score.ToString();
            }
        }
    }

    void assignTraits()
    {
        int evilFactor = 0, temp;
        firstName.text = "Name: ";
        occupation.text = "Occupation: ";
        crime.text = "Crime: ";

        temp = Random.Range(0, 2);
        if (temp == 0)
        {
            title.text = "IS SHE GUILTY?";
            firstName.text = firstNamesFemale[Random.Range(0, firstNamesFemale.Length)];
            male.gameObject.SetActive(false);
            female.gameObject.SetActive(true);
        }
        else
        {
            title.text = "IS HE GUILTY?";
            firstName.text = firstNamesMale[Random.Range(0, firstNamesMale.Length)];
            male.gameObject.SetActive(true);
            female.gameObject.SetActive(false);
        }
            firstName.text += " " + lastNames[Random.Range(0, lastNames.Length)];
        temp = Random.Range(0, 2);
        if (temp == 0)
            occupation.text += occupationsGood[Random.Range(0, occupationsGood.Length)];
        else
        {
            occupation.text += occupationsEvil[Random.Range(0, occupationsEvil.Length)];
            evilFactor++;
        }
        crime.text += crimes[Random.Range(0, crimes.Length)];

        int[] previousTraits = new int[traits.Length];
        int i = 0;

        foreach(Text trait in traits)
        {
            temp = Random.Range(0, 2);

            if (temp == 0)
            {
                int newTrait = Random.Range(0, traitsGood.Length);

                while(!traitCheck(previousTraits, newTrait))
                    newTrait = Random.Range(0, traitsGood.Length);

                previousTraits[i] = newTrait;
                trait.text = traitsGood[newTrait];
            }                
            else
            {
                int newTrait = Random.Range(0, traitsEvil.Length);

                while (!traitCheck(previousTraits, newTrait))
                    newTrait = Random.Range(0, traitsEvil.Length);

                previousTraits[i] = newTrait;
                trait.text = traitsEvil[newTrait];
                evilFactor++;
            }
            i++;
        }

        if (evilFactor >= traits.Length)
            isGuilty = true;
        else isGuilty = false;

        //setToolsActive(true);
    }

    private bool traitCheck(int[] previous, int newId)
    {
        foreach(int i in previous)
        {
            if (i == newId)
                return false;
        }
        return true;
    }

    IEnumerator waitForResponse()
    {
        while(time >= 0)
        {
            timer.text = /*"Time left: " + */time.ToString() + " s";
            yield return new WaitForSeconds(1);
            time--;
        }
            
        gameOver = true;
    }

    IEnumerator flashScoreText()
    {
        for (int i = 0; i <= 255; i += 4)
        {
            correct.color = new Color(correct.color.r, correct.color.g, correct.color.b, (byte)i);
            yield return null;
        }
        
        for (int i = 255; i <= 0; i -= 4)
        {
            correct.color = new Color(correct.color.r, correct.color.g, correct.color.b, (byte)i);
            yield return null;
        }
        correct.color = new Color(correct.color.r, correct.color.g, correct.color.b, 0);
    }

    IEnumerator flashScoreCorrect(Color newColor)
    {
        Color defaultColor = title.color;
        for(int i = 0; i < 4; i++)
        {
            scoreDisplay.color = newColor;
            yield return new WaitForSeconds(0.1f);
            scoreDisplay.color = defaultColor;
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator pulseTitle()
    {
        while(!gameOver)
        {
            for(int i = 0; i <= 255; i++)
            {
                title.color = new Color32((byte)i, (byte)i, (byte)i, 255);
                yield return null;
            }
            for(int i = 255; i <= 0; i--)
            {
                title.color = new Color32((byte)i, (byte)i, (byte)i, 255);
                yield return null;
            }
        }
    }

    public void guiltyPressed()
    {  
        var main = minigame.GetComponent<minigameData>();     
        if (main.isGuilty)
        {
            main.score++;
            correct.text = "CORRECT";
            correct.color = Color.green;
            StartCoroutine(flashScoreCorrect(Color.green));
        }
        else
        {
            if(main.score > 0)
                main.score--;
            correct.text = "INCORRECT";
            correct.color = Color.red;
            StartCoroutine(flashScoreCorrect(Color.red));
        }

        StartCoroutine(flashScoreText());

        main.assignTraits();
    }

    public void innocentPressed()
    {
        var main = minigame.GetComponent<minigameData>();
        if (!main.isGuilty)
        {
            main.score++;
            correct.text = "CORRECT";
            correct.color = Color.green;
            StartCoroutine(flashScoreCorrect(Color.green));
        }
        else
        {
            if(main.score > 0)
                main.score--;
            correct.text = "INCORRECT";
            correct.color = Color.red;
            StartCoroutine(flashScoreCorrect(Color.red));
        }

        StartCoroutine(flashScoreText());

        main.assignTraits();
    }

    public void setToolsActive(bool active)
    {
        firstName.gameObject.SetActive(active);
        occupation.gameObject.SetActive(active);
        crime.gameObject.SetActive(active);
        traitText.gameObject.SetActive(active);
        foreach (Text trait in traits)
            trait.gameObject.SetActive(active);
        guilty.gameObject.SetActive(active);
        notGuilty.gameObject.SetActive(active);
        quit.gameObject.SetActive(!active);
    }

    public void activateMinigame()
    {
        minigame.SetActive(true);
    }

    public void deactivateMinigame()
    {
        minigame.SetActive(false);
    }
}
