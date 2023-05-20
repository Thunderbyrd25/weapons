using System;
using System.IO;   
using System.Drawing;    
public class Weapons
{

    string[] weaponNames = File.ReadLines("D:\\VSC projects\\Weapons\\Weapon Info\\Weapons.txt").ToArray();
    string[] manufacturers = File.ReadLines("D:\\VSC projects\\Weapons\\Weapon Info\\Manufacturers.txt").ToArray();
    string[] elements = File.ReadLines("D:\\VSC projects\\Weapons\\Weapon Info\\Elements.txt").ToArray();
    string[] specialEffects = File.ReadLines("D:\\VSC projects\\Weapons\\Weapon Info\\Special Effects.txt").ToArray();
    string[] rarities = File.ReadLines("D:\\VSC projects\\Weapons\\Weapon Info\\Rarities.txt").ToArray();
    string[] bladeType = File.ReadLines("D:\\VSC projects\\Weapons\\Weapon Info\\Sword Parts\\Blade Types.txt").ToArray();
    string[] guardType = File.ReadLines("D:\\VSC projects\\Weapons\\Weapon Info\\Sword Parts\\Guard Types.txt").ToArray();
    string[] handleType = File.ReadLines("D:\\VSC projects\\Weapons\\Weapon Info\\Sword Parts\\Handle Types.txt").ToArray();
    string[] accessoryType = File.ReadLines("D:\\VSC projects\\Weapons\\Weapon Info\\Sword Parts\\Accessory Types.txt").ToArray();
    string[] legendaries = File.ReadLines("D:\\VSC projects\\Weapons\\Weapon Info\\Legendaries.txt").ToArray();
    string[] mythics = File.ReadLines("D:\\VSC projects\\Weapons\\Weapon Info\\Mythics.txt").ToArray();
    string[] apocryphals = File.ReadLines("D:\\VSC projects\\Weapons\\Weapon Info\\Apocryphals.txt").ToArray();
    string[] bladeImages;
    string[] guardImages;
    string[] handleImages;
    
    int levelCap = 80;
    int level;
    String name = "";
    String flavorText = "";
    String uniqueDescription = "";
    String manufacturer = "";
    String element = "";
    bool accessoryPrefix = true;
    bool elementPrefix = true;
    bool specialEffectPrefix = true;
    double elementalDamage;
    double elementalChance;
    double elementalSecondary;
    double elementalTertiary;
    float meleePotency = 1.0f;
    float elementalPotency = 1.0f;
    float firePotency = 1.0f;
    float shockPotency = 1.0f;
    float frostPotency = 1.0f;
    float poisonPotency = 1.0f;
    String specialEffect = "";
    double specialEffectiveness;
    double specialEffectPotency;
    String rarity = "";
    double atkSpd;
    double dmg;
    double critChance;
    double critDamage;
    String swordBlade = "";
    String swordGuard = "";
    String swordHandle = "";
    String swordAccessory = "";
    Random odds = new Random();

    
    public int RarityOdds() {
        Random roll = new Random();
        float newRoll = 0.0f;
        float commonOdds =  (39.9f);
        float uncommonOdds = (25.0f);
        float rareOdds = (20.0f);
        float epicOdds = (10.0f);
        float legendaryOdds = (4.0f);
        float mythicOdds = (1.0f);
        float apocryphalOdds = (0.1f);
        List<float> odds = new List<float>();
        odds.Add(commonOdds);
        odds.Add(uncommonOdds);
        odds.Add(rareOdds);
        odds.Add(epicOdds);
        odds.Add(legendaryOdds);
        odds.Add(mythicOdds);
        odds.Add(apocryphalOdds);
        float total_weight = 100.0f;
        newRoll = (float) Math.Round((roll.NextDouble() * total_weight), 2);
        for (int i = 0; i < odds.Count; ++i) { 
            newRoll -= odds[i]; 
            if (newRoll <= 0) { 
                return i; 
                
            } 
         }
        
        return 0;
    }

    public void GenerateSwordImage(Weapons sword) {
        Weapons sword1 = new Weapons();
        foreach (string file in Directory.EnumerateFiles("D:\\VSC projects\\Weapons\\Weapon Info\\Sword Parts\\Sword Images\\Blades", "*.png")) {
            string bladeImages = File.ReadAllText(file);
        }
        foreach (string file in Directory.EnumerateFiles("D:\\VSC projects\\Weapons\\Weapon Info\\Sword Parts\\Sword Images\\Guards", "*.png")) {
            string guardImages = File.ReadAllText(file);
        }
        foreach (string file in Directory.EnumerateFiles("D:\\VSC projects\\Weapons\\Weapon Info\\Sword Parts\\Sword Images\\Handles", "*.png")) {
            string handleImages = File.ReadAllText(file);
        }
        switch(sword.swordBlade) {
            case "Orcish Blade":

                break;
        }
        // Bitmap bitmap = new Bitmap(bladeImages)
    }

