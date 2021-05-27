using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Sharpixel.API.Requests;

namespace Sharpixel.API.Elements
{
    /// <summary>
    ///     Class used for storing data from request to <a href="https://api.hypixel.net/player">Player API</a>
    /// </summary>
    public sealed class Player : RequestElement
    {
        /// <summary>
        ///     Where the player data is stored. Is <i>nullable</i>
        /// </summary>
#nullable enable
        [JsonProperty("player")] public PlayerRequest? PlayerData;
#nullable disable
    }

    /// <summary>
    ///     Class returned from doing request to player API.
    /// </summary>
    public sealed class PlayerRequest
    {
        /// <summary>
        /// Amount of achievment points of player
        /// </summary>
        [JsonProperty("achievementPoints")] public ulong AchievementPoints;

        /// <summary>
        ///     Contains data not included in class
        /// </summary>
        [JsonExtensionData] public IDictionary<string, JToken>? ExtensionData;

        /// <summary>
        ///     Unix Timestamp in milliseconds since when player first logged in
        /// </summary>
        [JsonProperty("firstLogin")] public ulong FirstLogin;

        /// <summary>
        ///     Represents Hypixel ID of player
        /// </summary>
        [JsonProperty("id")] public string ID;

        /// <summary>
        /// Amount of player's karma
        /// </summary>
        [JsonProperty("karma")] public long Karma;

        /// <summary>
        /// Known aliases of player, but lowercased
        /// </summary>
        [JsonProperty("knownAliasesLower")] public string[] KnowAliasesLower;

        /// <summary>
        ///     All known aliases of player, a.k.a. all previous nicknames of player.
        /// </summary>
        [JsonProperty("knownAliases")] public string[] KnownAliases;

        /// <summary>
        /// Last gamemode, that was played
        /// </summary>
        [JsonProperty("mostRecentGameType")] public string LastGamePlayed;

        /// <summary>
        ///     Unix Timestamp in milliseconds since when player last logged in
        /// </summary>
        [JsonProperty("lastLogin")] public ulong UnixLastLogin;

        /// <summary>
        /// Unix Timestamp in milliseconds since when player last logged out
        /// </summary>
        [JsonProperty("lastLogout")] public ulong UnixLastLogout;

        /// <summary>
        /// Last login represented by <see cref="DateTime"/>
        /// </summary>
        public DateTime DateLastLogin
        {
            get
            {
                DateTime convert = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                return convert.AddMilliseconds(UnixLastLogin).ToLocalTime();
            }
        }
        
        /// <summary>
        /// Last logout represented by <see cref="DateTime"/>
        /// </summary>
        public DateTime DateLastLogout
        {
            get
            {
                DateTime convert = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                return convert.AddMilliseconds(UnixLastLogout).ToLocalTime();
            }
        }
        
        /// <summary>
        /// Total network experience of player
        /// </summary>
        [JsonProperty("networkExp")] public long NetworkExperience;

        /// <summary>
        /// Onetime achievements player ever obtained
        /// </summary>
        [JsonProperty("achievementsOneTime")] public string[] OneTimeAchievments;

        /// <summary>
        /// Consumables of pets available
        /// </summary>
        [JsonProperty("petConsumables")] public IDictionary<string, int> PetConsumables;

        /// <summary>
        ///     Represents Nickname of player
        /// </summary>
        [JsonProperty("playername")] public string PlayerName;
#nullable enable
        /// <summary>
        /// Represents total stats of player
        /// </summary>
        [JsonProperty("stats")] public PlayerStats? Stats;
#nullable disable
        /// <summary>
        /// Represents tiered achievements of player, and their level
        /// </summary>
        [JsonProperty("achievements")] public IDictionary<string, int> TieredAchievements;

        /// <summary>
        ///     Represents Mojang UUID of player
        /// </summary>
        [JsonProperty("uuid")] public string UUID;

        /// <summary>
        /// Contains current worn vanity outfit
        /// </summary>
        [JsonProperty("outfit")] public IDictionary<string, string> VanityOutfit;
    }

    #region PlayerStats

