using System.Collections.Generic;

namespace AetherCurrents.Data;

public enum CurrentType
{
    Field,  // Green orb in the world
    Quest   // Rewarded from a sidequest or MSQ
}

public record AetherCurrent(
    float X,
    float Y,
    CurrentType Type,
    string Description,
    uint TerritoryTypeId
);

public record ZoneData(
    string Name,
    string Expansion,
    uint TerritoryTypeId,
    uint MapId,
    List<AetherCurrent> Currents
);

/// <summary>
/// All aether current coordinates verified against ffxiv.consolegameswiki.com.
/// Field coords use x/y from wiki tables. Quest coords are NPC locations.
/// Zones where the NPC is in a different zone are noted in the description.
/// </summary>
public static class AetherCurrentDatabase
{
    public static readonly List<ZoneData> AllZones = new()
    {
        // ─── HEAVENSWARD ────────────────────────────────────────────────────────
        new ZoneData("Coerthas Western Highlands", "Heavensward", 397, 400, new()
        {
            new(30.6f, 33.7f, CurrentType.Field, "On road north of Falcon's Nest", 397),
            new(31.1f, 11.8f, CurrentType.Field, "Behind Gorgagne Mills", 397),
            new(15.8f, 22.3f, CurrentType.Field, "Overlooking The Convictory", 397),
            new(9.3f,  15.0f, CurrentType.Field, "On the edge of a cliff", 397),
            new(32.4f, 35.8f, CurrentType.Quest, "Quest: Bridge Over Frozen Water (Lv50)", 397),
            new(16.9f, 22.8f, CurrentType.Quest, "Quest: For All the Nights to Come (Lv51)", 397),
            new(16.7f, 22.8f, CurrentType.Quest, "Quest: Baby Steps (Lv51)", 397),
            new(16.5f, 22.5f, CurrentType.Quest, "Quest: Protecting What's Important (Lv51)", 397),
            new(16.4f, 22.4f, CurrentType.Quest, "Quest: Purple Flame, Purple Flame (Lv51, MSQ)", 397),
        }),

        new ZoneData("The Dravanian Forelands", "Heavensward", 398, 401, new()
        {
            new(37.8f, 28.3f, CurrentType.Field, "On top of the arched tree at zone entrance", 398),
            new(31.2f, 16.8f, CurrentType.Field, "In Whilom River, north of fork", 398),
            new(12.9f, 14.0f, CurrentType.Field, "In the cavern on Mourn", 398),
            new(30.6f, 36.2f, CurrentType.Field, "In Loth ast Gnath past second door", 398),
            new(31.9f, 23.9f, CurrentType.Quest, "Quest: Some Bad News (Lv52)", 398),
            new(24.9f, 19.7f, CurrentType.Quest, "Quest: Stolen Munitions (Lv52)", 398),
            new(16.4f, 23.0f, CurrentType.Quest, "Quest: A Lesson in Humility (Lv53)", 398),
            new(31.9f, 23.9f, CurrentType.Quest, "Quest: The Hunter Becomes the Kweh (Lv53)", 398),
            new(23.0f, 19.0f, CurrentType.Quest, "Quest: Mourn in Passing (Lv53, MSQ)", 398),
        }),

        new ZoneData("The Sea of Clouds", "Heavensward", 401, 407, new()
        {
            new(7.6f,  25.8f, CurrentType.Field, "Right when you get off the airship (MSQ)", 401),
            new(7.3f,  20.3f, CurrentType.Field, "Right before Ok' Zundu entrance", 401),
            new(18.9f, 11.6f, CurrentType.Field, "Next to Cid's Airship", 401),
            new(11.2f, 15.2f, CurrentType.Field, "Behind Vanu chieftain Sonu Vanu", 401),
            new(17.0f, 37.0f, CurrentType.Quest, "Quest: Clipped Wings (Lv50)", 401),
            new(11.5f, 10.9f, CurrentType.Quest, "Quest: Honoring the Past (Lv56) — NPC in The Pillars", 401),
            new(9.6f,  14.2f, CurrentType.Quest, "Quest: Sleepless in Ok' Zundu (Lv57)", 401),
            new(10.6f, 14.8f, CurrentType.Quest, "Quest: Flying the Nest (Lv57)", 401),
            new(11.0f, 14.0f, CurrentType.Quest, "Quest: Bolt, Chain, and Island (Lv57, MSQ)", 401),
        }),

        new ZoneData("The Churning Mists", "Heavensward", 402, 408, new()
        {
            new(30.9f, 35.7f, CurrentType.Field, "East tunnel from Moghome, up rocky ramp", 402),
            new(20.6f, 27.0f, CurrentType.Field, "In Asah", 402),
            new(7.0f,  27.4f, CurrentType.Field, "Top of the palace in Zenith", 402),
            new(29.3f, 19.9f, CurrentType.Field, "Path leading to Monsterie", 402),
            new(29.0f, 36.0f, CurrentType.Quest, "Quest: The Bathing Bully (Lv54)", 402),
            new(32.0f, 15.0f, CurrentType.Quest, "Quest: Waiting to Inhale (Lv54)", 402),
            new(27.0f, 33.0f, CurrentType.Quest, "Quest: Road Kill (Lv54)", 402),
            new(12.0f, 29.0f, CurrentType.Quest, "Quest: Hide Your Moogles (Lv54)", 402),
            new(13.0f, 11.0f, CurrentType.Quest, "Quest: Into the Aery (Lv55, MSQ) — NPC in Foundation", 402),
        }),

        new ZoneData("The Dravanian Hinterlands", "Heavensward", 399, 406, new()
        {
            new(37.1f, 25.5f, CurrentType.Field, "Entrance to area from MSQ", 399),
            new(24.5f, 19.0f, CurrentType.Field, "Across bridge east of Bigwest Shortstop", 399),
            new(12.8f, 16.8f, CurrentType.Field, "Entrance to The Answering Quarter", 399),
            new(13.5f, 36.1f, CurrentType.Field, "In caverns by Matoya's Cave", 399),
            new(21.0f, 18.0f, CurrentType.Quest, "Quest: Louder than Words (Lv58)", 399),
            new(7.0f,  6.0f,  CurrentType.Quest, "Quest: Ebb and Aetherflow (Lv58) — NPC in Idyllshire", 399),
            new(5.0f,  6.0f,  CurrentType.Quest, "Quest: Taking Stock (Lv58) — NPC in Idyllshire", 399),
            new(6.0f,  6.0f,  CurrentType.Quest, "Quest: Saro Roggo's Common Life (Lv59) — NPC in Matoya's Cave", 399),
            new(6.0f,  6.0f,  CurrentType.Quest, "Quest: Forbidden Knowledge (Lv59, MSQ) — NPC in Matoya's Cave", 399),
        }),

        new ZoneData("Azys Lla", "Heavensward", 403, 409, new()
        {
            // No field currents
            new(21.0f, 15.0f, CurrentType.Quest, "Quest: Systematic Exploration (Lv59, MSQ)", 403),
            new(6.0f,  10.0f, CurrentType.Quest, "Quest: In Node We Trust (Lv59, MSQ)", 403),
            new(27.0f, 10.0f, CurrentType.Quest, "Quest: Chimerical Maintenance (Lv59, MSQ)", 403),
            new(37.0f, 11.0f, CurrentType.Quest, "Quest: Close Encounters of the VIth Kind (Lv59, MSQ)", 403),
            new(18.0f, 31.0f, CurrentType.Quest, "Quest: Fetters of Lament (Lv59, MSQ)", 403),
        }),

        // ─── STORMBLOOD ─────────────────────────────────────────────────────────
        new ZoneData("The Fringes", "Stormblood", 612, 2, new()
        {
            new(36.3f, 17.2f, CurrentType.Field, "On a ledge below the upward path", 612),
            new(27.9f, 21.6f, CurrentType.Field, "On a cliff overlooking the village", 612),
            new(24.5f, 11.4f, CurrentType.Field, "On a rock by the path", 612),
            new(11.7f, 16.4f, CurrentType.Field, "Under the bridge", 612),
            new(8.4f,  11.2f, CurrentType.Quest, "Quest: Magiteknical Failure (Lv60)", 612),
            new(9.2f,  10.9f, CurrentType.Quest, "Quest: The Hidden Truth (Lv61)", 612),
            new(30.1f, 26.1f, CurrentType.Quest, "Quest: Eyes Bigger Than Her Stomach (Lv67)", 612),
            new(27.0f, 21.0f, CurrentType.Quest, "Quest: Unexpected Guests (Lv67)", 612),
            new(31.6f, 16.6f, CurrentType.Quest, "Quest: The Silence of the Gods (Lv67, MSQ)", 612),
        }),

        new ZoneData("The Peaks", "Stormblood", 620, 11, new()
        {
            new(24.4f, 30.6f, CurrentType.Field, "Edge of a small cliff", 620),
            new(11.7f, 26.4f, CurrentType.Field, "Edge of a cliff", 620),
            new(16.0f, 15.8f, CurrentType.Field, "Up stairs at (15.8, 14.2), go left 2/3 up", 620),
            new(25.5f, 6.4f,  CurrentType.Field, "NW of Ala Gannha, up two inclines", 620),
            new(24.3f, 6.8f,  CurrentType.Quest, "Quest: Saint Sayer (Lv61)", 620),
            new(27.7f, 28.7f, CurrentType.Quest, "Quest: A Hunger for Trade (Lv68)", 620),
            new(14.9f, 36.6f, CurrentType.Quest, "Quest: Out of Sight (Lv68)", 620),
            new(27.1f, 36.5f, CurrentType.Quest, "Quest: Closing Up Shop (Lv69)", 620),
            new(26.7f, 36.2f, CurrentType.Quest, "Quest: Liberty or Death (Lv69, MSQ)", 620),
        }),

        new ZoneData("The Lochs", "Stormblood", 621, 12, new()
        {
            new(13.8f, 21.8f, CurrentType.Field, "On a small rock next to a cliff, north of the main road", 621),
            new(23.6f, 37.2f, CurrentType.Field, "Edge of a cliff behind Sali Monastery", 621),
            new(35.1f, 31.9f, CurrentType.Field, "Next to one of the Gatekeeper map markers", 621),
            new(26.7f, 22.8f, CurrentType.Field, "At the edge of the podium overlooking the way in", 621),
            new(10.6f, 22.5f, CurrentType.Quest, "Quest: Are They Ill-Tempered (Lv69)", 621),
            new(8.2f,  20.5f, CurrentType.Quest, "Quest: If I Were a Fish (Lv69)", 621),
            new(10.9f, 21.0f, CurrentType.Quest, "Quest: A Rite to Rest (Lv69)", 621),
            new(11.3f, 20.6f, CurrentType.Quest, "Quest: It's a Zu Out There (Lv69)", 621),
            new(32.6f, 22.9f, CurrentType.Quest, "Quest: Stormblood (Lv70, MSQ)", 621),
        }),

        new ZoneData("The Ruby Sea", "Stormblood", 613, 3, new()
        {
            new(5.3f,  26.1f, CurrentType.Field, "Isle of Zekki — swim to underwater cave at (12.2, 25.3)", 613),
            new(35.3f, 20.4f, CurrentType.Field, "Below cliff next to a tree", 613),
            new(21.9f, 9.0f,  CurrentType.Field, "On roof of hut", 613),
            new(29.9f, 37.5f, CurrentType.Field, "Southwest of Sakazuki", 613),
            new(31.4f, 37.1f, CurrentType.Quest, "Quest: The Price of Betrayal (Lv62)", 613),
            new(23.4f, 9.1f,  CurrentType.Quest, "Quest: Pulling Double Booty (Lv62)", 613),
            new(32.7f, 18.5f, CurrentType.Quest, "Quest: The Sword in the Stone (Lv62)", 613),
            new(20.2f, 20.1f, CurrentType.Quest, "Quest: The Palace of Lost Souls (Lv63)", 613),
            new(6.2f,  12.3f, CurrentType.Quest, "Quest: Tide Goes In, Imperials Go Out (Lv63, MSQ)", 613),
        }),

        new ZoneData("Yanxia", "Stormblood", 614, 4, new()
        {
            new(31.4f, 29.5f, CurrentType.Field, "On ledge of rock", 614),
            new(24.7f, 21.2f, CurrentType.Field, "Climb to top of cliff in Namai", 614),
            new(30.6f, 37.9f, CurrentType.Field, "Edge of cliff, south end of Castrum Fluminis", 614),
            new(19.7f, 32.7f, CurrentType.Field, "Western edge of broken bridge", 614),
            new(30.1f, 18.9f, CurrentType.Quest, "Quest: Wolves and Weeds (Lv64)", 614),
            new(30.7f, 18.0f, CurrentType.Quest, "Quest: Whacking Day (Lv64)", 614),
            new(30.5f, 17.7f, CurrentType.Quest, "Quest: Fly, My Pretties (Lv64)", 614),
            new(29.9f, 15.6f, CurrentType.Quest, "Quest: Something Smells (Lv64)", 614),
            new(31.2f, 28.9f, CurrentType.Quest, "Quest: All the Little Angels (Lv64, MSQ)", 614),
        }),

        new ZoneData("The Azim Steppe", "Stormblood", 622, 13, new()
        {
            new(32.8f, 30.2f, CurrentType.Field, "Just outside Reunion southern entrance", 622),
            new(26.1f, 11.2f, CurrentType.Field, "Climb up cliff side and fall to lower ledge", 622),
            new(23.5f, 20.4f, CurrentType.Field, "Edge of The Dawn Throne (after The Children of Azim)", 622),
            new(7.5f,  34.6f, CurrentType.Field, "Southern edge of map", 622),
            new(12.7f, 34.4f, CurrentType.Quest, "Quest: Mauci of the Seven Worries (Lv66)", 622),
            new(23.0f, 23.3f, CurrentType.Quest, "Quest: Forty Years and Counting (Lv66)", 622),
            new(28.2f, 14.8f, CurrentType.Quest, "Quest: Sheep Snatcher (Lv65)", 622),
            new(32.9f, 28.3f, CurrentType.Quest, "Quest: Words Are Very Unnecessary (Lv65)", 622),
            new(31.2f, 12.1f, CurrentType.Quest, "Quest: Glory to the Khagan (Lv66, MSQ)", 622),
        }),

        // ─── SHADOWBRINGERS ──────────────────────────────────────────────────────
        new ZoneData("Lakeland", "Shadowbringers", 813, 2, new()
        {
            new(9.0f,  17.5f, CurrentType.Field, "On the castle wall, northwest of Amarokeep", 813),
            new(18.4f, 19.4f, CurrentType.Field, "On the second floor of the tower structure", 813),
            new(33.7f, 16.8f, CurrentType.Field, "On a small rocky ledge, east of the road fork", 813),
            new(32.5f, 28.5f, CurrentType.Field, "Atop stairs at The Accensor Gate", 813),
            new(7.4f,  14.4f, CurrentType.Quest, "Quest: An Unreasonable Request (Lv70)", 813),
            new(8.0f,  17.0f, CurrentType.Quest, "Quest: The Astute Amaro (Lv70)", 813),
            new(6.1f,  15.4f, CurrentType.Quest, "Quest: Imperative Repairs (Lv70)", 813),
            new(12.0f, 16.4f, CurrentType.Quest, "Quest: A Jobb Well Done (Lv70) — NPC in The Crystarium", 813),
            new(8.5f,  9.7f,  CurrentType.Quest, "Quest: Logistics of War (Lv72, MSQ) — NPC in The Crystarium", 813),
        }),

        new ZoneData("Amh Araeng", "Shadowbringers", 815, 6, new()
        {
            new(24.6f, 34.9f, CurrentType.Field, "Round platform in center of The Pristine Palace of Amh Malik", 815),
            new(14.6f, 16.7f, CurrentType.Field, "On the railroad track, east of Twine", 815),
            new(28.3f, 32.2f, CurrentType.Field, "The Derrick, directly south of The Inn at Journey's Head", 815),
            new(30.3f, 10.4f, CurrentType.Field, "North of bridge when entering from The Crystarium", 815),
            new(11.3f, 17.5f, CurrentType.Quest, "Quest: A Vein Pursuit (Lv70)", 815),
            new(11.8f, 17.4f, CurrentType.Quest, "Quest: Charmless Man (Lv70)", 815),
            new(12.9f, 16.9f, CurrentType.Quest, "Quest: Scavengers Assemble (Lv70)", 815),
            new(26.8f, 18.5f, CurrentType.Quest, "Quest: Work to Live or Live to Work (Lv70)", 815),
            new(15.8f, 29.1f, CurrentType.Quest, "Quest: A Fresh Start (Lv77, MSQ)", 815),
        }),

        new ZoneData("Il Mheg", "Shadowbringers", 816, 4, new()
        {
            new(21.2f, 16.5f, CurrentType.Field, "Platform on stairs towards Lyhe Ghiah", 816),
            new(30.1f, 6.0f,  CurrentType.Field, "Just northeast of the Wolekdorf Aetheryte", 816),
            new(21.8f, 4.4f,  CurrentType.Field, "Up a staircase of mushrooms in Pla Enni", 816),
            new(16.8f, 24.6f, CurrentType.Field, "The roof of a sunken house", 816),
            new(30.3f, 8.3f,  CurrentType.Quest, "Quest: A New Amaro (Lv70)", 816),
            new(15.7f, 30.4f, CurrentType.Quest, "Quest: The Path to Popularity (Lv70)", 816),
            new(9.2f,  17.1f, CurrentType.Quest, "Quest: Delightful Decorations (Lv70)", 816),
            new(14.1f, 32.6f, CurrentType.Quest, "Quest: The Forbidden Lran (Lv70)", 816),
            new(30.4f, 7.5f,  CurrentType.Quest, "Quest: Acht-la Ormh Inn (Lv73, MSQ)", 816),
        }),

        new ZoneData("Kholusia", "Shadowbringers", 814, 3, new()
        {
            new(20.2f, 21.1f, CurrentType.Field, "On top of a rock mound, southwest of road fork", 814),
            new(33.9f, 10.3f, CurrentType.Field, "In front of entrance to The Duergar's Tewel, on a hill", 814),
            new(8.4f,  33.2f, CurrentType.Field, "On the shoreline, next to a rock", 814),
            new(34.4f, 32.5f, CurrentType.Field, "End of a pier along the coast, next to a boat", 814),
            new(15.3f, 29.5f, CurrentType.Quest, "Quest: A Plankless Task (Lv70)", 814),
            new(18.8f, 17.9f, CurrentType.Quest, "Quest: Fugitive of Fear (Lv70)", 814),
            new(15.3f, 28.6f, CurrentType.Quest, "Quest: Village of Woe (Lv70)", 814),
            new(12.4f, 9.2f,  CurrentType.Quest, "Quest: A Disagreeable Dwarf (Lv70)", 814),
            new(18.7f, 17.6f, CurrentType.Quest, "Quest: Extinguishing the Last Light (Lv79, MSQ)", 814),
        }),

        new ZoneData("The Rak'tika Greatwood", "Shadowbringers", 817, 5, new()
        {
            new(35.1f, 16.2f, CurrentType.Field, "North-eastern edge of the cliff", 817),
            new(28.2f, 25.5f, CurrentType.Field, "Atop a cliff overlooking the blue petal path", 817),
            new(18.6f, 22.4f, CurrentType.Field, "On rock near the end of the Rotzatl River", 817),
            new(13.3f, 31.6f, CurrentType.Field, "North edge of the ruins of Fort Gohn", 817),
            new(31.3f, 16.9f, CurrentType.Quest, "Quest: Stand on Ceremony (Lv70)", 817),
            new(29.4f, 17.8f, CurrentType.Quest, "Quest: Suit Up (Lv70)", 817),
            new(19.8f, 27.6f, CurrentType.Quest, "Quest: The Great Deceiver (Lv70)", 817),
            new(18.8f, 27.7f, CurrentType.Quest, "Quest: What We Do for Family (Lv70)", 817),
            new(30.5f, 17.4f, CurrentType.Quest, "Quest: The Burden of Knowledge (Lv75, MSQ)", 817),
        }),

        new ZoneData("The Tempest", "Shadowbringers", 818, 7, new()
        {
            new(5.3f,  19.4f, CurrentType.Field, "On edge of cliff overlooking Amaurot", 818),
            new(28.2f, 15.9f, CurrentType.Field, "Underground path starts at (31.5, 16.2)", 818),
            new(22.4f, 11.2f, CurrentType.Field, "Near a rock formation north of Walls of the Forgotten", 818),
            new(29.1f, 7.2f,  CurrentType.Field, "Between rock ledges beneath pillar southeast of Kholusia transition", 818),
            new(9.5f,  28.2f, CurrentType.Quest, "Quest: Community Cohesion (Lv70)", 818),
            new(7.2f,  31.4f, CurrentType.Quest, "Quest: Debate and Discourse (Lv70)", 818),
            new(13.7f, 27.6f, CurrentType.Quest, "Quest: Responsible Creation (Lv70)", 818),
            new(32.1f, 16.6f, CurrentType.Quest, "Quest: Koal of the Cups (Lv70)", 818),
            new(8.8f,  26.5f, CurrentType.Quest, "Quest: A Greater Purpose (Lv80, MSQ)", 818),
        }),

        // ─── ENDWALKER ───────────────────────────────────────────────────────────
        new ZoneData("Labyrinthos", "Endwalker", 956, 2, new()
        {
            new(18.9f, 35.0f, CurrentType.Field, "On grass covered rock, west of Kokkol's Forge", 956),
            new(10.5f, 34.7f, CurrentType.Field, "On a ledge overlooking a tower, NW of Logistikon Gamma", 956),
            new(36.4f, 22.8f, CurrentType.Field, "In mineshaft, first tunnel on the left, on the ledge", 956),
            new(28.4f, 6.1f,  CurrentType.Field, "Atop the cliff next to the tower Mistloom", 956),
            new(30.3f, 19.3f, CurrentType.Quest, "Quest: Lost Little Troll (Lv80)", 956),
            new(21.0f, 21.5f, CurrentType.Quest, "Quest: Let the Good Times Troll (Lv80)", 956),
            new(20.8f, 21.0f, CurrentType.Quest, "Quest: The Lad in Labyrinthos (Lv80)", 956),
            new(23.2f, 19.9f, CurrentType.Quest, "Quest: Gleaner's Wish (Lv80)", 956),
            new(21.6f, 33.8f, CurrentType.Quest, "Quest: Bonds of Adamant(ite) (Lv88, MSQ)", 956),
        }),

        new ZoneData("Thavnair", "Endwalker", 957, 3, new()
        {
            new(17.9f, 32.2f, CurrentType.Field, "On ledge next to large rock, SW of Akyaali", 957),
            new(20.4f, 7.2f,  CurrentType.Field, "On a quarried ledge accessed from the left (Giantsgall Grounds)", 957),
            new(23.8f, 14.6f, CurrentType.Field, "In water at Pavana's Remorse (after Beyond the Depths of Despair)", 957),
            new(32.4f, 18.2f, CurrentType.Field, "SE of Palaka's Stand on some rocks (after Beyond the Depths of Despair)", 957),
            new(25.5f, 35.6f, CurrentType.Quest, "Quest: Steppe Child (Lv80)", 957),
            new(11.0f, 21.0f, CurrentType.Quest, "Quest: Alchemist or Dancer (Lv80)", 957),
            new(29.1f, 17.3f, CurrentType.Quest, "Quest: Radiant Patrol (Lv80)", 957),
            new(30.7f, 17.0f, CurrentType.Quest, "Quest: In Agama's Footsteps (Lv80)", 957),
            new(20.6f, 15.0f, CurrentType.Quest, "Quest: Simple Pleasures (Lv85, MSQ)", 957),
        }),

        new ZoneData("Garlemald", "Endwalker", 958, 4, new()
        {
            new(17.7f, 29.9f, CurrentType.Field, "On top of right rock outcropping east of Camp Broken Glass", 958),
            new(25.3f, 34.3f, CurrentType.Field, "In the ravine next to east of the Tapper's Den", 958),
            new(29.1f, 11.8f, CurrentType.Field, "Up the ramp to pedestrian sitting area, SW of Forum Solius", 958),
            new(9.4f,  14.9f, CurrentType.Field, "Behind a tree west of Forum Patens", 958),
            new(14.9f, 29.9f, CurrentType.Quest, "Quest: In Pursuit of Power (Lv80)", 958),
            new(31.4f, 13.1f, CurrentType.Quest, "Quest: Children Are Our Future (Lv80)", 958),
            new(12.8f, 30.6f, CurrentType.Quest, "Quest: Best Delivered Cold (Lv80)", 958),
            new(15.0f, 31.2f, CurrentType.Quest, "Quest: Stranded at the Station (Lv80)", 958),
            new(14.0f, 29.4f, CurrentType.Quest, "Quest: Gateway of the Gods (Lv83, MSQ)", 958),
        }),

        new ZoneData("Mare Lamentorum", "Endwalker", 959, 5, new()
        {
            new(22.3f, 18.1f, CurrentType.Field, "NW of Lovingway's Darlings, atop the cavern leading to Bestways Burrow", 959),
            new(11.8f, 9.5f,  CurrentType.Field, "Middle of The Carrotorium on raised platform, stairs to the west", 959),
            new(27.8f, 9.5f,  CurrentType.Field, "Directly on the left middle platform as you enter the Greatest Endsvale", 959),
            new(22.0f, 10.4f, CurrentType.Field, "Next to the large sphere on the second floor of Bestways Burrow", 959),
            new(15.4f, 11.6f, CurrentType.Quest, "Quest: True Carrot Crimes (Lv80)", 959),
            new(15.7f, 11.0f, CurrentType.Quest, "Quest: Carrots: It's What's for Dinner (Lv80)", 959),
            new(19.8f, 11.0f, CurrentType.Quest, "Quest: Alluring Allag (Lv80)", 959),
            new(22.0f, 10.7f, CurrentType.Quest, "Quest: Name That Way (Lv80)", 959),
            new(28.7f, 8.9f,  CurrentType.Quest, "Quest: Heart of the Matter (Lv84, MSQ)", 959),
        }),

        new ZoneData("Elpis", "Endwalker", 961, 6, new()
        {
            new(34.0f, 23.6f, CurrentType.Field, "To the south of The Mourning Dew, near the edge", 961),
            new(6.3f,  29.7f, CurrentType.Field, "On the middle rock ledge NW of The Twelve Wonders", 961),
            new(13.4f, 7.6f,  CurrentType.Field, "On the ledge to the south of Ktisis Hyperboreia", 961),
            new(10.3f, 24.9f, CurrentType.Field, "On a rock near two pillars, SW of Southerly Zephyrneus", 961),
            new(24.8f, 26.2f, CurrentType.Quest, "Quest: Touring Anagnorisis, Part I (Lv80)", 961),
            new(9.2f,  31.6f, CurrentType.Quest, "Quest: You and the Ailouros (Lv80)", 961),
            new(11.7f, 19.5f, CurrentType.Quest, "Quest: The Perks of Being a Lost Flower (Lv80)", 961),
            new(8.6f,  17.6f, CurrentType.Quest, "Quest: An Expected Guest (Lv80)", 961),
            new(31.6f, 15.4f, CurrentType.Quest, "Quest: Caging the Messenger (Lv87, MSQ)", 961),
        }),

        new ZoneData("Ultima Thule", "Endwalker", 960, 7, new()
        {
            new(32.2f, 26.2f, CurrentType.Field, "Head north from Base Omicron, in a corner", 960),
            new(34.7f, 29.7f, CurrentType.Field, "Northeast of Stigma-1, on the edge of the map", 960),
            new(21.7f, 6.3f,  CurrentType.Field, "Beside a rock pillar north of Abode of the Ea", 960),
            new(14.8f, 14.2f, CurrentType.Field, "On a rise northwest of Hollow of the Flesh", 960),
            new(23.5f, 12.3f, CurrentType.Quest, "Quest: A Most Stimulating Discussion (Lv80)", 960),
            new(22.4f, 11.0f, CurrentType.Quest, "Quest: Ending as One (Lv80)", 960),
            new(30.8f, 27.7f, CurrentType.Quest, "Quest: Combat Evolved (Lv80)", 960),
            new(31.0f, 27.9f, CurrentType.Quest, "Quest: The Will to Live (Lv80)", 960),
            new(21.4f, 34.5f, CurrentType.Quest, "Quest: Beyond the Stars (Lv90, MSQ)", 960),
        }),

        // ─── DAWNTRAIL ────────────────────────────────────────────────────────────
        // Dawntrail field currents verified from individual zone wiki pages.
        // Quest coords also from zone wiki pages.
        // NOTE: Ultima Thule quests 4+5 are from my training data — wiki page was truncated.

        new ZoneData("Urqopacha", "Dawntrail", 1187, 2, new()
        {
            new(28.5f, 16.7f, CurrentType.Field, "On a boulder near Icuvlo's Inn", 1187),
            new(12.3f, 11.6f, CurrentType.Field, "On cliff NW of Miplu's Mate Garden", 1187),
            new(17.4f, 17.4f, CurrentType.Field, "On a boulder SW of Ciblu's Coffee Grounds", 1187),
            new(29.7f, 7.8f,  CurrentType.Field, "East of Agave Jaw", 1187),
            new(18.7f, 9.8f,  CurrentType.Field, "NW of Ciblu's Coffee Grounds, on top of the slope", 1187),
            new(17.5f, 20.3f, CurrentType.Field, "Bottom cliff at Proof", 1187),
            new(5.2f,  23.5f, CurrentType.Field, "On boulder at east edge of Worqor Lar Dor", 1187),
            new(22.8f, 36.4f, CurrentType.Field, "On cliff edge east of Chirwagur Lake", 1187),
            new(28.8f, 21.2f, CurrentType.Field, "NE of Shades of Grief, behind stone tower", 1187),
            new(29.4f, 26.7f, CurrentType.Field, "Topside edge of cliff north of Worlar's Echo", 1187),
            new(29.1f, 13.0f, CurrentType.Quest, "Quest: A Crisis of Corruption (Lv90)", 1187),
            new(29.3f, 13.7f, CurrentType.Quest, "Quest: A Traveler to the Rescue (Lv90)", 1187),
            new(5.4f,  24.2f, CurrentType.Quest, "Quest: The Feat of Ice (Lv93, MSQ)", 1187),
            new(29.9f, 33.5f, CurrentType.Quest, "Quest: The Flame Burns No More (Lv90)", 1187),
            new(29.4f, 32.3f, CurrentType.Quest, "Quest: An Illuminating Ritual (Lv90)", 1187),
        }),

        new ZoneData("Kozama'uka", "Dawntrail", 1188, 3, new()
        {
            new(27.4f, 7.7f,  CurrentType.Field, "NW of the House of Waters High", 1188),
            new(9.4f,  17.8f, CurrentType.Field, "NE of the Xodune", 1188),
            new(8.7f,  11.7f, CurrentType.Field, "Under stairs of House of Winds High", 1188),
            new(39.8f, 13.4f, CurrentType.Field, "NW of the Dock Poga", 1188),
            new(31.8f, 14.5f, CurrentType.Field, "NW of the Stride of the Sun", 1188),
            new(15.6f, 34.3f, CurrentType.Field, "Next to wrecked ships north of Shoals of No Return", 1188),
            new(22.4f, 27.2f, CurrentType.Field, "West of Many Fires Aetheryte", 1188),
            new(6.4f,  23.9f, CurrentType.Field, "Cave west of The Imperious", 1188),
            new(24.0f, 31.9f, CurrentType.Field, "Island in Marsh Ligaka", 1188),
            new(31.1f, 38.1f, CurrentType.Field, "Edge of cliff in The Dewspun Bank", 1188),
            new(18.8f, 13.0f, CurrentType.Quest, "Quest: Rite of the Wind's Chosen (Lv90)", 1188),
            new(20.0f, 11.7f, CurrentType.Quest, "Quest: Ripe for the Offering (Lv90)", 1188),
            new(11.0f, 27.8f, CurrentType.Quest, "Quest: All Good Potpacts Must Come to an End (Lv90)", 1188),
            new(11.6f, 26.9f, CurrentType.Quest, "Quest: Divine Inspiration (Lv90)", 1188),
            new(31.8f, 25.5f, CurrentType.Quest, "Quest: Sibling Rescue (Lv92, MSQ)", 1188),
        }),

        new ZoneData("Yak T'el", "Dawntrail", 1189, 4, new()
        {
            new(19.1f, 10.9f, CurrentType.Field, "Along the path to Iq Br'aax from the dirigible landing", 1189),
            new(29.7f, 10.5f, CurrentType.Field, "Just north of the Village of Ilyon Asoh", 1189),
            new(10.4f, 18.7f, CurrentType.Field, "On a ridge overlooking Xmun Hojaw", 1189),
            new(17.5f, 6.7f,  CurrentType.Field, "Just north of Yak Awak Tsoly", 1189),
            new(33.6f, 26.1f, CurrentType.Field, "At the top of the ridge overlooking the Ty'iinbek Traverse", 1189),
            new(19.1f, 33.9f, CurrentType.Field, "In the river at the bottom of a ramp near Cenote Jayunja", 1189),
            new(22.2f, 21.4f, CurrentType.Field, "On a small ridge east of Moxutural Zooj", 1189),
            new(7.9f,  26.2f, CurrentType.Field, "At the top of the ridge around Ankledeep", 1189),
            new(25.5f, 24.6f, CurrentType.Field, "In a wooden arch on the SE corner of Choliselvaas", 1189),
            new(36.4f, 35.7f, CurrentType.Field, "Down the path SE of the Mamook aetheryte", 1189),
            new(13.3f, 13.5f, CurrentType.Quest, "Quest: Aiming High (Lv90)", 1189),
            new(22.2f, 8.8f,  CurrentType.Quest, "Quest: Secrets in the Cinderfield (Lv90)", 1189),
            new(31.4f, 32.7f, CurrentType.Quest, "Quest: Road to the Golden City (Lv95, MSQ)", 1189),
            new(33.1f, 31.6f, CurrentType.Quest, "Quest: Beast of the Heartland (Lv90)", 1189),
            new(32.1f, 31.3f, CurrentType.Quest, "Quest: Lost and Powerless (Lv90)", 1189),
        }),

        new ZoneData("Shaaloani", "Dawntrail", 1190, 5, new()
        {
            new(27.3f, 31.5f, CurrentType.Field, "Second floor in back of first building, east side of town", 1190),
            new(7.2f,  19.8f, CurrentType.Field, "Mountain on the east side of town", 1190),
            new(9.4f,  14.4f, CurrentType.Field, "Small plateau NW from the cemetery", 1190),
            new(17.6f, 20.4f, CurrentType.Field, "Boulder on the north side of old mining town", 1190),
            new(9.0f,  27.9f, CurrentType.Field, "East end of the canyon, behind a stone pillar", 1190),
            new(20.2f, 17.9f, CurrentType.Field, "South of the train track switcher at Shaaloani Station", 1190),
            new(29.0f, 11.3f, CurrentType.Field, "On a small pier by Lake Toari, SE from the Aetheryte", 1190),
            new(34.4f, 13.1f, CurrentType.Field, "On top of a plateau in the middle of nowhere", 1190),
            new(25.1f, 20.2f, CurrentType.Field, "East side of Lake Toari, in a small set of mountains", 1190),
            new(34.6f, 23.1f, CurrentType.Field, "East side of the map", 1190),
            new(28.9f, 30.2f, CurrentType.Quest, "Quest: When the Bill Comes Due (Lv90)", 1190),
            new(19.2f, 27.8f, CurrentType.Quest, "Quest: Meeting of the Spirits (Lv90)", 1190),
            new(27.2f, 11.8f, CurrentType.Quest, "Quest: Rroneek Seeker (Lv90)", 1190),
            new(13.9f, 19.1f, CurrentType.Quest, "Quest: A Bad Case of the Blue Devils (Lv90)", 1190),
            new(15.1f, 17.9f, CurrentType.Quest, "Quest: A Hot Commodity (Lv96, MSQ)", 1190),
        }),

        new ZoneData("Heritage Found", "Dawntrail", 1191, 6, new()
        {
            new(29.4f, 25.9f, CurrentType.Field, "West of the Yyasulani Station Aetheryte", 1191),
            new(25.5f, 7.8f,  CurrentType.Field, "Inside the cavern at Earthen Sky", 1191),
            new(23.0f, 18.5f, CurrentType.Field, "Atop a cliff between Tesh'pyani Village and Yyupye's Halo", 1191),
            new(33.6f, 17.6f, CurrentType.Field, "Southwest from an energy tower", 1191),
            new(35.1f, 11.1f, CurrentType.Field, "North of the train tracks", 1191),
            new(9.7f,  12.1f, CurrentType.Field, "Atop the hill south of The Driftdowns", 1191),
            new(9.4f,  26.8f, CurrentType.Field, "Atop the south plateau, behind some stones", 1191),
            new(15.7f, 16.1f, CurrentType.Field, "At the center of an archway bridge, west side of Archeo Alexandria", 1191),
            new(20.8f, 28.1f, CurrentType.Field, "Atop a plateau SE from the Electrope Strike Aetheryte", 1191),
            new(12.3f, 35.3f, CurrentType.Field, "Center of Submerged Skyline town", 1191),
            new(17.9f, 9.4f,  CurrentType.Quest, "Quest: Stressed Testing (Lv90)", 1191),
            new(18.4f, 9.8f,  CurrentType.Quest, "Quest: Aunty Knows Best (Lv90)", 1191),
            new(17.2f, 33.4f, CurrentType.Quest, "Quest: He Who Remembers (Lv90)", 1191),
            new(9.4f,  11.6f, CurrentType.Quest, "Quest: Phyt for Survival (Lv90)", 1191),
            new(5.9f,  6.2f,  CurrentType.Quest, "Quest: Unto the Summit (Lv99, MSQ)", 1191),
        }),

        new ZoneData("Living Memory", "Dawntrail", 1192, 7, new()
        {
            new(7.5f,  30.9f, CurrentType.Field, "Center of gazebo at the square", 1192),
            new(36.5f, 28.4f, CurrentType.Field, "Right at the right castle stairs", 1192),
            new(11.1f, 35.1f, CurrentType.Field, "By the gondolas", 1192),
            new(26.1f, 32.3f, CurrentType.Field, "Central area", 1192),
            new(33.9f, 34.2f, CurrentType.Field, "Behind the ticketing booth at the Ferris wheel", 1192),
            new(31.6f, 8.4f,  CurrentType.Field, "Northern area", 1192),
            new(10.2f, 11.3f, CurrentType.Field, "Top corner of the museum balcony", 1192),
            new(37.7f, 10.7f, CurrentType.Field, "Northeast area", 1192),
            new(24.8f, 15.3f, CurrentType.Field, "Near the lava river", 1192),
            new(11.8f, 20.4f, CurrentType.Field, "Behind an electrope tree", 1192),
            new(8.7f,  31.4f, CurrentType.Quest, "Quest: Well-wishing at the Wishing Well (Lv90)", 1192),
            new(30.9f, 35.6f, CurrentType.Quest, "Quest: Perplexing Puzzles, Endless Fun (Lv90)", 1192),
            new(34.0f, 15.8f, CurrentType.Quest, "Quest: Volcanic Disruptions (Lv90)", 1192),
            new(32.2f, 17.6f, CurrentType.Quest, "Quest: Blueprint Protocol (Lv90)", 1192),
            new(11.0f, 12.5f, CurrentType.Quest, "Quest: A Journey Never-ending (Lv100, MSQ)", 1192),
        }),
    };

    public static IEnumerable<string> Expansions()
    {
        yield return "Heavensward";
        yield return "Stormblood";
        yield return "Shadowbringers";
        yield return "Endwalker";
        yield return "Dawntrail";
    }

    public static IEnumerable<ZoneData> GetZones(string expansion) =>
        AllZones.FindAll(z => z.Expansion == expansion);

    public static ZoneData? GetZone(uint territoryTypeId) =>
        AllZones.Find(z => z.TerritoryTypeId == territoryTypeId);

    public static ZoneData? GetZoneByName(string name) =>
        AllZones.Find(z => z.Name == name);
}
