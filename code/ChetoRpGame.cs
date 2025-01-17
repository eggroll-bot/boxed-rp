﻿using ChetoRp.Localization;

using Sandbox;
using Sandbox.UI;

namespace ChetoRp
{
	/// <summary>
	/// The main game class.
	/// </summary>
	internal partial class ChetoRpGame : SandboxGame
	{
		/// <summary>
		/// Called on game load.
		/// </summary>
		public ChetoRpGame() : base()
		{
			Event.Run( GameEvents.PreGameInit );
			Modules.Start();
			Log.Info( LocalizationModule.Locale.BaseFinishedLoading );
		}

		/// <summary>
		/// Called when a client joins.
		/// </summary>
		public override void ClientJoined( Client client )
		{
			string joinedMessage = LocalizationModule.Locale.BaseClientJoined.Format( client.Name );
			Log.Info( joinedMessage );
			ChatBox.AddInformation( To.Everyone, joinedMessage, $"avatar:{client.SteamId}" );
			GamePlayer player = new( client );
			client.Pawn = player;
			player.Respawn();
		}

		/// <summary>
		/// Overwrites noclip.
		/// </summary>
		public override void DoPlayerNoclip( Client player )
		{
		}

		/// <summary>
		/// Called on game shutdown.
		/// </summary>
		public override void Shutdown()
		{
			Event.Run( GameEvents.OnGameShutdown );
			base.Shutdown();
		}
	}
}