    /// <summary>
    ///     Class used for storing all stats in gamemodes of player
    /// </summary>
    public sealed class PlayerStats
    {
#nullable enable
        /// <summary>
        /// Contains all data related to skywars gamemode
        /// </summary>
        public SkyWars? SkyWars;
        /// <summary>
        /// Contains all data related to VampireZ gamemode
        /// </summary>
        public VampireZ? VampireZ;
        /// <summary>
        /// Contains all data related to Arcade gamemodes
        /// </summary>
        public Arcade? Arcade;
        /// <summary>
        /// Contains all data related to BedWars gamemode
        /// </summary>
        public Bedwars? BedWars;
        /// <summary>
        /// Contains some data related to Skyblock gamemode
        /// </summary>
        public PlayerDataSkyBlock? SkyBlock;
        /// <summary>
        /// Contains all data related to Murder Mystery gamemode
        /// </summary>
        public MurderMystery? MurderMystery;
        /// <summary>
        /// Contains all data related to Pit gamemode
        /// </summary>
        public Pit? Pit;
        /// <summary>
        /// Contains all data related to Ultra Hardcore gamemode
        /// </summary>
        public UHC? UHC;

        /// <summary>
        ///     Contains data not included in class
        /// </summary>
        [JsonExtensionData] public IDictionary<string, JToken>? ExtensionData;
#nullable disable
    }

    #endregion PlayerStats

    #region Gamemodes

    #region SW

    /// <summary>
    ///     Stores data of SkyWars Gamemode stats
    /// </summary>
    public sealed class SkyWars
    {
        /// <summary>
        /// Kill assists of player
        /// </summary>
        [JsonProperty("assists")] public long Assists;
        /// <summary>
        /// Total blocks broken by player
        /// </summary>
        [JsonProperty("blocks_broken")] public ulong BlocksBroken;
        /// <summary>
        /// Total blocks placed by player
        /// </summary>
        [JsonProperty("blocks_placed")] public long BlocksPlaced;
        /// <summary>
        /// Total attempts at challenges
        /// </summary>
        [JsonProperty("challenge_attempts")] public int ChallengeAttempts;

        /// <summary>
        /// Chest drop history of player
        /// </summary>
        [JsonProperty("skywars_chest_history")] public string[] ChestHistory;

        /// <summary>
        /// Total chests opened
        /// </summary>
        [JsonProperty("chests_opened")] public long ChestsOpened;

        /// <summary>
        /// Coins of player
        /// </summary>
        [JsonProperty("coins")] public long Coins;

        /// <summary>
        /// Deaths of player
        /// </summary>
        [JsonProperty("deaths")] public long Deaths;

        /// <summary>
        /// Total eggs and snowballs thrown by player
        /// </summary>
        [JsonProperty("eggs_thrown")] public long EggsThrown;

        /// <summary>
        ///     Contains all the data that was not put into this object.
        /// </summary>
        [JsonExtensionData] public IDictionary<string, JToken> ExtensionData;

        /// <summary>
        /// Total games played
        /// </summary>
        [JsonProperty("games_played_skywars")] public long GamesPlayed;

        /// <summary>
        /// Contains heads data
        /// </summary>
        [JsonProperty("head_collections")] public Heads HeadCollection;

        /// <summary>
        /// Total heads obtained by player
        /// </summary>
        [JsonProperty("heads")] public ulong Heads;

        /// <summary>
        /// Total kills by player
        /// </summary>
        [JsonProperty("kills")] public ulong Kills;

        /// <summary>
        /// Last played gamemode
        /// </summary>
        [JsonProperty("lastMode")] [JsonConverter(typeof(StringEnumConverter))]
        public SkyWarsMode LastPlayedMode;

        /// <summary>
        /// Formatted version of player's level.
        /// <example>§73⋆</example>
        /// </summary>
        [JsonProperty("levelFormatted")] public string LevelFormatted;

        /// <summary>
        /// Total loses of player
        /// </summary>
        [JsonProperty("losses")] public long Loses;

        /// <summary>
        /// Total chests opened
        /// </summary>
        [JsonProperty("SkyWars_openedChests")] public ulong OpenedChests;

        /// <summary>
        /// Packages owned by player
        /// </summary>
        [JsonProperty("packages")] public string[] Packages;

        /// <summary>
        /// Total times player quit
        /// </summary>
        [JsonProperty("quits")] public long Quits;

        /// <summary>
        /// Total amount of souls player has
        /// </summary>
        [JsonProperty("souls")] public ulong Souls;

        /// <summary>
        /// Total souls spent in soul well
        /// </summary>
        [JsonProperty("soul_well")] public ulong SoulWell;