    public void GenerateRandomSword(int swordCount) {

        for (int i = 0; i < swordCount; i++) {
            if(i < swordCount) {
                Weapons sword1 = new Weapons();
                Random odds = new Random(); 
                sword1.manufacturer = manufacturers[odds.Next(manufacturers.Length)];
                int elementsIndex = odds.Next(elements.Length);
                int specialEffectsIndex = odds.Next(specialEffects.Length);



                float elementsOdds = odds.Next(101);
                float specialEffectsOdds = odds.Next(101);
                float rarityOdds = odds.Next(101);

                level = odds.Next(1, levelCap);
                
                sword1.level = odds.Next(1, levelCap);
                sword1.critChance = 10;
                sword1.critDamage = 100;

                sword1.swordBlade = bladeType[odds.Next(bladeType.Length)];
                sword1.swordGuard = guardType[odds.Next(guardType.Length)];
                sword1.swordHandle = handleType[odds.Next(handleType.Length)];

                float accessoryOdds = odds.Next(101);

                if(accessoryOdds <= 40) {
                    sword1.swordAccessory = accessoryType[odds.Next(accessoryType.Length)];

                } else {
                    sword1.swordAccessory = "None";
                }
                if(sword1.manufacturer == "Draconic" || sword1.swordBlade == "Draconic Blade") {
                    sword1.element = elements[elementsIndex];
                } else {
                        if (elementsOdds <= 40) { 
                        sword1.element = "None";
                    } else {
                        sword1.element = elements[elementsIndex];

                    }

                }
                if(sword1.manufacturer == "Dwarven" || sword1.swordBlade == "Dwarven Blade") {
                    sword1.specialEffect = specialEffects[specialEffectsIndex];
                } else {
                        if (specialEffectsOdds <= 40) { 
                        sword1.specialEffect = "None";
                    } else {
                        sword1.specialEffect = specialEffects[specialEffectsIndex];

                    }

                }
                if((sword1.swordAccessory == "Magic Core" && sword1.element == "None") ||(sword1.swordAccessory == "Capacitor" && sword1.specialEffect == "None")) {
                    sword1.swordAccessory = "None";
                }
                sword1.rarity = rarities[RarityOdds()];

                sword1.GenerateSwordParts(sword1);
                
                Console.Write("\nLevel: " + sword1.level + "\n" + sword1.name + "\nDamage: " + sword1.dmg + "\nCritcal Strike Chance: " + sword1.critChance + "%" + "\nCritical Strike Damage: " + (100 + sword1.critDamage) + "%" + "\nAttack Speed: " + sword1.atkSpd + "\nManufacturer: " + sword1.manufacturer); 
                if (sword1.element != "None") {
                    Console.Write("\nElement: " + sword1.element + "\nElemental Effect Chance: " + sword1.elementalChance + "%");
                    switch (sword1.element) {
                        case "Fire": 
                            Console.Write("\nElemental Effect: Apply a burn to the target, dealing " + sword1.elementalDamage + " fire damage over second for 3 seconds. Kills on burning enemies deal " + sword1.elementalSecondary + " bonus fire damage in an area around them, and apply burn to enemies affected.");
                            break;
                        case "Shock":
                            Console.Write("\nElemental Effect: Deal " + sword1.elementalDamage + " shock damage to the primary target as well as up to " + sword1.elementalSecondary + " nearby enemies. Shock damage can chain back to the original target if there are not enough enemies to chain to.");
                            break;
                        case "Frost":
                            Console.Write("\nAttacks passively deal " + sword1.elementalDamage + "% bonus frost damage.\nElemental Effect: Apply frost to the target for 5 seconds, causing them to take " + sword1.elementalSecondary + "% bonus frost damage per stack from non frost weapons. Stacks up to " + sword1.elementalTertiary + " times for up to " + Math.Round((sword1.elementalSecondary * sword1.elementalTertiary),2) + "% bonus frost damage.");
                            break;
                        case "Poison":
                            Console.Write("\nElemental Effect: Apply poison to the target, dealing " + sword1.elementalDamage + " poison damage over 8 seconds per stack of poison. Each application of poison adds a stack, up to " + sword1.elementalSecondary + " times, dealing up to " + Math.Round((sword1.elementalDamage * sword1.elementalSecondary), 2) + " poison damage over 8 seconds.");
                            break;
                    }
                }
                if (sword1.specialEffect != "None") {
                    Console.Write("\nSpecial Effect: " + sword1.specialEffect);
                    switch (sword1.specialEffect) {
                        case "Bleeding":
                            Console.Write("\nDeal " + sword1.specialEffectiveness + " damage over 3 seconds to enemies you damage.");
                            break;
                        case "Penetrating":
                            Console.Write("\nDamage you deal penetrates " + sword1.specialEffectiveness + "% of enemy armor.");
                            break;
                        case "Rending": 
                            Console.Write("\nDamaging enemies slows their movement speed by " + sword1.specialEffectiveness + "%.");
                            break;
                        case "Lifesteal":
                            Console.Write("\nYou heal for " + sword1.specialEffectiveness + "% of damage you deal.");
                            break;
                    }
                }
                Console.Write("\nRarity: " + sword1.rarity);
                if (sword1.flavorText != "") {
                    Console.Write("\n" + sword1.flavorText + "\n" + sword1.uniqueDescription);
                }
                Console.Write("\n" + "\nParts:\n" + "Blade: " + sword1.swordBlade + "\nGuard: " + sword1.swordGuard + "\nHandle: " + sword1.swordHandle);
                if (sword1.swordAccessory != "None") {
                    Console.Write("\nAccessory: " + sword1.swordAccessory + "\n");
                } else {
                    Console.Write("\n");
                }
            }
        }

    }

