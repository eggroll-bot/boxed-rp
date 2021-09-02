﻿using System;
using System.Text.Json.Serialization;

namespace ChetoRp.Employment
{
	/// <summary>
	/// The class used to build teams.
	/// </summary>
	[GameConfigObject]
	public class TeamConfig
	{
		/// <summary>
		/// The category of the team.
		/// </summary>
		[GameConfigOptionInfo( "TeamConfigCategory" )]
		public string Category { get; set; } = "Uncategorized";

		/// <summary>
		/// The pretty name of the team.
		/// </summary>
		[GameConfigOptionInfo( "TeamConfigPrettyName" )]
		public string PrettyName { get; set; } = "";

		/// <summary>
		/// The description of the team.
		/// </summary>
		[GameConfigOptionInfo( "TeamConfigDescription" )]
		public string Description { get; set; } = "";

		/// <summary>
		/// The possible models of the players in the team.
		/// </summary>
		[GameConfigOptionInfo( "TeamConfigModels" )]
		public string[] Models { get; set; } = Array.Empty<string>();

		/// <summary>
		/// The weapons given to players in the team on spawn.
		/// </summary>
		[GameConfigOptionInfo( "TeamConfigWeapons" )]
		public string[] Weapons { get; set; } = Array.Empty<string>();

		/// <summary>
		/// Whether the default weapons should be given to this team.
		/// </summary>
		[GameConfigOptionInfo( "TeamConfigShouldGetDefaultWeapons" )]
		public bool ShouldGetDefaultWeapons { get; set; } = true;

		/// <summary>
		/// The max number of players that can be in this team at a time. 0 = unlimited players.
		/// </summary>
		[GameConfigOptionInfo( "TeamConfigMaxPlayers" )]
		public uint MaxPlayers { get; set; } = 0;

		/// <summary>
		/// The salary given to the player every pay period.
		/// </summary>
		[GameConfigOptionInfo( "TeamConfigSalary" )]
		public ulong Salary { get; set; } = 100;

		/// <summary>
		/// Whether a player needs to be voted into the team.
		/// </summary>
		[GameConfigOptionInfo( "TeamConfigIsVoteRequired" )]
		public bool IsVoteRequired { get; set; } = false;

		/// <summary>
		/// Whether players in the team can be demoted out of the team.
		/// </summary>
		[GameConfigOptionInfo( "TeamConfigCanBeDemoted" )]
		public bool CanBeDemoted { get; set; } = true;

		/// <summary>
		/// Whether this team should be the default team given when a player joins. The first default team in the configuration file will be the default team.
		/// </summary>
		[GameConfigOptionInfo( "TeamConfigIsDefault" )]
		public bool IsDefault { get; set; } = false;

		/// <summary>
		/// Whether this team is a special team.
		/// </summary>
		[GameConfigOptionInfo( "TeamConfigIsSpecialTeam" )]
		[JsonConverter( typeof( JsonStringEnumConverter ) )]
		public SpecialTeam IsSpecialTeam { get; set; } = SpecialTeam.None;

		/// <summary>
		/// Converts the <see cref="TeamConfig"/> to a <see cref="Team"/>.
		/// </summary>
		/// <returns>The converted <see cref="Team"/>.</returns>
		internal Team ToTeam()
		{
			return new Team( this );
		}
	}
}