        /// <summary>
        /// Total times played
        /// </summary>
        [JsonProperty("time_played")] public ulong TimesPlayed;

        /// <summary>
        /// Total amount of wins
        /// </summary>
        [JsonProperty("wins")] public int Wins;
        
        /// <summary>
        /// Current win streak
        /// </summary>
        [JsonProperty("win_streak")] public long WinStreak;

        /// <summary>
        /// Unformatted level, containing just integer
        /// </summary>
        public string LevelUnformatted { get; set; }
        
        
        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            LevelUnformatted = LevelFormatted.Remove(0, 2).Replace("☆", "");
        }
    }

    /// <summary>
    ///     Type of played skywars mode
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
    ///     Reaction of sacrificing a head
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
    ///     Data of collected head
    /// </summary>
    public sealed class HeadData
    {
        [JsonProperty("sacrifice")] [JsonConverter(typeof(StringEnumConverter))]
        public SacrificeReaction SacrificeReaction;

        [JsonProperty("mode")] public string SkywarsMode;

        [JsonProperty("timestamp")] public ulong TimeStamp;

        [JsonProperty("uuid")] public string UUID;
    }

    public sealed class Heads
    {
#nullable enable
        [JsonProperty("recent")] public HeadData[]? Recent;

        [JsonProperty("prestigious")] public HeadData[]? Prestigious;
#nullable disable
    }

    #endregion SW

    #region VampireZ

    /// <summary>
    ///     Class used to store data of VampireZ GameMode
    /// </summary>
    public sealed class VampireZ
    {
        [JsonProperty("coins")] public ulong Coins;

        [JsonProperty("human_deaths")] public int DeathsHuman;

        [JsonProperty("vampire_deaths")] public int DeathsVampire;

        [JsonProperty("vampire_kills")] public int KillsVampire;
    }

    #endregion VampireZ

    #region Arcade

    /// <summary>
    ///     Class used for storing data of Arcade Gamemodes
    /// </summary>
    public sealed class Arcade
    {
        [JsonProperty("coins")] public long Coins;

        /// <summary>
        ///     All the data not included in class
        /// </summary>
        [JsonExtensionData] public IDictionary<string, JToken> ExtensionData;

        [JsonProperty("lastTourneyAd")] public ulong LastTourneyAd;
    }

    #endregion Arcade

    #region BW

    /// <summary>
    ///     Class used for storing data of BedWars gamemode
    /// </summary>
    public sealed class Bedwars
    {
        [JsonProperty("beds_broken_bedwars")] public uint BedsBroken;

        [JsonProperty("beds_lost_bedwars")] public uint BedsLost;

        [JsonProperty("bedwars_boxes")] public int Boxes;

        [JsonProperty("chest_history_new")] public string[] ChestHistory;

        [JsonProperty("coins")] public ulong Coins;

        [JsonProperty("deaths_bedwars")] public uint Deaths;

        public long Experience;

        /// <summary>
        ///     Contains all the data that was not included in the class
        /// </summary>
        [JsonExtensionData] public IDictionary<string, JToken> ExtensionData;

        [JsonProperty("final_deaths_bedwars")] public uint FinalDeaths;

        [JsonProperty("final_kills_bedwars")] public uint FinalKills;

        [JsonProperty("games_played_bedwars")] public ulong GamesPlayed;

        [JsonProperty("kills_bedwars")] public uint Kills;

        [JsonProperty("losses_bedwars")] public uint Loses;

        [JsonProperty("Bedwars_openedChests")] public uint OpenedChests;

        [JsonProperty("packages")] public string[] Packages;

        [JsonProperty("winstreak")] public int Streak;

        [JsonProperty("wins_bedwars")] public uint Wins;

        public string[] Favorites { get; set; }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            var favorites = (string) ExtensionData["favourites_2"];
            Favorites = favorites.Split(",");
        }
    }

    #endregion BW

    #region SkyBlock

    /// <summary>
    ///     Contains player related data of skyblock gamemode
    /// </summary>
    public sealed class PlayerDataSkyBlock
    {
        [JsonProperty("profiles")] public IDictionary<string, SkyBlockProfile> Profiles;
    }

    public sealed class SkyBlockProfile
    {
        [JsonProperty("cute_name")] public string Fruit;

        [JsonProperty("profile_id")] public string ID;
    }

    #endregion SkyBlock

    #region MurderMystery

    public sealed class MurderMystery
    {
        [JsonProperty("chest_history_new")] public string[] ChestHistory;

        [JsonProperty("mm_chests")] public uint Chests;

        [JsonProperty("coins")] public ulong Coins;

        [JsonProperty("detective_chance")] public int DetectiveChance;

        /// <summary>
        ///     Contains all the data noto included into class
        /// </summary>
        [JsonExtensionData] public IDictionary<string, JToken> ExtensionData;

        [JsonProperty("games")] public uint GamesPlayed;

        [JsonProperty("kills")] public long Kills;

        [JsonProperty("murderer_chance")] public int MurdererChance;

        [JsonProperty("MurderMystery_openedChests")]
        public long OpenedChests;

        [JsonProperty("packages")] public string[] Packages;

        [JsonProperty("was_hero")] public int TimesHero;

        [JsonProperty("wins")] public uint Wins;
    }

    #endregion

    #region Pit

    /// <summary>
    ///     Contains data of pit gamemode
    /// </summary>
    public sealed class Pit
    {
#nullable enable
        [JsonProperty("profile")] public PitProfile? Profile;

        [JsonProperty("pit_stats_ptl")] public PrototypePitProfile? PrototypeProfile;
#nullable disable
    }

    /// <summary>
    ///     Contains data of pit profile
    /// </summary>
    public sealed class PitProfile
    {
        [JsonProperty("inv_armor")] public PitContainer ArmorInventory;

        [JsonProperty("cash")] public float Cash;

        [JsonProperty("death_recaps")] public PitContainer DeathRecaps;

        [JsonProperty("inv_enderchest")] public PitContainer EnderChest;

        /// <summary>
        ///     Contains data not included in class
        /// </summary>
        [JsonExtensionData] public IDictionary<string, JToken> ExtensionData;

        [JsonProperty("hotbar_favorites")] public int[] HotbarFavorites;

        [JsonProperty("inv_contents")] public PitContainer Inventory;

        [JsonProperty("item_stash")] public PitContainer ItemStash;

        [JsonProperty("king_quest")] public IDictionary<string, long> KingQuest;

        [JsonProperty("last_save")] public ulong LastSave;

        [JsonProperty("leaderboard_stats")] public IDictionary<string, int> Leaderboard;

        [JsonProperty("outgoing_offers")] public object[] OutgoingOffers;

        [JsonProperty("spire_stash_armor")] public PitContainer SpireStashArmor;

        [JsonProperty("spire_stash_inv")] public PitContainer SpireStashInventory;

        [JsonProperty("unlocks")] public PitUnlock[] Unlocks;
    }

    /// <summary>
    ///     Contains data of pit profile, while it was in prototype
    /// </summary>
    public sealed class PrototypePitProfile
    {
        [JsonProperty("arrow_hits")] public uint ArrowHits;

        [JsonProperty("arrows_fired")] public uint ArrowsFired;

        [JsonProperty("joins")] public uint Connects;

        [JsonProperty("deaths")] public uint Deaths;

        /// <summary>
        ///     Contains data not included in class
        /// </summary>
        [JsonExtensionData] public IDictionary<string, JToken> ExtensionData;

        [JsonProperty("jumped_into_pit")] public uint JumpedIntoPit;

        [JsonProperty("kills")] public uint Kills;

        [JsonProperty("left_clicks")] public uint LeftClicks;
    }

    /// <summary>
    ///     Contains data of Pit Inventory
    /// </summary>
    public sealed class PitContainer
    {
        [JsonProperty("data")] public int[] Data;

        [JsonProperty("type")] public int Type;
    }

    /// <summary>
    ///     Contains data of pit unlock
    /// </summary>
    public sealed class PitUnlock
    {
        [JsonProperty("acquireDate")] public ulong AcquireDate;

        [JsonProperty("key")] public string Key;

        [JsonProperty("tier")] public int Tier;
    }

    #endregion Pit

    #region UHC

    /// <summary>
    ///     Contains data for gamemode UltraHardcore
    /// </summary>
    public sealed class UHC
    {
        [JsonProperty("coins")] public ulong Coins;

        [JsonProperty("deaths")] public ulong Deaths;

        /// <summary>
        ///     Contains data not included in class
        /// </summary>
        [JsonExtensionData] public IDictionary<string, JToken> ExtensionData;

        [JsonProperty("packages")] public string[] Packages;
    }

    #endregion UHC

    #endregion Gamemodes
}