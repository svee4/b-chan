using System.Diagnostics.CodeAnalysis;

namespace BChan.Bot.Infra.DiscordEvents;

[SuppressMessage("Style", "IDE0040:Add accessibility modifiers", Justification = "Partial")]
partial class EventPublisher
{
	private void AddEventHandlers()
	{
		_socketClient.Connected += PublishConnected;
		_socketClient.Disconnected += PublishDisconnected;
		_socketClient.Ready += PublishReady;
		_socketClient.LatencyUpdated += PublishLatencyUpdated;
		_socketClient.ChannelCreated += PublishChannelCreated;
		_socketClient.ChannelDestroyed += PublishChannelDestroyed;
		_socketClient.ChannelUpdated += PublishChannelUpdated;
		_socketClient.VoiceChannelStatusUpdated += PublishVoiceChannelStatusUpdated;
		_socketClient.MessageReceived += PublishMessageReceived;
		_socketClient.MessageDeleted += PublishMessageDeleted;
		_socketClient.MessagesBulkDeleted += PublishMessagesBulkDeleted;
		_socketClient.MessageUpdated += PublishMessageUpdated;
		_socketClient.ReactionAdded += PublishReactionAdded;
		_socketClient.ReactionRemoved += PublishReactionRemoved;
		_socketClient.ReactionsCleared += PublishReactionsCleared;
		_socketClient.ReactionsRemovedForEmote += PublishReactionsRemovedForEmote;
		_socketClient.PollVoteAdded += PublishPollVoteAdded;
		_socketClient.PollVoteRemoved += PublishPollVoteRemoved;
		_socketClient.RoleCreated += PublishRoleCreated;
		_socketClient.RoleDeleted += PublishRoleDeleted;
		_socketClient.RoleUpdated += PublishRoleUpdated;
		_socketClient.JoinedGuild += PublishJoinedGuild;
		_socketClient.LeftGuild += PublishLeftGuild;
		_socketClient.GuildAvailable += PublishGuildAvailable;
		_socketClient.GuildUnavailable += PublishGuildUnavailable;
		_socketClient.GuildMembersDownloaded += PublishGuildMembersDownloaded;
		_socketClient.GuildUpdated += PublishGuildUpdated;
		_socketClient.GuildJoinRequestDeleted += PublishGuildJoinRequestDeleted;
		_socketClient.GuildScheduledEventCreated += PublishGuildScheduledEventCreated;
		_socketClient.GuildScheduledEventUpdated += PublishGuildScheduledEventUpdated;
		_socketClient.GuildScheduledEventCancelled += PublishGuildScheduledEventCancelled;
		_socketClient.GuildScheduledEventCompleted += PublishGuildScheduledEventCompleted;
		_socketClient.GuildScheduledEventStarted += PublishGuildScheduledEventStarted;
		_socketClient.GuildScheduledEventUserAdd += PublishGuildScheduledEventUserAdd;
		_socketClient.GuildScheduledEventUserRemove += PublishGuildScheduledEventUserRemove;
		_socketClient.IntegrationCreated += PublishIntegrationCreated;
		_socketClient.IntegrationUpdated += PublishIntegrationUpdated;
		_socketClient.IntegrationDeleted += PublishIntegrationDeleted;
		_socketClient.UserJoined += PublishUserJoined;
		_socketClient.UserLeft += PublishUserLeft;
		_socketClient.UserBanned += PublishUserBanned;
		_socketClient.UserUnbanned += PublishUserUnbanned;
		_socketClient.UserUpdated += PublishUserUpdated;
		_socketClient.GuildMemberUpdated += PublishGuildMemberUpdated;
		_socketClient.UserVoiceStateUpdated += PublishUserVoiceStateUpdated;
		_socketClient.VoiceServerUpdated += PublishVoiceServerUpdated;
		_socketClient.CurrentUserUpdated += PublishCurrentUserUpdated;
		_socketClient.UserIsTyping += PublishUserIsTyping;
		_socketClient.RecipientAdded += PublishRecipientAdded;
		_socketClient.RecipientRemoved += PublishRecipientRemoved;
		_socketClient.PresenceUpdated += PublishPresenceUpdated;
		_socketClient.InviteCreated += PublishInviteCreated;
		_socketClient.InviteDeleted += PublishInviteDeleted;
		_socketClient.InteractionCreated += PublishInteractionCreated;
		_socketClient.ButtonExecuted += PublishButtonExecuted;
		_socketClient.SelectMenuExecuted += PublishSelectMenuExecuted;
		_socketClient.SlashCommandExecuted += PublishSlashCommandExecuted;
		_socketClient.UserCommandExecuted += PublishUserCommandExecuted;
		_socketClient.MessageCommandExecuted += PublishMessageCommandExecuted;
		_socketClient.AutocompleteExecuted += PublishAutocompleteExecuted;
		_socketClient.ModalSubmitted += PublishModalSubmitted;
		_socketClient.ApplicationCommandCreated += PublishApplicationCommandCreated;
		_socketClient.ApplicationCommandUpdated += PublishApplicationCommandUpdated;
		_socketClient.ApplicationCommandDeleted += PublishApplicationCommandDeleted;
		_socketClient.ThreadCreated += PublishThreadCreated;
		_socketClient.ThreadUpdated += PublishThreadUpdated;
		_socketClient.ThreadDeleted += PublishThreadDeleted;
		_socketClient.ThreadMemberJoined += PublishThreadMemberJoined;
		_socketClient.ThreadMemberLeft += PublishThreadMemberLeft;
		_socketClient.StageStarted += PublishStageStarted;
		_socketClient.StageEnded += PublishStageEnded;
		_socketClient.StageUpdated += PublishStageUpdated;
		_socketClient.RequestToSpeak += PublishRequestToSpeak;
		_socketClient.SpeakerAdded += PublishSpeakerAdded;
		_socketClient.SpeakerRemoved += PublishSpeakerRemoved;
		_socketClient.GuildStickerCreated += PublishGuildStickerCreated;
		_socketClient.GuildStickerUpdated += PublishGuildStickerUpdated;
		_socketClient.GuildStickerDeleted += PublishGuildStickerDeleted;
		_socketClient.WebhooksUpdated += PublishWebhooksUpdated;
		_socketClient.AuditLogCreated += PublishAuditLogCreated;
		_socketClient.AutoModRuleCreated += PublishAutoModRuleCreated;
		_socketClient.AutoModRuleUpdated += PublishAutoModRuleUpdated;
		_socketClient.AutoModRuleDeleted += PublishAutoModRuleDeleted;
		_socketClient.AutoModActionExecuted += PublishAutoModActionExecuted;
		_socketClient.EntitlementCreated += PublishEntitlementCreated;
		_socketClient.EntitlementUpdated += PublishEntitlementUpdated;
		_socketClient.EntitlementDeleted += PublishEntitlementDeleted;
		_socketClient.SubscriptionCreated += PublishSubscriptionCreated;
		_socketClient.SubscriptionUpdated += PublishSubscriptionUpdated;
		_socketClient.SubscriptionDeleted += PublishSubscriptionDeleted;
		_socketClient.Log += PublishLog;
		_socketClient.LoggedIn += PublishLoggedIn;
		_socketClient.LoggedOut += PublishLoggedOut;
		_socketClient.SentRequest += PublishSentRequest;
	}

