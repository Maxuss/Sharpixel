using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharpixel.API.Requests;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json.Converters;

namespace Sharpixel.API.Elements
{
    /// <summary>
    /// Class used for storing data from request to <a href="https://api.hypixel.net/player">Player API</a>
    /// </summary>
    public sealed class Player : RequestElement
    {
        /// <summary>
        /// Where the player data is stored. Is <i>nullable</i>
        /// </summary>
#nullable enable
        [JsonProperty("player")]
        public PlayerRequest? PlayerData;
#nullable disable
    }

    /// <summary>
    /// Class returned from doing request to player API.
    /// </summary>
    public sealed class PlayerRequest
    {
        /// <summary>
        /// Represents Hypixel ID of player
        /// </summary>
        [JsonProperty("id")]
        public string ID;
        /// <summary>
        /// Represents Mojang UUID of player
        /// </summary>
        [JsonProperty("uuid")]
        public string UUID;
        /// <summary>
        /// Represents Nickname of player
        /// </summary>
        [JsonProperty("playername")]
        public string PlayerName;
        /// <summary>
        /// Unix Timestamp in milliseconds since when player first logged in
        /// </summary>
        [JsonProperty("firstLogin")]
        public ulong FirstLogin;
        /// <summary>
        /// Unix Timestamp in milliseconds since when player last logged in
        /// </summary>
        [JsonProperty("lastLogin")]
        public ulong LastLogin;
        /// <summary>
        /// All known aliases of player, a.k.a. all previous nicknames of player.
        /// </summary>
        [JsonProperty("knownAliases")]
        public string[] KnownAliases;
        [JsonProperty("knownAliasesLower")]
        public string[] KnowAliasesLower;
        [JsonProperty("achievementsOneTime")]
        public string[] OneTimeAchievments;
#nullable enable
        [JsonProperty("stats")]
        public PlayerStats? Stats;
#nullable disable
        [JsonProperty("achievementPoints")]
        public ulong AchievementPoins;
        [JsonProperty("achievements")]
        public IDictionary<string, int> TieredAchievements;
        [JsonProperty("networkExp")]
        public long NetworkExperience;
        [JsonProperty("lastLogout")]
        public ulong LastLogout;
        [JsonProperty("petConsumables")]
        public IDictionary<string, int> PetConsumables;
        [JsonProperty("outfit")]
        public IDictionary<string, string> VanityOutfit;
        [JsonProperty("karma")]
        public long Karma;
        [JsonProperty("mostRecentGameType")]
        public string LastGamePlayed;

        /// <summary>
        /// Contains data not included in class
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, JToken>? ExtensionData;
    }

    #region PlayerStats
    /// <summary>
    /// Class used for storing all stats in gamemodes of player
    /// </summary>
    public sealed class PlayerStats
    {
#nullable enable
        public SkyWars? SkyWars;
        public VampireZ? VampireZ;
        public Arcade? Arcade;
        public BedWars? BedWars;
        public PlayerDataSkyBlock? SkyBlock;
        public MurderMystery? MurderMystery;
        public Pit? Pit;
        public UHC? UHC;

        /// <summary>
        /// Contains data not included in class
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, JToken>? ExtensionData;
#nullable disable
    }
    #endregion PlayerStats

    #region Gamemodes

    #region SW
    /// <summary>
    /// Stores data of SkyWars Gamemode stats
    /// </summary>
    public sealed class SkyWars
    {
        [JsonProperty("packages")]
        public string[] Packages;
        [JsonProperty("levelFormatted")]
        public string LevelFormatted;
        [JsonProperty("souls")]
        public ulong Souls;
        [JsonProperty("games_played_skywars")]
        public long GamesPlayed;
        [JsonProperty("blocks_placed")]
        public long BlocksPlaced;
        [JsonProperty("chests_opened")]
        public long ChestsOpened;
        [JsonProperty("coins")]
        public long Coins;
        [JsonProperty("deaths")]
        public long Deaths;
        [JsonProperty("eggs_thrown")]
        public long EggsThrown;
        [JsonProperty("lastMode")]
        [JsonConverter(typeof(StringEnumConverter))]
        public SkyWarsMode LastPlayedMode;
        [JsonProperty("losses")]
        public long Loses;
        [JsonProperty("quits")]
        public long Quits;
        [JsonProperty("time_played")]
        public ulong TimePlayed;
        [JsonProperty("win_streak")]
        public long WinStreak;
        [JsonProperty("assists")]
        public long Assists;
        [JsonProperty("blocks_broken")]
        public ulong BlocksBroken;
        [JsonProperty("kills")]
        public ulong Kills;
        [JsonProperty("soul_well")]
        public ulong SoulWell;
        [JsonProperty("heads")]
        public ulong Heads;
        [JsonProperty("head_collections")]
        public Heads HeadCollection;
        [JsonProperty("challenge_attempts")]
        public int ChallengeAttempts;
        [JsonProperty("wins")]
        public int Wins;
        [JsonProperty("SkyWars_openedChests")]
        public ulong OpenedChests;
        [JsonProperty("skywars_chest_history")]
        public string[] ChestHistory;