    public Weapons GenerateSwordParts(Weapons sword) {
        Weapons sword1 = new Weapons();
        Random odds = new Random(); 
        sword1 = sword;
        int legendaryIndex = odds.Next(legendaries.Length);
        int mythicIndex = odds.Next(mythics.Length);
        int apocryphalIndex = odds.Next(apocryphals.Length);

        //base naming convention 
        switch (sword1.rarity) {
            case "Legendary": 
                sword1.name = legendaries[legendaryIndex];
                switch (sword1.name) {
                    case "BEST SORDD":
                        sword1.dmg = 75;
                        sword1.atkSpd = 0.325;
                        sword1.element = "None";
                        sword1.manufacturer = "Orcish";
                        sword1.swordBlade = "Orcish Blade";
                        sword1.flavorText = "Well, it had to be one of them.";
                        sword1.uniqueDescription = "Does a LOT of damage.";
                        break;
                    case "HOT HOT HOT":
                        sword1.dmg = 45;
                        sword1.atkSpd = 0.8;
                        sword1.element = "Fire";
                        sword1.manufacturer = "Orcish";
                        sword1.elementalDamage = (sword1.dmg * 0.60);
                        sword1.elementalChance = (112 / sword1.atkSpd);
                        sword1.elementalSecondary = Math.Round(sword1.dmg * 0.56, 2);
                        sword1.swordBlade = "Orcish Blade";
                        sword1.flavorText = "Pain is power.";
                        sword1.uniqueDescription = "Increased fire damage and application chance, lighting enemies on fire lights you on fire as well.";
                        sword1.elementPrefix = false;
                        break;
                    case "HAVOCK":
                        sword1.dmg = 15;
                        sword1.atkSpd = 1.3;
                        sword1.manufacturer = "Orcish";
                        sword1.swordBlade = "Orcish Blade";
                        sword1.critChance = 25;
                        sword1.critDamage = 400;
                        sword1.flavorText = "KEEP SWINGING!!!!";
                        sword1.uniqueDescription = "Decreased damage, massively increased attack speed, critical hit chance and critical hit damage.";
                        break;
                    case "APOCKALIPS":
                        sword1.dmg = 35;
                        sword1.atkSpd = 0.6;
                        sword1.manufacturer = "Orcish";
                        sword1.swordBlade = "Orcish Blade";
                        sword1.flavorText = "Collateral.";
                        sword1.uniqueDescription = "+50% Area of effect damage.";
                        break;
                    case "MURDER STIK":
                        sword1.dmg = 35;
                        sword1.atkSpd = 0.6;
                        sword1.manufacturer = "Orcish";
                        sword1.swordBlade = "Orcish Blade";
                        sword1.flavorText = "Collateral.";
                        sword1.uniqueDescription = "+50% attack range.";
                        break;
                    case "PLAGUEBRINGER":
                        sword1.dmg = 45;
                        sword1.atkSpd = 0.8;
                        sword1.element = "Poison";
                        sword1.manufacturer = "Orcish";
                        sword1.elementalDamage = (sword1.dmg * 0.30);
                        sword1.elementalChance = (56 / sword1.atkSpd);
                        sword1.elementalSecondary = Math.Ceiling(sword1.dmg * 0.028);
                        sword1.swordBlade = "Orcish Blade";
                        sword1.flavorText = "Spread it.";
                        sword1.uniqueDescription = "Increased poison damage and stack count. Poison spreads to you and nearby enemies.";  
                        sword1.elementPrefix = false;
                        break;
                    case "SPARCK PLUGG":
                        sword1.dmg = 45;
                        sword1.atkSpd = 0.8;
                        sword1.element = "Shock";
                        sword1.manufacturer = "Orcish";
                        sword.elementalDamage =  (sword1.dmg * 0.69);
                        sword.elementalChance = (56 / sword1.atkSpd);
                        sword1.elementalSecondary = Math.Ceiling(sword1.dmg * 0.028);
                        sword1.swordBlade = "Orcish Blade";
                        sword1.flavorText = "Handle with caution.";
                        sword1.uniqueDescription = "Increased shock damage and target count. Electricity may chain back to you.";  
                        sword1.elementPrefix = false;
                        break;
                    case "Grace":
                        break;
                    case "Shattered Glass":
                        break;
                    case "Eleanor's Grudge":
                        break;
                    case "Benevolence":
                        break;
                    case "Whisper":
                        break;
                    case "Angel Wing":
                        break;
                    case "Tidecaller":
                        break;
                    case "Blade of the Exile":
                        break;
                    case "Shattered Edge":
                        break;
                    case "Edge of Infinity":
                        break;
                    case "The Quickness":
                        break;
                    case "Midnight":
                        break;
                    case "Spark of the Heavens":
                        break;
                    case "The Wretched":
                        break;
                    case "Talon":
                        break;
                    case "Broken Scale":
                        break;
                    case "Breath of Winter":
                        break;
                    case "Oblivion":
                        break;
                    case "Unseen":
                        break;
                    case "Unheard":
                        break;
                    case "The Slasher":
                        break;
                    case "Nemesis":
                        break;
                    case "Gemini":
                        break;
                    case "Beholder":
                        break;
                    case "Bloodletter":
                        break;
                    case "Chronos":
                        break;
                    case "Fatal Injection":
                        break;
                    case "Vamp":
                        break;
                    case "Creeping Death":
                        break;
                    case "Iceage":
                        break;
                    case "The Nail":
                        break;
                    case "Blade of Ruin":
                        break;
                }
                break;
            case "Mythic":
                break;
            case "Apocryphal":
                break;  
            default:
                switch(sword.manufacturer) {
                    case "Orcish":
                    sword1.dmg = 40;
                    sword1.atkSpd = 0.65;
                    sword1.elementalPotency -= 0.25f;
                    switch(sword1.swordBlade) {
                        case "Orcish Blade":
                            sword1.name = "SMASHR";
                            break;
                        case "Elven Blade":
                            sword1.name = "STABER";
                            break;
                        case "Human Blade":
                            sword1.name = "SORDD";
                            break;
                        case "Draconic Blade":
                            sword1.name = "RAYZOR";
                            break;
                        case "Goblin Blade":
                            sword1.name = "NIFE";
                            break;
                        case "Dwarven Blade":
                            sword1.name = "CUTTR";
                            break;

                    }

                    break;
                    case "Elven":
                    sword1.dmg = 20;
                    sword1.atkSpd = 0.9;
                    sword1.critChance = 20;
                    sword1.critDamage = 125;
                    switch(sword1.swordBlade) {
                        case "Orcish Blade":
                            sword1.name = "Walloper";
                            break;
                        case "Elven Blade":
                            sword1.name = "Rapier";
                            break;
                        case "Human Blade":
                            sword1.name = "Longsword";
                            break;
                        case "Draconic Blade":
                            sword1.name = "Cutlass";
                            break;
                        case "Goblin Blade":
                            sword1.name = "Bayonet";
                            break;
                        case "Dwarven Blade":
                            sword1.name = "Poniard";
                            break;
                    }

                    break;
                    case "Human":
                    sword1.dmg = 30;
                    sword1.atkSpd = 1;
                    switch(sword1.swordBlade) {
                        case "Orcish Blade":
                            sword1.name = "Claymore";
                            break;
                        case "Elven Blade":
                            sword1.name = "Longsword";
                            break;
                        case "Human Blade":
                            sword1.name = "Blade";
                            break;
                        case "Draconic Blade":
                            sword1.name = "Brand";
                            break;
                        case "Goblin Blade":
                            sword1.name = "Knife";
                            break;
                        case "Dwarven Blade":
                            sword1.name = "Scimiter";
                            break;
                    }

                    break;
                    case "Draconic":
                    sword1.dmg = 25;
                    sword1.atkSpd = 0.8;
                    switch(sword1.swordBlade) {
                        case "Orcish Blade":
                            sword1.name = "Apex";
                            break;
                        case "Elven Blade":
                            sword1.name = "Katana";
                            break;
                        case "Human Blade":
                            sword1.name = "Shortsword";
                            break;
                        case "Draconic Blade":
                            sword1.name = "Broadsword";
                            break;
                        case "Goblin Blade":
                            sword1.name = "Stiletto";
                            break;
                        case "Dwarven Blade":
                            sword1.name = "Bodkin";
                            break;
                    }

                    break;
                    case "Goblin":
                    sword1.dmg = 15;
                    sword1.atkSpd = 2.25;
                    sword1.critChance += 5;
                    switch(sword1.swordBlade) {
                        case "Orcish Blade":
                            sword1.name = "Curtana";
                            break;
                        case "Elven Blade":
                            sword1.name = "Sidearm";
                            break;
                        case "Human Blade":
                            sword1.name = "Stylet";
                            break;
                        case "Draconic Blade":
                            sword1.name = "Anlace";
                            break;
                        case "Goblin Blade":
                            sword1.name = "Switchblade";
                            break;
                        case "Dwarven Blade":
                            sword1.name = "Skean";
                            break;
                    }

                    break;
                    case "Dwarven":
                    sword1.dmg = 25;
                    sword1.atkSpd = 0.8;
                    switch(sword1.swordBlade) {
                        case "Orcish Blade":
                            sword1.name = "Shank";
                            break;
                        case "Elven Blade":
                            sword1.name = "Lance";
                            break;
                        case "Human Blade":
                            sword1.name = "Cutter";
                            break;
                        case "Draconic Blade":
                            sword1.name = "Machete";
                            break;
                        case "Goblin Blade":
                            sword1.name = "Skiver";
                            break;
                        case "Dwarven Blade":
                            sword1.name = "Sabre";
                            break;
                    }
                    break;
                }
                break;
        }



    //Elemental Prefix calculation
    if (sword1.elementPrefix == true) {
        switch(sword1.element) {
                case "Fire":
                    switch(sword1.manufacturer) {
                        case "Orcish":
                            sword1.name = string.Concat("HOT " + sword1.name);
                            break;
                        case "Elven":
                            sword1.name = string.Concat("Blazing " + sword1.name);
                            break;
                        case "Human":
                            sword1.name = string.Concat("Fiery " + sword1.name);
                            break;
                        case "Draconic":
                            sword1.name = string.Concat("Cindering " + sword1.name);
                            break;
                        case "Goblin":
                            sword1.name = string.Concat("Heated " + sword1.name);
                            break;
                        case "Dwarven":
                            sword1.name = string.Concat("Smoldering " + sword1.name);
                            break;
                    }
                    break;
                case "Shock":
                    switch(sword1.manufacturer) {
                        case "Orcish":
                            sword1.name = string.Concat("STINGY " + sword1.name);
                            break;
                        case "Elven":
                            sword1.name = string.Concat("Electrifying " + sword1.name);
                            break;
                        case "Human":
                            sword1.name = string.Concat("Shocking " + sword1.name);
                            break;
                        case "Draconic":
                            sword1.name = string.Concat("Conducting " + sword1.name);
                            break;
                        case "Goblin":
                            sword1.name = string.Concat("Volatic " + sword1.name);
                            break;
                        case "Dwarven":
                            sword1.name = string.Concat("Energized " + sword1.name);
                            break;
                    }
                    break;
                case "Frost": 
                    switch(sword1.manufacturer) {
                        case "Orcish":
                            sword1.name = string.Concat("COLD " + sword1.name);
                            break;
                        case "Elven":
                            sword1.name = string.Concat("Glacial " + sword1.name);
                            break;
                        case "Human":
                            sword1.name = string.Concat("Freezing " + sword1.name);
                            break;
                        case "Draconic":
                            sword1.name = string.Concat("Frosty " + sword1.name);
                            break;
                        case "Goblin":
                            sword1.name = string.Concat("Polar " + sword1.name);
                            break;
                        case "Dwarven":
                            sword1.name = string.Concat("Gelid " + sword1.name);
                            break;
                    }
                    break;
                case "Poison":
                    switch(sword1.manufacturer) {
                        case "Orcish":
                            sword1.name = string.Concat("ICKY " + sword1.name);
                            break;
                        case "Elven":
                            sword1.name = string.Concat("Toxic " + sword1.name);
                            break;
                        case "Human":
                            sword1.name = string.Concat("Poisonous " + sword1.name);
                            break;
                        case "Draconic":
                            sword1.name = string.Concat("Pestilent " + sword1.name);
                            break;
                        case "Goblin":
                            sword1.name = string.Concat("Noxious " + sword1.name);
                            break;
                        case "Dwarven":
                            sword1.name = string.Concat("Virulent " + sword1.name);
                            break;
                    }  
                    break;
        }
    }

    //Special effect prefix calculation
    if(sword1.specialEffectPrefix == true) {
        switch (sword1.specialEffect) {
            case "Bleeding":
                switch(sword1.manufacturer) {
                    case "Orcish":
                        sword1.name = string.Concat("REDD " + sword1.name);
                        break;
                    case "Elven":
                        sword1.name = string.Concat("Sanguine " + sword1.name);
                        break;
                    case "Human":
                        sword1.name = string.Concat("Bloodletting " + sword1.name);
                        break;
                    case "Draconic":
                        sword1.name = string.Concat("Lasting " + sword1.name);
                        break;
                    case "Goblin":
                        sword1.name = string.Concat("Merciful " + sword1.name);
                        break;
                    case "Dwarven":
                        sword1.name = string.Concat("Lethal " + sword1.name);
                        break;
                }
                break;
            case "Penetrating":
                switch(sword1.manufacturer) {
                    case "Orcish":
                        sword1.name = string.Concat("SHARP " + sword1.name);
                        break;
                    case "Elven":
                        sword1.name = string.Concat("Benevolent " + sword1.name);
                        break;
                    case "Human":
                        sword1.name = string.Concat("Penetrating " + sword1.name);
                        break;
                    case "Draconic":
                        sword1.name = string.Concat("Sharpened " + sword1.name);
                        break;
                    case "Goblin":
                        sword1.name = string.Concat("Toothed " + sword1.name);
                        break;
                    case "Dwarven":
                        sword1.name = string.Concat("Notched " + sword1.name);
                        break;
                }
                break;
            case "Rending":
                switch(sword1.manufacturer) {
                    case "Orcish":
                        sword1.name = string.Concat("HEAVY " + sword1.name);
                        break;
                    case "Elven":
                        sword1.name = string.Concat("Overwhelming " + sword1.name);
                        break;
                    case "Human":
                        sword1.name = string.Concat("Rending " + sword1.name);
                        break;
                    case "Draconic":
                        sword1.name = string.Concat("Crushing " + sword1.name);
                        break;
                    case "Goblin":
                        sword1.name = string.Concat("Stunning " + sword1.name);
                        break;
                    case "Dwarven":
                        sword1.name = string.Concat("Devastating " + sword1.name);
                        break;
                }
                break;
            case "Lifesteal":
                switch(sword1.manufacturer) {
                    case "Orcish":
                        sword1.name = string.Concat("FEEL GOOD " + sword1.name);
                        break;
                    case "Elven":
                        sword1.name = string.Concat("Rejuvinating " + sword1.name);
                        break;
                    case "Human":
                        sword1.name = string.Concat("Angelic " + sword1.name);
                        break;
                    case "Draconic":
                        sword1.name = string.Concat("Mending " + sword1.name);
                        break;
                    case "Goblin":
                        sword1.name = string.Concat("Invigorating " + sword1.name);
                        break;
                    case "Dwarven":
                        sword1.name = string.Concat("Medicinal " + sword1.name);
                        break;
                }
                break;
        }
    }
   

    //Accessory prefix calculation
    if (sword1.accessoryPrefix == true) {
        switch(sword1.swordAccessory) {
            case "Reinforced Blade":
                switch(sword1.manufacturer) {
                    case "Orcish":
                        sword1.name = string.Concat("BIGG " + sword1.name);
                        break;
                    case "Elven":
                        sword1.name = string.Concat("Impactful " + sword1.name);
                        break;
                    case "Human":
                        sword1.name = string.Concat("Berserk " + sword1.name);
                        break;
                    case "Draconic":
                        sword1.name = string.Concat("Reforged " + sword1.name);
                        break;
                    case "Goblin":
                        sword1.name = string.Concat("Ultra-wide " + sword1.name);
                        break;
                    case "Dwarven":
                        sword1.name = string.Concat("Poignant " + sword1.name);
                        break;
                }
                break;
            case "Serrated Edge": 
                switch(sword1.manufacturer) {
                    case "Orcish":
                        sword1.name = string.Concat("XTRA SHARP " + sword1.name);
                        break;
                    case "Elven":
                        sword1.name = string.Concat("Serrated " + sword1.name);
                        break;
                    case "Human":
                        sword1.name = string.Concat("Rigid " + sword1.name);
                        break;
                    case "Draconic":
                        sword1.name = string.Concat("Scaled " + sword1.name);
                        break;
                    case "Goblin":
                        sword1.name = string.Concat("Subtle " + sword1.name);
                        break;
                    case "Dwarven":
                        sword1.name = string.Concat("Jagged " + sword1.name);
                        break;
                }
                break;
            case "Handle Tape":
                switch(sword1.manufacturer) {
                    case "Orcish":
                        sword1.name = string.Concat("STEDY " + sword1.name);
                        break;
                    case "Elven":
                        sword1.name = string.Concat("Focused " + sword1.name);
                        break;
                    case "Human":
                        sword1.name = string.Concat("Steady " + sword1.name);
                        break;
                    case "Draconic":
                        sword1.name = string.Concat("Cold-blooded " + sword1.name);
                        break;
                    case "Goblin":
                        sword1.name = string.Concat("Stable " + sword1.name);
                        break;
                    case "Dwarven":
                        sword1.name = string.Concat("Secure " + sword1.name);
                        break;
                }
                break;
            case "Magic Core":
                switch(sword1.manufacturer) {
                    case "Orcish":
                        sword1.name = string.Concat("GLOWEY " + sword1.name);
                        break;
                    case "Elven":
                        sword1.name = string.Concat("Tranquil " + sword1.name);
                        break;
                    case "Human":
                        sword1.name = string.Concat("Arcane " + sword1.name);
                        break;
                    case "Draconic":
                        sword1.name = string.Concat("Mystic " + sword1.name);
                        break;
                    case "Goblin":
                        sword1.name = string.Concat("Covert " + sword1.name);
                        break;
                    case "Dwarven":
                        sword1.name = string.Concat("Enigmatic " + sword1.name);
                        break;
                }
                break;
            case "Capacitor":
                switch(sword1.manufacturer) {
                    case "Orcish":
                        sword1.name = string.Concat("SMARTTY " + sword1.name);
                        break;
                    case "Elven":
                        sword1.name = string.Concat("Potent " + sword1.name);
                        break;
                    case "Human":
                        sword1.name = string.Concat("Charged " + sword1.name);
                        break;
                    case "Draconic":
                        sword1.name = string.Concat("Formidable " + sword1.name);
                        break;
                    case "Goblin":
                        sword1.name = string.Concat("Obscure " + sword1.name);
                        break;
                    case "Dwarven":
                        sword1.name = string.Concat("Dynamic " + sword1.name);
                        break;
                }
                break;
            
        }
    }


    //Blade calculation
    switch (sword1.swordBlade) {
        case "Orcish Blade":
            sword1.dmg = (sword.dmg * 1.25);
            sword1.atkSpd = (sword.atkSpd * 0.75);
            sword1.elementalPotency -= 0.25f;
            break;
        case "Elven Blade": 
            sword1.dmg = (sword.dmg * 0.80);
            sword1.critChance += 10;
            sword1.critDamage += 25;
            break;
        case "Human Blade":
            sword1.dmg = (sword.dmg * 1.1);
            sword1.atkSpd = (sword.atkSpd * 1.1);
            break;
        case "Draconic Blade":
            sword1.dmg = (sword.dmg * 0.75);
            break;
        case "Goblin Blade":
            sword1.dmg = (sword.dmg * 0.65);
            sword.atkSpd = (sword.atkSpd * 1.5); 
            break;
        case "Dwarven Blade":
            sword1.dmg = (sword.dmg * 0.75);
            break;
    }

    //Level calculation
    for (int i = 0; i < sword1.level; i++) {
        sword1.dmg = (sword1.dmg * 1.08);
    }
    //Rarity damage calculation
    switch(sword1.rarity){
        case "Common":
            sword1.dmg = (sword.dmg * 0.70);
            break;
        case "Uncommon":
            sword1.dmg = (sword.dmg * 0.85);
            break;
        case "Rare":
            break;
        case "Epic":
            sword1.dmg = (sword.dmg * 1.15);
            break;
        case "Legendary":
            sword1.dmg = (sword.dmg * 1.3);
            break;
        case "Mythic":
            sword1.dmg = (sword.dmg * 1.45);
            break;
        case "Apocryphal":
            sword1.dmg = (sword.dmg * 1.6);
            break;
    }

    //Guard calculation
    switch (sword1.swordGuard) {
        case "Orcish Guard":
            sword1.dmg = (sword.dmg * 1.1);
            break;
        case "Elven Guard": 
            sword1.critDamage += 10;
            break;
        case "Human Guard":
            sword1.dmg = (sword.dmg * 1.05);
            sword1.atkSpd = (sword.atkSpd * 1.05);
            break;
        case "Draconic Guard":
            switch(sword1.element) {
                case "None": 
                    sword1.dmg = (sword.dmg * 1.05);
                    break;
                default:
                    sword1.elementalDamage = (sword1.elementalDamage * 1.1);
                    sword1.elementalSecondary = (sword1.elementalSecondary * 1.1);
                    break;
            }
            break;
        case "Goblin Guard":
            sword.atkSpd = (sword.atkSpd * 1.1); 
            break;
        case "Dwarven Guard":
            switch(sword1.specialEffect) {
                case "None": 
                    sword1.dmg = (sword.atkSpd * 1.05);
                    break;
                default:
                    if(sword1.specialEffect != "None") {
                        sword1.specialEffectiveness = (sword1.specialEffectiveness * 1.1);
                    } 
                    break;
            }
            break;
    }
    //Handle calculation
    switch (sword1.swordHandle) {
        case "Orcish Handle":
            sword1.dmg = (sword.dmg * 1.2);
            sword1.atkSpd = (sword1.atkSpd * 0.8);
            break;
        case "Elven Handle": 
            sword1.critChance += 10;
            sword1.dmg = (sword1.dmg * 0.9);
            break;
        case "Human Handle":
            break;
        case "Draconic Handle":
            switch(sword1.element) {
                case "None": 
                    sword1.dmg = (sword.dmg * 1.1);
                    break;
                default:
                    sword1.elementalChance = (sword1.elementalChance * 1.1);
                    sword1.atkSpd = (sword1.atkSpd * 0.9);
                    break;
            }
            break;
        case "Goblin Handle":
            sword.atkSpd = (sword.atkSpd * 1.2);
            sword1.dmg = (sword1.dmg * 0.8); 
            break;
        case "Dwarven Handle":
            switch(sword1.specialEffect) {
                case "None": 
                    sword1.dmg = (sword.atkSpd * 1.1);
                    break;
                default:
                    if(sword1.specialEffect != "None") {
                        sword1.specialEffectiveness = (sword1.specialEffectiveness * 1.2);
                    } 
                    break;
            }
            break;
    }
    //Accessory calculation
    switch (sword1.swordAccessory) {
        case "Reinforced Blade":
            sword1.dmg = (sword1.dmg * 1.1);
            break;
        case "Serrated Edge":
            sword1.critChance += 5;
            sword1.critDamage += 10;
            break;
        case "Handle Tape":
            sword1.atkSpd = (sword1.atkSpd * 1.1);
            break;
        case "Magic Core":
            sword1.elementalDamage = (sword1.elementalDamage * 1.1);
            sword1.elementalChance = (sword1.elementalChance * 1.1);
            break;
        case "Capacitor":
            sword1.specialEffectiveness = (sword1.specialEffectiveness * 1.1);
            break;
        default:
            break;
    }

    //Elemental effect calculation and application

    switch (sword1.element) {
        case "None":
            break;
        default:
            switch (sword1.manufacturer) {
                case "Draconic": 
                    switch(sword1.swordBlade) {
                        case "Draconic Blade":
                            switch (sword1.element) {
                                case "Fire":
                                    sword1.elementalDamage = (sword1.dmg * 0.35);
                                    sword1.elementalChance = (56 / sword1.atkSpd);
                                    sword1.elementalSecondary = Math.Round(sword1.dmg * 0.56, 2);
                                    sword1.meleePotency -= 0.1f;
                                    break;
                                case "Shock":
                                    sword.elementalDamage =  (sword1.dmg * 0.49);
                                    sword.elementalChance = (56 / sword1.atkSpd);
                                    sword1.elementalSecondary = Math.Ceiling(sword1.dmg * 0.014);
                                    break;
                                case "Frost":
                                    sword1.elementalDamage = Math.Ceiling(((sword1.dmg * 0.14) / sword1.level) * 1);
                                    sword1.elementalChance = (56 / sword1.atkSpd);
                                    sword1.elementalSecondary = Math.Round(((sword1.dmg * 1.4) / sword1.level) / (sword1.level) * (100 - sword1.level),2 );
                                    sword1.elementalTertiary = Math.Ceiling((sword1.level * 0.1));
                                    break;
                                case "Poison":
                                    sword1.elementalDamage = (sword1.dmg * 0.21);
                                    sword1.elementalChance = (56 / sword1.atkSpd);
                                    sword1.elementalSecondary = Math.Ceiling(sword1.dmg * 0.014);
                                    break;
                            }
                            break;
                        default:
                            switch (sword1.element) {
                                case "Fire":
                                    sword1.elementalDamage = (sword1.dmg * 0.3);
                                    sword1.elementalChance = (48 / sword1.atkSpd);
                                    sword1.elementalSecondary = Math.Round(sword1.dmg * 0.48, 2);
                                    break;
                                case "Shock":
                                    sword.elementalDamage =  (sword1.dmg * 0.42);
                                    sword.elementalChance = (48 / sword1.atkSpd);
                                    sword1.elementalSecondary = Math.Ceiling(sword1.dmg * 0.012);
                                    break;
                                case "Frost":
                                    sword1.elementalDamage = Math.Ceiling(((sword1.dmg * 0.12) / sword1.level)*10);
                                    sword1.elementalChance = (48 / sword1.atkSpd);
                                    sword1.elementalSecondary = Math.Round(((sword1.dmg * 1.2) / sword1.level) / (sword1.level) * (100 - sword1.level),2 );
                                    sword1.elementalTertiary = Math.Ceiling((sword1.level * 0.1));
                                    break;
                                case "Poison":
                                    sword1.elementalDamage = (sword1.dmg * 0.18);
                                    sword1.elementalChance = (48 / sword1.atkSpd);
                                    sword1.elementalSecondary = Math.Ceiling(sword1.dmg * 0.012);
                                    break;
                            }
                            break;
                    }
                    break;

                default:
                    switch(sword1.swordBlade) {
                        case "Draconic Blade":
                            switch (sword1.element) {
                                case "Fire":
                                    sword1.elementalDamage = (sword1.dmg * 0.3);
                                    sword1.elementalChance = (48 / sword1.atkSpd);
                                    sword1.elementalSecondary = Math.Round(sword1.dmg * 0.48, 2);
                                    break;
                                case "Shock":
                                    sword.elementalDamage =  (sword1.dmg * 0.42);
                                    sword.elementalChance = (48 / sword1.atkSpd);
                                    sword1.elementalSecondary = Math.Ceiling(sword1.dmg * 0.012);
                                    break;
                                case "Frost":
                                    sword1.elementalDamage = Math.Ceiling(((sword1.dmg * 0.12) / sword1.level) * 10);
                                    sword1.elementalChance = (48 / sword1.atkSpd);
                                    sword1.elementalSecondary = Math.Round(((sword1.dmg * 1.2) / sword1.level) / (sword1.level) * (100 - sword1.level),2 );
                                    sword1.elementalTertiary = Math.Ceiling((sword1.level * 0.1));
                                    break;
                                case "Poison":
                                    sword1.elementalDamage = (sword1.dmg * 0.18);
                                    sword1.elementalChance = (48 / sword1.atkSpd);
                                    sword1.elementalSecondary = Math.Ceiling(sword1.dmg * 0.012);
                                    break;
                            }
                            break;
                        default:
                            switch (sword1.element) {
                                case "Fire":
                                    sword1.elementalDamage = (sword1.dmg * 0.25);
                                    sword1.elementalChance = (40 / sword1.atkSpd);
                                    sword1.elementalSecondary = Math.Round(sword1.dmg * 0.4, 2);
                                    break;
                                case "Shock":
                                    sword.elementalDamage = (sword1.dmg * 0.35);
                                    sword.elementalChance = (40 / sword1.atkSpd);
                                    sword1.elementalSecondary = Math.Ceiling(sword1.dmg * 0.01);
                                    break;
                                case "Frost":
                                    sword1.elementalDamage = Math.Ceiling(((sword1.dmg * 0.1) / sword1.level) * 10);
                                    sword1.elementalChance = (40 / sword1.atkSpd);
                                    sword1.elementalSecondary = Math.Round((sword1.dmg / sword1.level) / (sword1.level) * (100 - sword1.level),2 );
                                    sword1.elementalTertiary = Math.Ceiling((sword1.level * 0.1));
                                    break;
                                case "Poison":
                                    sword1.elementalDamage = (sword1.dmg * 0.15);
                                    sword1.elementalChance = (40 / sword1.atkSpd);
                                    sword1.elementalSecondary = Math.Ceiling(sword1.dmg * 0.01);
                                    break;
                            }
                            break;
                    }
                    break;
            }
            sword1.meleePotency -= 0.2f;
            break;
    }
    
    //Special effect calculation and application

    switch (sword1.specialEffect) {
        case "None":
            break;
        default:
            switch (sword1.manufacturer) {
                case "Dwarven": 
                    switch(sword1.swordBlade) {
                        case "Dwarven Blade":
                            switch(sword1.specialEffect) {
                                case "Bleeding": 
                                    sword1.specialEffectiveness = (sword1.dmg * 1);
                                    sword1.dmg = (sword1.dmg * 0.3);
                                    break;
                                case "Penetrating":
                                    sword1.specialEffectiveness = 28;
                                    break;
                                case "Rending":
                                    sword1.specialEffectiveness = 35;
                                    break;
                                case "Lifesteal":
                                    sword1.specialEffectiveness = 7;
                                    break;
                            }
                            break;
                        default:
                            switch(sword1.specialEffect) {
                                case "Bleeding": 
                                    sword1.specialEffectiveness = (sword1.dmg * 0.9);
                                    sword1.dmg = (sword1.dmg * 0.4);
                                    break;
                                case "Penetrating":
                                    sword1.specialEffectiveness = 24;
                                    break;
                                case "Rending":
                                    sword1.specialEffectiveness = 30;
                                    break;
                                case "Lifesteal":
                                    sword1.specialEffectiveness = 6;
                                    break;
                            }
                            break;
                    }
                    break;

                default:
                    switch(sword1.swordBlade) {
                        case "Dwarven Blade":
                            switch(sword1.specialEffect) {
                                case "Bleeding": 
                                    sword1.specialEffectiveness = (sword1.dmg * 0.9);
                                    sword1.dmg = (sword1.dmg * 0.4);
                                    break;
                                case "Penetrating":
                                    sword1.specialEffectiveness = 24;
                                    break;
                                case "Rending":
                                    sword1.specialEffectiveness = 30;
                                    break;
                                case "Lifesteal":
                                    sword1.specialEffectiveness = 6;
                                    break;
                            }
                            break;
                        default:
                            switch(sword1.specialEffect) {
                                case "Bleeding": 
                                    sword1.specialEffectiveness = (sword1.dmg * 0.75);
                                    sword1.dmg = (sword1.dmg * 0.5);
                                    break;
                                case "Penetrating":
                                    sword1.specialEffectiveness = 20;
                                    break;
                                case "Rending":
                                    sword1.specialEffectiveness = 25;
                                    break;
                                case "Lifesteal":
                                    sword1.specialEffectiveness = 5;
                                    break;
                            }

                            break;
                    }
                    break;
            }
            break;
    }

    sword1.atkSpd = Math.Round(sword1.atkSpd * sword1.meleePotency, 2); //Round attack speed to 2 decimals
    sword1.dmg = Math.Round(sword1.dmg * sword1.meleePotency, 2); //Round damage to 2 decimals
    sword1.elementalDamage = Math.Round(sword1.elementalDamage * sword1.elementalPotency, 2); //Round elemental damage to 2 decimals
    sword1.elementalChance = Math.Round(sword1.elementalChance * sword1.elementalPotency, 2); //Round elemental chance to 2 decimals
    sword1.specialEffectiveness = Math.Round(sword1.specialEffectiveness, 2); //Round special effectiveness to 2 decimals
    sword = sword1;
    return sword1; 
    }
    public static void Main()
    {
        Weapons sword1 = new Weapons();
        Random odds = new Random(); 
        sword1.GenerateSwordImage(sword1);
        sword1.GenerateRandomSword(10);
        
    }
}