	private void RemoveEventHandlers()
	{
		_socketClient.Connected -= PublishConnected;
		_socketClient.Disconnected -= PublishDisconnected;
		_socketClient.Ready -= PublishReady;
		_socketClient.LatencyUpdated -= PublishLatencyUpdated;
		_socketClient.ChannelCreated -= PublishChannelCreated;
		_socketClient.ChannelDestroyed -= PublishChannelDestroyed;
		_socketClient.ChannelUpdated -= PublishChannelUpdated;
		_socketClient.VoiceChannelStatusUpdated -= PublishVoiceChannelStatusUpdated;
		_socketClient.MessageReceived -= PublishMessageReceived;
		_socketClient.MessageDeleted -= PublishMessageDeleted;
		_socketClient.MessagesBulkDeleted -= PublishMessagesBulkDeleted;
		_socketClient.MessageUpdated -= PublishMessageUpdated;
		_socketClient.ReactionAdded -= PublishReactionAdded;
		_socketClient.ReactionRemoved -= PublishReactionRemoved;
		_socketClient.ReactionsCleared -= PublishReactionsCleared;
		_socketClient.ReactionsRemovedForEmote -= PublishReactionsRemovedForEmote;
		_socketClient.PollVoteAdded -= PublishPollVoteAdded;
		_socketClient.PollVoteRemoved -= PublishPollVoteRemoved;
		_socketClient.RoleCreated -= PublishRoleCreated;
		_socketClient.RoleDeleted -= PublishRoleDeleted;
		_socketClient.RoleUpdated -= PublishRoleUpdated;
		_socketClient.JoinedGuild -= PublishJoinedGuild;
		_socketClient.LeftGuild -= PublishLeftGuild;
		_socketClient.GuildAvailable -= PublishGuildAvailable;
		_socketClient.GuildUnavailable -= PublishGuildUnavailable;
		_socketClient.GuildMembersDownloaded -= PublishGuildMembersDownloaded;
		_socketClient.GuildUpdated -= PublishGuildUpdated;
		_socketClient.GuildJoinRequestDeleted -= PublishGuildJoinRequestDeleted;
		_socketClient.GuildScheduledEventCreated -= PublishGuildScheduledEventCreated;
		_socketClient.GuildScheduledEventUpdated -= PublishGuildScheduledEventUpdated;
		_socketClient.GuildScheduledEventCancelled -= PublishGuildScheduledEventCancelled;
		_socketClient.GuildScheduledEventCompleted -= PublishGuildScheduledEventCompleted;
		_socketClient.GuildScheduledEventStarted -= PublishGuildScheduledEventStarted;
		_socketClient.GuildScheduledEventUserAdd -= PublishGuildScheduledEventUserAdd;
		_socketClient.GuildScheduledEventUserRemove -= PublishGuildScheduledEventUserRemove;
		_socketClient.IntegrationCreated -= PublishIntegrationCreated;
		_socketClient.IntegrationUpdated -= PublishIntegrationUpdated;
		_socketClient.IntegrationDeleted -= PublishIntegrationDeleted;
		_socketClient.UserJoined -= PublishUserJoined;
		_socketClient.UserLeft -= PublishUserLeft;
		_socketClient.UserBanned -= PublishUserBanned;
		_socketClient.UserUnbanned -= PublishUserUnbanned;
		_socketClient.UserUpdated -= PublishUserUpdated;
		_socketClient.GuildMemberUpdated -= PublishGuildMemberUpdated;
		_socketClient.UserVoiceStateUpdated -= PublishUserVoiceStateUpdated;
		_socketClient.VoiceServerUpdated -= PublishVoiceServerUpdated;
		_socketClient.CurrentUserUpdated -= PublishCurrentUserUpdated;
		_socketClient.UserIsTyping -= PublishUserIsTyping;
		_socketClient.RecipientAdded -= PublishRecipientAdded;
		_socketClient.RecipientRemoved -= PublishRecipientRemoved;
		_socketClient.PresenceUpdated -= PublishPresenceUpdated;
		_socketClient.InviteCreated -= PublishInviteCreated;
		_socketClient.InviteDeleted -= PublishInviteDeleted;
		_socketClient.InteractionCreated -= PublishInteractionCreated;
		_socketClient.ButtonExecuted -= PublishButtonExecuted;
		_socketClient.SelectMenuExecuted -= PublishSelectMenuExecuted;
		_socketClient.SlashCommandExecuted -= PublishSlashCommandExecuted;
		_socketClient.UserCommandExecuted -= PublishUserCommandExecuted;
		_socketClient.MessageCommandExecuted -= PublishMessageCommandExecuted;
		_socketClient.AutocompleteExecuted -= PublishAutocompleteExecuted;
		_socketClient.ModalSubmitted -= PublishModalSubmitted;
		_socketClient.ApplicationCommandCreated -= PublishApplicationCommandCreated;
		_socketClient.ApplicationCommandUpdated -= PublishApplicationCommandUpdated;
		_socketClient.ApplicationCommandDeleted -= PublishApplicationCommandDeleted;
		_socketClient.ThreadCreated -= PublishThreadCreated;
		_socketClient.ThreadUpdated -= PublishThreadUpdated;
		_socketClient.ThreadDeleted -= PublishThreadDeleted;
		_socketClient.ThreadMemberJoined -= PublishThreadMemberJoined;
		_socketClient.ThreadMemberLeft -= PublishThreadMemberLeft;
		_socketClient.StageStarted -= PublishStageStarted;
		_socketClient.StageEnded -= PublishStageEnded;
		_socketClient.StageUpdated -= PublishStageUpdated;
		_socketClient.RequestToSpeak -= PublishRequestToSpeak;
		_socketClient.SpeakerAdded -= PublishSpeakerAdded;
		_socketClient.SpeakerRemoved -= PublishSpeakerRemoved;
		_socketClient.GuildStickerCreated -= PublishGuildStickerCreated;
		_socketClient.GuildStickerUpdated -= PublishGuildStickerUpdated;
		_socketClient.GuildStickerDeleted -= PublishGuildStickerDeleted;
		_socketClient.WebhooksUpdated -= PublishWebhooksUpdated;
		_socketClient.AuditLogCreated -= PublishAuditLogCreated;
		_socketClient.AutoModRuleCreated -= PublishAutoModRuleCreated;
		_socketClient.AutoModRuleUpdated -= PublishAutoModRuleUpdated;
		_socketClient.AutoModRuleDeleted -= PublishAutoModRuleDeleted;
		_socketClient.AutoModActionExecuted -= PublishAutoModActionExecuted;
		_socketClient.EntitlementCreated -= PublishEntitlementCreated;
		_socketClient.EntitlementUpdated -= PublishEntitlementUpdated;
		_socketClient.EntitlementDeleted -= PublishEntitlementDeleted;
		_socketClient.SubscriptionCreated -= PublishSubscriptionCreated;
		_socketClient.SubscriptionUpdated -= PublishSubscriptionUpdated;
		_socketClient.SubscriptionDeleted -= PublishSubscriptionDeleted;
		_socketClient.Log -= PublishLog;
		_socketClient.LoggedIn -= PublishLoggedIn;
		_socketClient.LoggedOut -= PublishLoggedOut;
		_socketClient.SentRequest -= PublishSentRequest;

	}