        /// <summary>
        /// Contains all the data that was not put into this object.
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, JToken> ExtensionData;

        public string LevelUnformatted { get; set; }
        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            LevelUnformatted = LevelFormatted.Remove(0, 2).Replace("☆", "");
        }
    }
    /// <summary>
    /// Type of played skywars mode
    /// </summary>
    public enum SkyWarsMode
    {
        SOLO,
        TEAMS,
        RANKED,
        INSANE,
        LABORATORY
    }
    /// <summary>
    /// Reaction of sacrificing a head
    /// </summary>
    public enum SacrificeReaction
    {
        DECENT,
        TASTY,
        EWW,
        SALTY,
        YUCKY,
        MEH,
        SUCCULENT
    }

    /// <summary>
    /// Data of collected head
    /// </summary>
    public sealed class HeadData
    {
        [JsonProperty("uuid")]
        public string UUID;
        [JsonProperty("timestamp")]
        public ulong TimeStamp;
        [JsonProperty("mode")]
        public string SkywarsMode;
        [JsonProperty("sacrifice")]
        [JsonConverter(typeof(StringEnumConverter))]
        public SacrificeReaction SacrificeReaction;
    }

    public sealed class Heads
    {
#nullable enable
        [JsonProperty("recent")]
        public HeadData[]? Recent;

        [JsonProperty("prestigious")]
        public HeadData[]? Prestigious;
#nullable disable
    }

    #endregion SW

    #region VampireZ
    /// <summary>
    /// Class used to store data of VampireZ GameMode
    /// </summary>
    public sealed class VampireZ
    {
        [JsonProperty("coins")]
        public ulong Coins;
        [JsonProperty("human_deaths")]
        public int DeathsHuman;
        [JsonProperty("vampire_deaths")]
        public int DeathsVampire;
        [JsonProperty("vampire_kills")]
        public int KillsVampire;
    }
    #endregion VampireZ

    #region Arcade
    /// <summary>
    /// Class used for storing data of Arcade Gamemodes
    /// </summary>
    public sealed class Arcade
    {
        [JsonProperty("coins")]
        public long Coins;

        [JsonProperty("lastTourneyAd")]
        public ulong LastTourneyAd;

        /// <summary>
        /// All the data not included in class
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, JToken> ExtensionData;
    }
    #endregion Arcade

    #region BW
    /// <summary>
    /// Class used for storing data of BedWars gamemode
    /// </summary>
    public sealed class BedWars
    {
        public long Experience;
        [JsonProperty("bedwars_boxes")]
        public int Boxes;
        [JsonProperty("coins")]
        public ulong Coins;
        [JsonProperty("beds_lost_bedwars")]
        public uint BedsLost;
        [JsonProperty("beds_broken_bedwars")]
        public uint BedsBroken;
        [JsonProperty("deaths_bedwars")]
        public uint Deaths;
        [JsonProperty("kills_bedwars")]
        public uint Kills;
        [JsonProperty("final_deaths_bedwars")]
        public uint FinalDeaths;
        [JsonProperty("final_kills_bedwars")]
        public uint FinalKills;
        [JsonProperty("games_played_bedwars")]
        public ulong GamesPlayed;
        [JsonProperty("losses_bedwars")]
        public uint Loses;
        [JsonProperty("wins_bedwars")]
        public uint Wins;
        [JsonProperty("packages")]
        public string[] Packages;
        [JsonProperty("Bedwars_openedChests")]
        public uint OpenedChests;
        [JsonProperty("chest_history_new")]
        public string[] ChestHistory;
        [JsonProperty("winstreak")]
        public int Streak;

        public string[] Favorites { get; set; }

        /// <summary>
        /// Contains all the data that was not included in the class
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, JToken> ExtensionData;

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            string favorites = (string)ExtensionData["favourites_2"];
            Favorites = favorites.Split(",");
        }
    }
    #endregion BW

    #region SkyBlock
    /// <summary>
    /// Contains player related data of skyblock gamemode
    /// </summary>
    public sealed class PlayerDataSkyBlock
    {
        [JsonProperty("profiles")]
        public IDictionary<string, SkyBlockProfile> Profiles;
    }

    public sealed class SkyBlockProfile
    {
        [JsonProperty("profile_id")]
        public string ID;
        [JsonProperty("cute_name")]
        public string Fruit;
    }
    #endregion SkyBlock

    #region MurderMystery

    public sealed class MurderMystery
    {
        [JsonProperty("mm_chests")]
        public uint Chests;
        [JsonProperty("detective_chance")]
        public int DetectiveChance;
        [JsonProperty("murderer_chance")]
        public int MurdererChance;
        [JsonProperty("coins")]
        public ulong Coins;
        [JsonProperty("games")]
        public uint GamesPlayed;
        [JsonProperty("wins")]
        public uint Wins;
        [JsonProperty("kills")]
        public long Kills;
        [JsonProperty("was_hero")]
        public int TimesHero;
        [JsonProperty("packages")]
        public string[] Packages;
        [JsonProperty("MurderMystery_openedChests")]
        public long OpenedChests;
        [JsonProperty("chest_history_new")]
        public string[] ChestHistory;

        /// <summary>
        /// Contains all the data noto included into class
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, JToken> ExtensionData;
    }

    #endregion

    #region Pit

    /// <summary>
    /// Contains data of pit gamemode
    /// </summary>
    public sealed class Pit
    {
#nullable enable
        [JsonProperty("profile")]
        public PitProfile? Profile;
        [JsonProperty("pit_stats_ptl")]
        public PrototypePitProfile? PrototypeProfile;
#nullable disable
    }
    /// <summary>
    /// Contains data of pit profile
    /// </summary>
    public sealed class PitProfile
    {
        [JsonProperty("outgoing_offers")]
        public object[] OutgoingOffers;
        [JsonProperty("last_save")]
        public ulong LastSave;
        [JsonProperty("king_quest")]
        public IDictionary<string, long> KingQuest;
        [JsonProperty("spire_stash_inv")]
        public PitContainer SpireStashInventory;
        [JsonProperty("inv_enderchest")]
        public PitContainer EnderChest;
        [JsonProperty("death_recaps")]
        public PitContainer DeathRecaps;
        [JsonProperty("spire_stash_armor")]
        public PitContainer SpireStashArmor;
        [JsonProperty("cash")]
        public float Cash;
        [JsonProperty("leaderboard_stats")]
        public IDictionary<string, int> Leaderboard;
        [JsonProperty("inv_armor")]
        public PitContainer ArmorInventory;
        [JsonProperty("item_stash")]
        public PitContainer ItemStash;
        [JsonProperty("hotbar_favorites")]
        public int[] HotbarFavorites;
        [JsonProperty("inv_contents")]
        public PitContainer Inventory;
        [JsonProperty("unlocks")]
        public PitUnlock[] Unlocks;

        /// <summary>
        /// Contains data not included in class
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, JToken> ExtensionData;
    }

    /// <summary>
    /// Contains data of pit profile, while it was in prototype
    /// </summary>
    public sealed class PrototypePitProfile
    {
        [JsonProperty("arrow_hits")]
        public uint ArrowHits;
        [JsonProperty("arrows_fired")]
        public uint ArrowsFired;
        [JsonProperty("joins")]
        public uint Connects;
        [JsonProperty("left_clicks")]
        public uint LeftClicks;
        [JsonProperty("deaths")]
        public uint Deaths;
        [JsonProperty("kills")]
        public uint Kills;
        [JsonProperty("jumped_into_pit")]
        public uint JumpedIntoPit;

        /// <summary>
        /// Contains data not included in class
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, JToken> ExtensionData;
    }

    /// <summary>
    /// Contains data of Pit Inventory
    /// </summary>
    public sealed class PitContainer
    {
        [JsonProperty("type")]
        public int Type;
        [JsonProperty("data")]
        public int[] Data;
    }
    /// <summary>
    /// Contains data of pit unlock
    /// </summary>
    public sealed class PitUnlock
    {
        [JsonProperty("tier")]
        public int Tier;
        [JsonProperty("acquireDate")]
        public ulong AcquireDate;
        [JsonProperty("key")]
        public string Key;
    }
    #endregion Pit

    #region UHC
    /// <summary>
    /// Contains data for gamemode UltraHardcore
    /// </summary>
    public sealed class UHC
    {
        [JsonProperty("coins")]
        public ulong Coins;
        [JsonProperty("deaths")]
        public ulong Deaths;
        [JsonProperty("packages")]
        public string[] Packages;

        /// <summary>
        /// Contains data not included in class
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, JToken> ExtensionData;
    }

    #endregion UHC



    #endregion Gamemodes
}
