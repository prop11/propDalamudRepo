using System.Collections.Generic;
using System.Numerics;

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
    uint TerritoryTypeId   // FFXIV TerritoryType row ID — used to check attunement via ETCGroup
);

public record ZoneData(
    string Name,
    string Expansion,
    uint TerritoryTypeId,
    uint MapId,              // Map sheet row ID for coordinate scaling
    List<AetherCurrent> Currents
);

/// <summary>
/// All field aether current coordinates sourced from the FFXIV Wiki.
/// Quest currents are included with their approximate NPC coordinates.
/// Territory IDs and Map IDs match the game's sheet data.
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
            new(16.4f, 22.4f, CurrentType.Quest, "Quest: Purple Flame, Purple Flame (Lv51)", 397),
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
            // Azys Lla has no field currents — all quest/MSQ
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
            new(8.4f,  21.4f, CurrentType.Field, "By the bridge north of Porta Praetoria", 621),
            new(14.5f, 29.6f, CurrentType.Field, "On a cliff by the Ala Mhigan Quarter", 621),
            new(26.7f, 34.5f, CurrentType.Field, "In the Lochs Shallows area", 621),
            new(36.5f, 32.4f, CurrentType.Field, "Near the Loch Seld coast", 621),
            new(13.6f, 11.6f, CurrentType.Quest, "Quest: A Soulful Reunion (Lv63)", 621),
            new(14.2f, 11.5f, CurrentType.Quest, "Quest: Beefy Boys (Lv63)", 621),
            new(10.8f, 22.2f, CurrentType.Quest, "Quest: Unrest in Porta Praetoria (Lv65)", 621),
            new(37.4f, 22.4f, CurrentType.Quest, "Quest: The Sword in the Star (Lv65)", 621),
            new(10.4f, 22.0f, CurrentType.Quest, "Quest: A Reward Long in Coming (Lv70, MSQ)", 621),
        }),

        new ZoneData("The Ruby Sea", "Stormblood", 613, 3, new()
        {
            new(37.5f, 13.2f, CurrentType.Field, "On a reef north of Tamamizu", 613),
            new(23.9f, 9.5f,  CurrentType.Field, "On an island near Onokoro", 613),
            new(29.4f, 28.7f, CurrentType.Field, "On a raised platform near the south coast", 613),
            new(11.5f, 36.8f, CurrentType.Field, "Near the Sui-no-Sato area", 613),
            new(28.4f, 15.6f, CurrentType.Quest, "Quest: Good-bye, Mr. Greggs (Lv62)", 613),
            new(24.1f, 9.1f,  CurrentType.Quest, "Quest: Tortoise in Time (Lv62)", 613),
            new(23.3f, 9.3f,  CurrentType.Quest, "Quest: Driftwood (Lv62)", 613),
            new(6.0f,  12.8f, CurrentType.Quest, "Quest: Tide Goes In, Imperials Go Out (Lv63)", 613),
            new(5.5f,  12.2f, CurrentType.Quest, "Quest: The Palace of Lost Souls (Lv63, MSQ)", 613),
        }),

        new ZoneData("Yanxia", "Stormblood", 614, 4, new()
        {
            new(23.9f, 19.0f, CurrentType.Field, "On the raised road near Namai", 614),
            new(31.7f, 16.7f, CurrentType.Field, "Near the Dairyu Moon Gates", 614),
            new(33.6f, 28.4f, CurrentType.Field, "On a hill near the One River", 614),
            new(27.9f, 35.8f, CurrentType.Field, "In the valley near Monzen", 614),
            new(30.3f, 27.4f, CurrentType.Quest, "Quest: The Grieve of Grief (Lv64)", 614),
            new(30.4f, 27.8f, CurrentType.Quest, "Quest: Steppe Child (Lv64)", 614),
            new(26.1f, 19.6f, CurrentType.Quest, "Quest: In the Footsteps of Bardam the Brave (Lv64, MSQ)", 614),
            new(17.8f, 30.7f, CurrentType.Quest, "Quest: An Unfortunate Coincidence (Lv64)", 614),
            new(18.0f, 30.9f, CurrentType.Quest, "Quest: Small Kindnesses (Lv64)", 614),
        }),

        new ZoneData("The Azim Steppe", "Stormblood", 622, 13, new()
        {
            new(22.5f, 22.0f, CurrentType.Field, "Near Mol Iloh, open steppe", 622),
            new(32.9f, 28.3f, CurrentType.Field, "Near the Dotharl Khaa", 622),
            new(15.9f, 33.3f, CurrentType.Field, "Near the Nhaama Desert edge", 622),
            new(16.4f, 15.4f, CurrentType.Field, "At the base of the Ijin highlands", 622),
            new(32.8f, 27.8f, CurrentType.Quest, "Quest: A Prickly Plaint (Lv64)", 622),
            new(8.9f,  12.7f, CurrentType.Quest, "Quest: Steppe Tragedy (Lv64)", 622),
            new(15.8f, 33.4f, CurrentType.Quest, "Quest: In the Footsteps of Bardam the Brave (Lv65, MSQ)", 622),
            new(32.2f, 28.8f, CurrentType.Quest, "Quest: A Request of the Xaela (Lv66)", 622),
            new(20.5f, 27.4f, CurrentType.Quest, "Quest: Riders on the Storm (Lv66, MSQ)", 622),
        }),

        // ─── SHADOWBRINGERS ──────────────────────────────────────────────────────
        new ZoneData("Lakeland", "Shadowbringers", 813, 2, new()
        {
            new(17.8f, 28.0f, CurrentType.Field, "Near the Source's Edge", 813),
            new(20.5f, 37.0f, CurrentType.Field, "South shore of Loch Seld", 813),
            new(35.2f, 22.4f, CurrentType.Field, "Near the Citia Swamps path", 813),
            new(37.9f, 13.6f, CurrentType.Field, "Northeast cliff face near Sullen", 813),
            new(36.8f, 22.3f, CurrentType.Quest, "Quest: In the Dark of the Wood (Lv70)", 813),
            new(26.4f, 16.4f, CurrentType.Quest, "Quest: The Flames of War (Lv72)", 813),
            new(17.4f, 28.1f, CurrentType.Quest, "Quest: The People We Choose to Be (Lv72)", 813),
            new(17.0f, 27.7f, CurrentType.Quest, "Quest: Nature's Cold Embrace (Lv72)", 813),
            new(36.5f, 22.1f, CurrentType.Quest, "Quest: A Little Normalcy (Lv73, MSQ)", 813),
        }),

        new ZoneData("Kholusia", "Shadowbringers", 814, 3, new()
        {
            new(27.5f, 18.5f, CurrentType.Field, "On a cliff east of Tomra", 814),
            new(12.5f, 8.9f,  CurrentType.Field, "North cliffs above Wright", 814),
            new(30.6f, 37.0f, CurrentType.Field, "Near Stilltide on the coast", 814),
            new(20.2f, 28.2f, CurrentType.Field, "On a hillside near Tomra path", 814),
            new(12.3f, 8.2f,  CurrentType.Quest, "Quest: A Sleep Disturbed (Lv70)", 814),
            new(25.2f, 18.2f, CurrentType.Quest, "Quest: The Key to the Castle (Lv73)", 814),
            new(12.9f, 8.6f,  CurrentType.Quest, "Quest: A Smile Unworn (Lv73)", 814),
            new(12.8f, 8.8f,  CurrentType.Quest, "Quest: A Fickle Existence (Lv73)", 814),
            new(25.7f, 18.3f, CurrentType.Quest, "Quest: With Tired Hands We Toil (Lv73, MSQ)", 814),
        }),

        new ZoneData("Il Mheg", "Shadowbringers", 816, 4, new()
        {
            new(8.8f,  30.8f, CurrentType.Field, "By a pixie ring near Lydha Lran", 816),
            new(18.6f, 4.2f,  CurrentType.Field, "On a floating rock near Pla Enni", 816),
            new(25.0f, 30.9f, CurrentType.Field, "Southeast of the Bookman's Shelves", 816),
            new(12.1f, 19.3f, CurrentType.Field, "Near Wolekdorf on a ledge", 816),
            new(15.3f, 31.4f, CurrentType.Quest, "Quest: Every Little Thing She Does Is Magia (Lv72)", 816),
            new(17.1f, 31.1f, CurrentType.Quest, "Quest: The Burden of Knowledge (Lv72)", 816),
            new(9.2f,  30.7f, CurrentType.Quest, "Quest: Talos Troubles (Lv74)", 816),
            new(9.1f,  30.6f, CurrentType.Quest, "Quest: The Lure of the Wild (Lv74)", 816),
            new(16.9f, 32.5f, CurrentType.Quest, "Quest: A Verdant Offering (Lv75, MSQ)", 816),
        }),

        new ZoneData("The Rak'tika Greatwood", "Shadowbringers", 817, 5, new()
        {
            new(21.2f, 16.5f, CurrentType.Field, "Below the canopy near Fanow", 817),
            new(19.9f, 27.2f, CurrentType.Field, "West of The Woven Oath", 817),
            new(30.1f, 28.0f, CurrentType.Field, "South of the Ondo Cups", 817),
            new(18.3f, 18.4f, CurrentType.Field, "Near Slitherbough edge", 817),
            new(22.1f, 18.8f, CurrentType.Quest, "Quest: A Fond Farewell (Lv74)", 817),
            new(22.3f, 18.6f, CurrentType.Quest, "Quest: A Little Dig (Lv74)", 817),
            new(19.2f, 28.1f, CurrentType.Quest, "Quest: Guardian of the Wood (Lv74)", 817),
            new(21.6f, 18.7f, CurrentType.Quest, "Quest: The Sorrow of Werlyt (Lv74)", 817),
            new(21.4f, 16.8f, CurrentType.Quest, "Quest: Shadowbringers (Lv79, MSQ)", 817),
        }),

        new ZoneData("Amh Araeng", "Shadowbringers", 815, 6, new()
        {
            new(26.8f, 16.4f, CurrentType.Field, "On a dune near the Inn at Journey's Head", 815),
            new(16.9f, 10.7f, CurrentType.Field, "North of Mord Souq on a rock shelf", 815),
            new(35.2f, 30.1f, CurrentType.Field, "East Amh Araeng near the Nabaath Areng entrance", 815),
            new(10.4f, 28.0f, CurrentType.Field, "West of the Mean cliffs", 815),
            new(25.2f, 17.5f, CurrentType.Quest, "Quest: A Pound of Flesh (Lv72)", 815),
            new(25.5f, 17.8f, CurrentType.Quest, "Quest: The Same Difference (Lv72)", 815),
            new(17.2f, 11.3f, CurrentType.Quest, "Quest: Good Vibrations (Lv76)", 815),
            new(17.4f, 11.1f, CurrentType.Quest, "Quest: A Liar in Every Port (Lv76)", 815),
            new(25.1f, 17.6f, CurrentType.Quest, "Quest: When the Bough Wakes (Lv78, MSQ)", 815),
        }),

        new ZoneData("The Tempest", "Shadowbringers", 818, 7, new()
        {
            new(32.1f, 16.8f, CurrentType.Field, "On a ledge near the Macarena", 818),
            new(36.5f, 10.8f, CurrentType.Field, "Northeast of The Caliban Gorge", 818),
            new(22.0f, 6.8f,  CurrentType.Field, "By the Caliban Gorge cliffs", 818),
            new(18.2f, 34.2f, CurrentType.Field, "Near the Ondo Cups depths", 818),
            new(35.1f, 16.5f, CurrentType.Quest, "Quest: An Unfamiliar Sky (Lv70)", 818),
            new(34.5f, 20.4f, CurrentType.Quest, "Quest: Between a Rock and a Hard Plaice (Lv78)", 818),
            new(35.0f, 20.0f, CurrentType.Quest, "Quest: Pride and Duty (Will Take You from the Mountain) (Lv78)", 818),
            new(34.7f, 20.2f, CurrentType.Quest, "Quest: What Nature Giveth (Lv78)", 818),
            new(36.0f, 17.0f, CurrentType.Quest, "Quest: Another Long Walk (Lv80, MSQ)", 818),
        }),

        // ─── ENDWALKER ───────────────────────────────────────────────────────────
        new ZoneData("Labyrinthos", "Endwalker", 956, 2, new()
        {
            new(11.3f, 14.2f, CurrentType.Field, "In the lower Aetherfont area", 956),
            new(8.9f,  28.9f, CurrentType.Field, "Near the Central Circuit", 956),
            new(29.1f, 36.5f, CurrentType.Field, "East Archeion passages", 956),
            new(36.7f, 21.2f, CurrentType.Field, "Near the Outer Circuit", 956),
            new(8.7f,  28.7f, CurrentType.Quest, "Quest: Seeking Proof (Lv80)", 956),
            new(11.5f, 14.0f, CurrentType.Quest, "Quest: Father of the Herd (Lv82)", 956),
            new(11.4f, 13.9f, CurrentType.Quest, "Quest: Keeping Up with the Aliapohs (Lv82)", 956),
            new(29.3f, 36.7f, CurrentType.Quest, "Quest: Catching Up (Lv83)", 956),
            new(8.8f,  28.8f, CurrentType.Quest, "Quest: Next in Line (Lv83, MSQ)", 956),
        }),

        new ZoneData("Thavnair", "Endwalker", 957, 3, new()
        {
            new(29.8f, 19.0f, CurrentType.Field, "Rocky terraces above Yedlihmad", 957),
            new(26.1f, 31.4f, CurrentType.Field, "Near the Shroud of the Samgha", 957),
            new(14.9f, 11.5f, CurrentType.Field, "Near the Gate of Nald", 957),
            new(22.5f, 8.3f,  CurrentType.Field, "Near Palaka's Stand coast", 957),
            new(25.7f, 30.8f, CurrentType.Quest, "Quest: Making Amends (Lv81)", 957),
            new(25.6f, 30.7f, CurrentType.Quest, "Quest: Memories in the Rain (Lv81)", 957),
            new(29.7f, 18.8f, CurrentType.Quest, "Quest: Paradise Found (Lv83)", 957),
            new(30.0f, 18.9f, CurrentType.Quest, "Quest: A Fisher in the Highest (Lv83)", 957),
            new(29.8f, 19.1f, CurrentType.Quest, "Quest: Radz-at-Han Dreamscape (Lv84, MSQ)", 957),
        }),

        new ZoneData("Garlemald", "Endwalker", 958, 4, new()
        {
            new(28.7f, 17.0f, CurrentType.Field, "In Camp Broken Glass ruins", 958),
            new(33.7f, 27.2f, CurrentType.Field, "Near the Tertium area", 958),
            new(16.8f, 22.1f, CurrentType.Field, "West near the Regio Urbanissima", 958),
            new(23.0f, 32.8f, CurrentType.Field, "South of the Forum Romanum ruins", 958),
            new(28.5f, 17.2f, CurrentType.Quest, "Quest: Doing It the Hard Way (Lv82)", 958),
            new(28.6f, 17.1f, CurrentType.Quest, "Quest: The Last Legionary (Lv82)", 958),
            new(33.5f, 27.0f, CurrentType.Quest, "Quest: In Search of Stability (Lv84)", 958),
            new(33.6f, 27.1f, CurrentType.Quest, "Quest: A Cry from the Void (Lv84)", 958),
            new(16.6f, 22.0f, CurrentType.Quest, "Quest: At World's End (Lv85, MSQ)", 958),
        }),

        new ZoneData("Mare Lamentorum", "Endwalker", 959, 5, new()
        {
            new(16.1f, 10.4f, CurrentType.Field, "Near the Sinus Lacrimarum", 959),
            new(27.6f, 18.8f, CurrentType.Field, "On the Frozen Tear plateau", 959),
            new(29.1f, 34.0f, CurrentType.Field, "Near the Bestways Burrow", 959),
            new(14.8f, 34.2f, CurrentType.Field, "West near the Lamentorum Peaks", 959),
            new(27.8f, 18.6f, CurrentType.Quest, "Quest: Where No Loporrit Has Gone Before (Lv83)", 959),
            new(27.7f, 18.7f, CurrentType.Quest, "Quest: Small Packages (Lv83)", 959),
            new(16.3f, 10.2f, CurrentType.Quest, "Quest: The Martinet of Mare Lamentorum (Lv85)", 959),
            new(16.2f, 10.3f, CurrentType.Quest, "Quest: Dost Thou Know the Loporrit? (Lv85)", 959),
            new(27.9f, 18.9f, CurrentType.Quest, "Quest: The Martinet's Matter (Lv85, MSQ)", 959),
        }),

        new ZoneData("Elpis", "Endwalker", 961, 6, new()
        {
            new(21.6f, 21.4f, CurrentType.Field, "Near Anagnorisis", 961),
            new(13.6f, 29.7f, CurrentType.Field, "South of Poieten Oikos", 961),
            new(30.8f, 9.7f,  CurrentType.Field, "North cliffs of Ktisis Hyperboreia", 961),
            new(32.2f, 31.7f, CurrentType.Field, "Near the Elpis coast southeast", 961),
            new(21.4f, 21.2f, CurrentType.Quest, "Quest: Just Measures (Lv86)", 961),
            new(21.5f, 21.3f, CurrentType.Quest, "Quest: A Mizzenmast Repast (Lv86)", 961),
            new(13.5f, 29.5f, CurrentType.Quest, "Quest: A Bold Beak (Lv86)", 961),
            new(13.7f, 29.6f, CurrentType.Quest, "Quest: A Dearth of Dolls (Lv86)", 961),
            new(21.3f, 21.1f, CurrentType.Quest, "Quest: Worthy of His Back (Lv87, MSQ)", 961),
        }),

        new ZoneData("Ultima Thule", "Endwalker", 960, 7, new()
        {
            new(13.5f, 29.7f, CurrentType.Field, "Near Reah Tahra", 960),
            new(25.0f, 29.9f, CurrentType.Field, "Near Abode of the Ea area", 960),
            new(34.2f, 17.0f, CurrentType.Field, "On the Ostrakon Deka-okto", 960),
            new(26.1f, 13.6f, CurrentType.Field, "Near Ostrakon Deka-hena", 960),
            new(13.3f, 29.5f, CurrentType.Quest, "Quest: Where Did the Stars Go? (Lv88)", 960),
            new(13.4f, 29.6f, CurrentType.Quest, "Quest: A Reward for Your Work (Lv88)", 960),
            new(25.1f, 30.0f, CurrentType.Quest, "Quest: The Ties That Bind (Lv89)", 960),
            new(25.2f, 29.8f, CurrentType.Quest, "Quest: Ask Not What Your Ea Can Do for You (Lv89)", 960),
            new(26.2f, 13.7f, CurrentType.Quest, "Quest: Beyond the Stars (Lv90, MSQ)", 960),
        }),

        // ─── DAWNTRAIL ────────────────────────────────────────────────────────────
        new ZoneData("Urqopacha", "Dawntrail", 1187, 2, new()
        {
            new(11.2f, 9.4f,  CurrentType.Field, "Near the Iq Br'aax hunting grounds", 1187),
            new(18.9f, 12.5f, CurrentType.Field, "Ridge east of Wachunpelo", 1187),
            new(25.0f, 8.2f,  CurrentType.Field, "By the summit trail going north", 1187),
            new(37.3f, 22.4f, CurrentType.Field, "East cliffs near Mamook", 1187),
            new(30.4f, 28.0f, CurrentType.Field, "South Urqopacha valley floor", 1187),
            new(14.8f, 29.7f, CurrentType.Field, "West valley near the Iq Br'aax", 1187),
            new(21.3f, 36.4f, CurrentType.Field, "Near the Rroneek Highlands lower path", 1187),
            new(34.9f, 35.8f, CurrentType.Field, "Southeast coast of Urqopacha", 1187),
            new(28.5f, 16.6f, CurrentType.Field, "North-central plateau", 1187),
            new(10.5f, 20.3f, CurrentType.Field, "Southwest mountains near Wachunpelo", 1187),
            new(12.1f, 9.5f,  CurrentType.Quest, "Quest: Growing Pains (Lv91)", 1187),
            new(18.7f, 12.3f, CurrentType.Quest, "Quest: Howl at the Rock (Lv91)", 1187),
            new(25.1f, 8.4f,  CurrentType.Quest, "Quest: A Place to Call Home (Lv92, MSQ)", 1187),
            new(37.1f, 22.2f, CurrentType.Quest, "Quest: In the Shadow of the Mountain (Lv92)", 1187),
            new(30.2f, 27.8f, CurrentType.Quest, "Quest: A Community in Bloom (Lv93, MSQ)", 1187),
        }),

        new ZoneData("Kozama'uka", "Dawntrail", 1188, 3, new()
        {
            new(21.4f, 9.6f,  CurrentType.Field, "North of Ok'hanu on a ridge", 1188),
            new(11.5f, 15.4f, CurrentType.Field, "West coast near the waterfall", 1188),
            new(17.4f, 22.1f, CurrentType.Field, "Near the Mamool Ja encampment", 1188),
            new(28.3f, 16.7f, CurrentType.Field, "East jungle path near Earthenshire", 1188),
            new(32.8f, 25.6f, CurrentType.Field, "Southeast near the Ok'hanu southern path", 1188),
            new(25.4f, 35.0f, CurrentType.Field, "South coast near Dock Poga", 1188),
            new(14.8f, 30.7f, CurrentType.Field, "West approach to the Voeburt ruins", 1188),
            new(36.9f, 14.0f, CurrentType.Field, "Northeast jungle canopy path", 1188),
            new(9.5f,  26.4f, CurrentType.Field, "Far west near the Lethe river", 1188),
            new(22.6f, 28.3f, CurrentType.Field, "Central Kozama'uka near Ok'hanu south", 1188),
            new(21.2f, 9.4f,  CurrentType.Quest, "Quest: The Strength of the Pack (Lv92)", 1188),
            new(11.3f, 15.2f, CurrentType.Quest, "Quest: The Winds of Change (Lv93)", 1188),
            new(17.2f, 21.9f, CurrentType.Quest, "Quest: Dawntrail (Lv93, MSQ)", 1188),
            new(28.1f, 16.5f, CurrentType.Quest, "Quest: A Verdant Past (Lv94)", 1188),
            new(32.6f, 25.4f, CurrentType.Quest, "Quest: For Want of a Memory (Lv94, MSQ)", 1188),
        }),

        new ZoneData("Yak T'el", "Dawntrail", 1189, 4, new()
        {
            new(15.7f, 21.0f, CurrentType.Field, "On a rocky ledge near the Aak Shaara", 1189),
            new(26.4f, 13.8f, CurrentType.Field, "Near Hhoh Kohshe open ground", 1189),
            new(32.2f, 8.9f,  CurrentType.Field, "North near the Winding Kvihrnnn", 1189),
            new(38.6f, 17.4f, CurrentType.Field, "Northeast Yak T'el near the Shaaloani border", 1189),
            new(35.0f, 31.2f, CurrentType.Field, "Southeast of the Aak Shaara", 1189),
            new(23.3f, 31.5f, CurrentType.Field, "South-central near the tangled roots", 1189),
            new(11.1f, 34.7f, CurrentType.Field, "West near the Hhoh Kohshe southern exit", 1189),
            new(8.3f,  22.9f, CurrentType.Field, "Far west edge near the cliffs", 1189),
            new(20.5f, 7.9f,  CurrentType.Field, "North near the Llavia range", 1189),
            new(28.7f, 25.9f, CurrentType.Field, "Central near Hhoh Kohshe", 1189),
            new(15.5f, 20.8f, CurrentType.Quest, "Quest: The Sound of a Grown Viper (Lv94)", 1189),
            new(26.2f, 13.6f, CurrentType.Quest, "Quest: Sibling Bonds (Lv95)", 1189),
            new(32.0f, 8.7f,  CurrentType.Quest, "Quest: Wormsign (Lv95)", 1189),
            new(38.4f, 17.2f, CurrentType.Quest, "Quest: Sins of the Father (Lv96, MSQ)", 1189),
            new(35.1f, 31.0f, CurrentType.Quest, "Quest: A Quest for Quests (Lv96)", 1189),
        }),

        new ZoneData("Shaaloani", "Dawntrail", 1190, 5, new()
        {
            new(22.4f, 13.3f, CurrentType.Field, "Ore extraction site north of Hhull Tribe", 1190),
            new(30.8f, 9.5f,  CurrentType.Field, "Northeast near the Llavia road", 1190),
            new(33.6f, 17.9f, CurrentType.Field, "Near the Anogg & Nogg excavation", 1190),
            new(16.6f, 22.3f, CurrentType.Field, "West-central near the Hhull railway", 1190),
            new(10.1f, 29.9f, CurrentType.Field, "Far west near the scrublands", 1190),
            new(24.5f, 31.0f, CurrentType.Field, "South of Hhull Tribe Dig", 1190),
            new(36.2f, 30.3f, CurrentType.Field, "Southeast near the Llavia basin", 1190),
            new(28.0f, 20.3f, CurrentType.Field, "Central plains", 1190),
            new(12.3f, 10.9f, CurrentType.Field, "Northwest corner near a canyon", 1190),
            new(21.5f, 36.8f, CurrentType.Field, "South Shaaloani near the boundary", 1190),
            new(22.2f, 13.1f, CurrentType.Quest, "Quest: Born under a Rotten Star (Lv96)", 1190),
            new(30.6f, 9.3f,  CurrentType.Quest, "Quest: A Miner Problem (Lv96)", 1190),
            new(33.4f, 17.7f, CurrentType.Quest, "Quest: Footprints in the Sand (Lv97, MSQ)", 1190),
            new(16.4f, 22.1f, CurrentType.Quest, "Quest: A Clamor for Comets (Lv97)", 1190),
            new(10.0f, 29.7f, CurrentType.Quest, "Quest: A Winsome Weasel (Lv98, MSQ)", 1190),
        }),

        new ZoneData("Heritage Found", "Dawntrail", 1191, 6, new()
        {
            new(10.2f, 9.3f,  CurrentType.Field, "Far north near the Sil'dihn ruins", 1191),
            new(21.8f, 10.4f, CurrentType.Field, "Near the Yyasulani station", 1191),
            new(34.8f, 11.1f, CurrentType.Field, "Northeast near the Yyasulani watchtower", 1191),
            new(17.5f, 21.6f, CurrentType.Field, "West-central of Heritage Found", 1191),
            new(30.0f, 21.2f, CurrentType.Field, "Near the Abode of the Ea bridge", 1191),
            new(10.5f, 30.5f, CurrentType.Field, "Southwest near the deep ruins", 1191),
            new(22.6f, 28.4f, CurrentType.Field, "Central Heritage near the old Allagan platforms", 1191),
            new(35.3f, 26.8f, CurrentType.Field, "Southeast near the fallen column", 1191),
            new(24.0f, 35.9f, CurrentType.Field, "South Heritage Found", 1191),
            new(37.1f, 36.3f, CurrentType.Field, "Far southeast corner", 1191),
            new(10.0f, 9.1f,  CurrentType.Quest, "Quest: Joyless in Tuliyollal (Lv98)", 1191),
            new(21.6f, 10.2f, CurrentType.Quest, "Quest: Where Fledglings Dare (Lv98)", 1191),
            new(34.6f, 10.9f, CurrentType.Quest, "Quest: A Land Without Gods (Lv99, MSQ)", 1191),
            new(17.3f, 21.4f, CurrentType.Quest, "Quest: The Saga of the Yyasulani (Lv99)", 1191),
            new(29.8f, 21.0f, CurrentType.Quest, "Quest: The Majesty of Blue (Lv100, MSQ)", 1191),
        }),

        new ZoneData("Living Memory", "Dawntrail", 1192, 7, new()
        {
            new(10.0f, 10.8f, CurrentType.Field, "Near Epcott in the memory district", 1192),
            new(22.8f, 8.5f,  CurrentType.Field, "Northern Living Memory", 1192),
            new(34.5f, 13.0f, CurrentType.Field, "Northeast near Aeternia", 1192),
            new(15.3f, 22.4f, CurrentType.Field, "West-central near Centurio path", 1192),
            new(29.2f, 20.5f, CurrentType.Field, "Central near Megaloterra", 1192),
            new(10.5f, 32.1f, CurrentType.Field, "Southwest Living Memory", 1192),
            new(23.4f, 30.6f, CurrentType.Field, "South-central near the preserved gardens", 1192),
            new(35.9f, 31.5f, CurrentType.Field, "Southeast near the Sil'dihn replica", 1192),
            new(19.6f, 38.2f, CurrentType.Field, "Far south near the ancient archive", 1192),
            new(32.0f, 38.0f, CurrentType.Field, "Far southeast corner of Living Memory", 1192),
            new(9.8f,  10.6f, CurrentType.Quest, "Quest: A Momentous Mind (Lv99)", 1192),
            new(22.6f, 8.3f,  CurrentType.Quest, "Quest: In the Face of the Enemy (Lv99)", 1192),
            new(34.3f, 12.8f, CurrentType.Quest, "Quest: Staying the Inevitable (Lv100, MSQ)", 1192),
            new(15.1f, 22.2f, CurrentType.Quest, "Quest: A Long Walk (Lv100)", 1192),
            new(29.0f, 20.3f, CurrentType.Quest, "Quest: Crossroads (Lv100, MSQ)", 1192),
        }),
    };

    /// <summary>Returns the list of unique expansion names in order.</summary>
    public static IEnumerable<string> Expansions()
    {
        yield return "Heavensward";
        yield return "Stormblood";
        yield return "Shadowbringers";
        yield return "Endwalker";
        yield return "Dawntrail";
    }

    /// <summary>Get zones for a given expansion name.</summary>
    public static IEnumerable<ZoneData> GetZones(string expansion) =>
        AllZones.FindAll(z => z.Expansion == expansion);

    /// <summary>Get zone by territory ID.</summary>
    public static ZoneData? GetZone(uint territoryTypeId) =>
        AllZones.Find(z => z.TerritoryTypeId == territoryTypeId);

    /// <summary>Get zone by name.</summary>
    public static ZoneData? GetZoneByName(string name) =>
        AllZones.Find(z => z.Name == name);
}