	#region Publish methods
	private Task PublishConnected() =>
		PublishEvent(new ConnectedEvent());
	private Task PublishDisconnected(System.Exception arg0) =>
		PublishEvent(new DisconnectedEvent(arg0));
	private Task PublishReady() =>
		PublishEvent(new ReadyEvent());
	private Task PublishLatencyUpdated(System.Int32 arg0, System.Int32 arg1) =>
		PublishEvent(new LatencyUpdatedEvent(arg0, arg1));
	private Task PublishChannelCreated(Discord.WebSocket.SocketChannel arg0) =>
		PublishEvent(new ChannelCreatedEvent(arg0));
	private Task PublishChannelDestroyed(Discord.WebSocket.SocketChannel arg0) =>
		PublishEvent(new ChannelDestroyedEvent(arg0));
	private Task PublishChannelUpdated(Discord.WebSocket.SocketChannel arg0, Discord.WebSocket.SocketChannel arg1) =>
		PublishEvent(new ChannelUpdatedEvent(arg0, arg1));
	private Task PublishVoiceChannelStatusUpdated(Discord.Cacheable<Discord.WebSocket.SocketVoiceChannel, System.UInt64> arg0, System.String arg1, System.String arg2) =>
		PublishEvent(new VoiceChannelStatusUpdatedEvent(arg0, arg1, arg2));
	private Task PublishMessageReceived(Discord.WebSocket.SocketMessage arg0) =>
		PublishEvent(new MessageReceivedEvent(arg0));
	private Task PublishMessageDeleted(Discord.Cacheable<Discord.IMessage, System.UInt64> arg0, Discord.Cacheable<Discord.IMessageChannel, System.UInt64> arg1) =>
		PublishEvent(new MessageDeletedEvent(arg0, arg1));
	private Task PublishMessagesBulkDeleted(System.Collections.Generic.IReadOnlyCollection<Discord.Cacheable<Discord.IMessage, System.UInt64>> arg0, Discord.Cacheable<Discord.IMessageChannel, System.UInt64> arg1) =>
		PublishEvent(new MessagesBulkDeletedEvent(arg0, arg1));
	private Task PublishMessageUpdated(Discord.Cacheable<Discord.IMessage, System.UInt64> arg0, Discord.WebSocket.SocketMessage arg1, Discord.WebSocket.ISocketMessageChannel arg2) =>
		PublishEvent(new MessageUpdatedEvent(arg0, arg1, arg2));
	private Task PublishReactionAdded(Discord.Cacheable<Discord.IUserMessage, System.UInt64> arg0, Discord.Cacheable<Discord.IMessageChannel, System.UInt64> arg1, Discord.WebSocket.SocketReaction arg2) =>
		PublishEvent(new ReactionAddedEvent(arg0, arg1, arg2));
	private Task PublishReactionRemoved(Discord.Cacheable<Discord.IUserMessage, System.UInt64> arg0, Discord.Cacheable<Discord.IMessageChannel, System.UInt64> arg1, Discord.WebSocket.SocketReaction arg2) =>
		PublishEvent(new ReactionRemovedEvent(arg0, arg1, arg2));
	private Task PublishReactionsCleared(Discord.Cacheable<Discord.IUserMessage, System.UInt64> arg0, Discord.Cacheable<Discord.IMessageChannel, System.UInt64> arg1) =>
		PublishEvent(new ReactionsClearedEvent(arg0, arg1));
	private Task PublishReactionsRemovedForEmote(Discord.Cacheable<Discord.IUserMessage, System.UInt64> arg0, Discord.Cacheable<Discord.IMessageChannel, System.UInt64> arg1, Discord.IEmote arg2) =>
		PublishEvent(new ReactionsRemovedForEmoteEvent(arg0, arg1, arg2));
	private Task PublishPollVoteAdded(Discord.Cacheable<Discord.IUser, System.UInt64> arg0, Discord.Cacheable<Discord.WebSocket.ISocketMessageChannel, Discord.Rest.IRestMessageChannel, Discord.IMessageChannel, System.UInt64> arg1, Discord.Cacheable<Discord.IUserMessage, System.UInt64> arg2, System.Nullable<Discord.Cacheable<Discord.WebSocket.SocketGuild, Discord.Rest.RestGuild, Discord.IGuild, System.UInt64>> arg3, System.UInt64 arg4) =>
		PublishEvent(new PollVoteAddedEvent(arg0, arg1, arg2, arg3, arg4));
	private Task PublishPollVoteRemoved(Discord.Cacheable<Discord.IUser, System.UInt64> arg0, Discord.Cacheable<Discord.WebSocket.ISocketMessageChannel, Discord.Rest.IRestMessageChannel, Discord.IMessageChannel, System.UInt64> arg1, Discord.Cacheable<Discord.IUserMessage, System.UInt64> arg2, System.Nullable<Discord.Cacheable<Discord.WebSocket.SocketGuild, Discord.Rest.RestGuild, Discord.IGuild, System.UInt64>> arg3, System.UInt64 arg4) =>
		PublishEvent(new PollVoteRemovedEvent(arg0, arg1, arg2, arg3, arg4));
	private Task PublishRoleCreated(Discord.WebSocket.SocketRole arg0) =>
		PublishEvent(new RoleCreatedEvent(arg0));
	private Task PublishRoleDeleted(Discord.WebSocket.SocketRole arg0) =>
		PublishEvent(new RoleDeletedEvent(arg0));
	private Task PublishRoleUpdated(Discord.WebSocket.SocketRole arg0, Discord.WebSocket.SocketRole arg1) =>
		PublishEvent(new RoleUpdatedEvent(arg0, arg1));
	private Task PublishJoinedGuild(Discord.WebSocket.SocketGuild arg0) =>
		PublishEvent(new JoinedGuildEvent(arg0));
	private Task PublishLeftGuild(Discord.WebSocket.SocketGuild arg0) =>
		PublishEvent(new LeftGuildEvent(arg0));
	private Task PublishGuildAvailable(Discord.WebSocket.SocketGuild arg0) =>
		PublishEvent(new GuildAvailableEvent(arg0));
	private Task PublishGuildUnavailable(Discord.WebSocket.SocketGuild arg0) =>
		PublishEvent(new GuildUnavailableEvent(arg0));
	private Task PublishGuildMembersDownloaded(Discord.WebSocket.SocketGuild arg0) =>
		PublishEvent(new GuildMembersDownloadedEvent(arg0));
	private Task PublishGuildUpdated(Discord.WebSocket.SocketGuild arg0, Discord.WebSocket.SocketGuild arg1) =>
		PublishEvent(new GuildUpdatedEvent(arg0, arg1));
	private Task PublishGuildJoinRequestDeleted(Discord.Cacheable<Discord.WebSocket.SocketGuildUser, System.UInt64> arg0, Discord.WebSocket.SocketGuild arg1) =>
		PublishEvent(new GuildJoinRequestDeletedEvent(arg0, arg1));
	private Task PublishGuildScheduledEventCreated(Discord.WebSocket.SocketGuildEvent arg0) =>
		PublishEvent(new GuildScheduledEventCreatedEvent(arg0));
	private Task PublishGuildScheduledEventUpdated(Discord.Cacheable<Discord.WebSocket.SocketGuildEvent, System.UInt64> arg0, Discord.WebSocket.SocketGuildEvent arg1) =>
		PublishEvent(new GuildScheduledEventUpdatedEvent(arg0, arg1));
	private Task PublishGuildScheduledEventCancelled(Discord.WebSocket.SocketGuildEvent arg0) =>
		PublishEvent(new GuildScheduledEventCancelledEvent(arg0));
	private Task PublishGuildScheduledEventCompleted(Discord.WebSocket.SocketGuildEvent arg0) =>
		PublishEvent(new GuildScheduledEventCompletedEvent(arg0));
	private Task PublishGuildScheduledEventStarted(Discord.WebSocket.SocketGuildEvent arg0) =>
		PublishEvent(new GuildScheduledEventStartedEvent(arg0));
	private Task PublishGuildScheduledEventUserAdd(Discord.Cacheable<Discord.WebSocket.SocketUser, Discord.Rest.RestUser, Discord.IUser, System.UInt64> arg0, Discord.WebSocket.SocketGuildEvent arg1) =>
		PublishEvent(new GuildScheduledEventUserAddEvent(arg0, arg1));
	private Task PublishGuildScheduledEventUserRemove(Discord.Cacheable<Discord.WebSocket.SocketUser, Discord.Rest.RestUser, Discord.IUser, System.UInt64> arg0, Discord.WebSocket.SocketGuildEvent arg1) =>
		PublishEvent(new GuildScheduledEventUserRemoveEvent(arg0, arg1));
	private Task PublishIntegrationCreated(Discord.IIntegration arg0) =>
		PublishEvent(new IntegrationCreatedEvent(arg0));
	private Task PublishIntegrationUpdated(Discord.IIntegration arg0) =>
		PublishEvent(new IntegrationUpdatedEvent(arg0));
	private Task PublishIntegrationDeleted(Discord.IGuild arg0, System.UInt64 arg1, Discord.Optional<System.UInt64> arg2) =>
		PublishEvent(new IntegrationDeletedEvent(arg0, arg1, arg2));
	private Task PublishUserJoined(Discord.WebSocket.SocketGuildUser arg0) =>
		PublishEvent(new UserJoinedEvent(arg0));
	private Task PublishUserLeft(Discord.WebSocket.SocketGuild arg0, Discord.WebSocket.SocketUser arg1) =>
		PublishEvent(new UserLeftEvent(arg0, arg1));
	private Task PublishUserBanned(Discord.WebSocket.SocketUser arg0, Discord.WebSocket.SocketGuild arg1) =>
		PublishEvent(new UserBannedEvent(arg0, arg1));
	private Task PublishUserUnbanned(Discord.WebSocket.SocketUser arg0, Discord.WebSocket.SocketGuild arg1) =>
		PublishEvent(new UserUnbannedEvent(arg0, arg1));
	private Task PublishUserUpdated(Discord.WebSocket.SocketUser arg0, Discord.WebSocket.SocketUser arg1) =>
		PublishEvent(new UserUpdatedEvent(arg0, arg1));
	private Task PublishGuildMemberUpdated(Discord.Cacheable<Discord.WebSocket.SocketGuildUser, System.UInt64> arg0, Discord.WebSocket.SocketGuildUser arg1) =>
		PublishEvent(new GuildMemberUpdatedEvent(arg0, arg1));
	private Task PublishUserVoiceStateUpdated(Discord.WebSocket.SocketUser arg0, Discord.WebSocket.SocketVoiceState arg1, Discord.WebSocket.SocketVoiceState arg2) =>
		PublishEvent(new UserVoiceStateUpdatedEvent(arg0, arg1, arg2));
	private Task PublishVoiceServerUpdated(Discord.WebSocket.SocketVoiceServer arg0) =>
		PublishEvent(new VoiceServerUpdatedEvent(arg0));
	private Task PublishCurrentUserUpdated(Discord.WebSocket.SocketSelfUser arg0, Discord.WebSocket.SocketSelfUser arg1) =>
		PublishEvent(new CurrentUserUpdatedEvent(arg0, arg1));
	private Task PublishUserIsTyping(Discord.Cacheable<Discord.IUser, System.UInt64> arg0, Discord.Cacheable<Discord.IMessageChannel, System.UInt64> arg1) =>
		PublishEvent(new UserIsTypingEvent(arg0, arg1));
	private Task PublishRecipientAdded(Discord.WebSocket.SocketGroupUser arg0) =>
		PublishEvent(new RecipientAddedEvent(arg0));
	private Task PublishRecipientRemoved(Discord.WebSocket.SocketGroupUser arg0) =>
		PublishEvent(new RecipientRemovedEvent(arg0));
	private Task PublishPresenceUpdated(Discord.WebSocket.SocketUser arg0, Discord.WebSocket.SocketPresence arg1, Discord.WebSocket.SocketPresence arg2) =>
		PublishEvent(new PresenceUpdatedEvent(arg0, arg1, arg2));
	private Task PublishInviteCreated(Discord.WebSocket.SocketInvite arg0) =>
		PublishEvent(new InviteCreatedEvent(arg0));
	private Task PublishInviteDeleted(Discord.WebSocket.SocketGuildChannel arg0, System.String arg1) =>
		PublishEvent(new InviteDeletedEvent(arg0, arg1));
	private Task PublishInteractionCreated(Discord.WebSocket.SocketInteraction arg0) =>
		PublishEvent(new InteractionCreatedEvent(arg0));
	private Task PublishButtonExecuted(Discord.WebSocket.SocketMessageComponent arg0) =>
		PublishEvent(new ButtonExecutedEvent(arg0));
	private Task PublishSelectMenuExecuted(Discord.WebSocket.SocketMessageComponent arg0) =>
		PublishEvent(new SelectMenuExecutedEvent(arg0));
	private Task PublishSlashCommandExecuted(Discord.WebSocket.SocketSlashCommand arg0) =>
		PublishEvent(new SlashCommandExecutedEvent(arg0));
	private Task PublishUserCommandExecuted(Discord.WebSocket.SocketUserCommand arg0) =>
		PublishEvent(new UserCommandExecutedEvent(arg0));
	private Task PublishMessageCommandExecuted(Discord.WebSocket.SocketMessageCommand arg0) =>
		PublishEvent(new MessageCommandExecutedEvent(arg0));
	private Task PublishAutocompleteExecuted(Discord.WebSocket.SocketAutocompleteInteraction arg0) =>
		PublishEvent(new AutocompleteExecutedEvent(arg0));
	private Task PublishModalSubmitted(Discord.WebSocket.SocketModal arg0) =>
		PublishEvent(new ModalSubmittedEvent(arg0));
	private Task PublishApplicationCommandCreated(Discord.WebSocket.SocketApplicationCommand arg0) =>
		PublishEvent(new ApplicationCommandCreatedEvent(arg0));
	private Task PublishApplicationCommandUpdated(Discord.WebSocket.SocketApplicationCommand arg0) =>
		PublishEvent(new ApplicationCommandUpdatedEvent(arg0));
	private Task PublishApplicationCommandDeleted(Discord.WebSocket.SocketApplicationCommand arg0) =>
		PublishEvent(new ApplicationCommandDeletedEvent(arg0));
	private Task PublishThreadCreated(Discord.WebSocket.SocketThreadChannel arg0) =>
		PublishEvent(new ThreadCreatedEvent(arg0));
	private Task PublishThreadUpdated(Discord.Cacheable<Discord.WebSocket.SocketThreadChannel, System.UInt64> arg0, Discord.WebSocket.SocketThreadChannel arg1) =>
		PublishEvent(new ThreadUpdatedEvent(arg0, arg1));
	private Task PublishThreadDeleted(Discord.Cacheable<Discord.WebSocket.SocketThreadChannel, System.UInt64> arg0) =>
		PublishEvent(new ThreadDeletedEvent(arg0));
	private Task PublishThreadMemberJoined(Discord.WebSocket.SocketThreadUser arg0) =>
		PublishEvent(new ThreadMemberJoinedEvent(arg0));
	private Task PublishThreadMemberLeft(Discord.WebSocket.SocketThreadUser arg0) =>
		PublishEvent(new ThreadMemberLeftEvent(arg0));
	private Task PublishStageStarted(Discord.WebSocket.SocketStageChannel arg0) =>
		PublishEvent(new StageStartedEvent(arg0));
	private Task PublishStageEnded(Discord.WebSocket.SocketStageChannel arg0) =>
		PublishEvent(new StageEndedEvent(arg0));
	private Task PublishStageUpdated(Discord.WebSocket.SocketStageChannel arg0, Discord.WebSocket.SocketStageChannel arg1) =>
		PublishEvent(new StageUpdatedEvent(arg0, arg1));
	private Task PublishRequestToSpeak(Discord.WebSocket.SocketStageChannel arg0, Discord.WebSocket.SocketGuildUser arg1) =>
		PublishEvent(new RequestToSpeakEvent(arg0, arg1));
	private Task PublishSpeakerAdded(Discord.WebSocket.SocketStageChannel arg0, Discord.WebSocket.SocketGuildUser arg1) =>
		PublishEvent(new SpeakerAddedEvent(arg0, arg1));
	private Task PublishSpeakerRemoved(Discord.WebSocket.SocketStageChannel arg0, Discord.WebSocket.SocketGuildUser arg1) =>
		PublishEvent(new SpeakerRemovedEvent(arg0, arg1));
	private Task PublishGuildStickerCreated(Discord.WebSocket.SocketCustomSticker arg0) =>
		PublishEvent(new GuildStickerCreatedEvent(arg0));
	private Task PublishGuildStickerUpdated(Discord.WebSocket.SocketCustomSticker arg0, Discord.WebSocket.SocketCustomSticker arg1) =>
		PublishEvent(new GuildStickerUpdatedEvent(arg0, arg1));
	private Task PublishGuildStickerDeleted(Discord.WebSocket.SocketCustomSticker arg0) =>
		PublishEvent(new GuildStickerDeletedEvent(arg0));
	private Task PublishWebhooksUpdated(Discord.WebSocket.SocketGuild arg0, Discord.WebSocket.SocketChannel arg1) =>
		PublishEvent(new WebhooksUpdatedEvent(arg0, arg1));
	private Task PublishAuditLogCreated(Discord.WebSocket.SocketAuditLogEntry arg0, Discord.WebSocket.SocketGuild arg1) =>
		PublishEvent(new AuditLogCreatedEvent(arg0, arg1));
	private Task PublishAutoModRuleCreated(Discord.WebSocket.SocketAutoModRule arg0) =>
		PublishEvent(new AutoModRuleCreatedEvent(arg0));
	private Task PublishAutoModRuleUpdated(Discord.Cacheable<Discord.WebSocket.SocketAutoModRule, System.UInt64> arg0, Discord.WebSocket.SocketAutoModRule arg1) =>
		PublishEvent(new AutoModRuleUpdatedEvent(arg0, arg1));
	private Task PublishAutoModRuleDeleted(Discord.WebSocket.SocketAutoModRule arg0) =>
		PublishEvent(new AutoModRuleDeletedEvent(arg0));
	private Task PublishAutoModActionExecuted(Discord.WebSocket.SocketGuild arg0, Discord.AutoModRuleAction arg1, Discord.WebSocket.AutoModActionExecutedData arg2) =>
		PublishEvent(new AutoModActionExecutedEvent(arg0, arg1, arg2));
	private Task PublishEntitlementCreated(Discord.WebSocket.SocketEntitlement arg0) =>
		PublishEvent(new EntitlementCreatedEvent(arg0));
	private Task PublishEntitlementUpdated(Discord.Cacheable<Discord.WebSocket.SocketEntitlement, System.UInt64> arg0, Discord.WebSocket.SocketEntitlement arg1) =>
		PublishEvent(new EntitlementUpdatedEvent(arg0, arg1));
	private Task PublishEntitlementDeleted(Discord.Cacheable<Discord.WebSocket.SocketEntitlement, System.UInt64> arg0) =>
		PublishEvent(new EntitlementDeletedEvent(arg0));
	private Task PublishSubscriptionCreated(Discord.WebSocket.SocketSubscription arg0) =>
		PublishEvent(new SubscriptionCreatedEvent(arg0));
	private Task PublishSubscriptionUpdated(Discord.Cacheable<Discord.WebSocket.SocketSubscription, System.UInt64> arg0, Discord.WebSocket.SocketSubscription arg1) =>
		PublishEvent(new SubscriptionUpdatedEvent(arg0, arg1));
	private Task PublishSubscriptionDeleted(Discord.Cacheable<Discord.WebSocket.SocketSubscription, System.UInt64> arg0) =>
		PublishEvent(new SubscriptionDeletedEvent(arg0));
	private Task PublishLog(Discord.LogMessage arg0) =>
		PublishEvent(new LogEvent(arg0));
	private Task PublishLoggedIn() =>
		PublishEvent(new LoggedInEvent());
	private Task PublishLoggedOut() =>
		PublishEvent(new LoggedOutEvent());
	private Task PublishSentRequest(System.String arg0, System.String arg1, System.Double arg2) =>
		PublishEvent(new SentRequestEvent(arg0, arg1, arg2));

	#endregion

}
