using Discord;
using Discord.WebSocket;
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
		_socketClient.SentRequest -= PublishSentRequest;

	}

	#region Publish methods
	private Task PublishConnected() =>
		PublishEvent(new ConnectedEvent());
	private Task PublishDisconnected(Exception arg0) =>
		PublishEvent(new DisconnectedEvent(arg0));
	private Task PublishReady() =>
		PublishEvent(new ReadyEvent());
	private Task PublishLatencyUpdated(int arg0, int arg1) =>
		PublishEvent(new LatencyUpdatedEvent(arg0, arg1));
	private Task PublishChannelCreated(SocketChannel arg0) =>
		PublishEvent(new ChannelCreatedEvent(arg0));
	private Task PublishChannelDestroyed(SocketChannel arg0) =>
		PublishEvent(new ChannelDestroyedEvent(arg0));
	private Task PublishChannelUpdated(SocketChannel arg0, SocketChannel arg1) =>
		PublishEvent(new ChannelUpdatedEvent(arg0, arg1));
	private Task PublishVoiceChannelStatusUpdated(Cacheable<SocketVoiceChannel, ulong> arg0, string arg1, string arg2) =>
		PublishEvent(new VoiceChannelStatusUpdatedEvent(arg0, arg1, arg2));
	private Task PublishMessageReceived(SocketMessage arg0) =>
		PublishEvent(new MessageReceivedEvent(arg0));
	private Task PublishMessageDeleted(Cacheable<IMessage, ulong> arg0, Cacheable<IMessageChannel, ulong> arg1) =>
		PublishEvent(new MessageDeletedEvent(arg0, arg1));
	private Task PublishMessagesBulkDeleted(IReadOnlyCollection<Cacheable<IMessage, ulong>> arg0, Cacheable<IMessageChannel, ulong> arg1) =>
		PublishEvent(new MessagesBulkDeletedEvent(arg0, arg1));
	private Task PublishMessageUpdated(Cacheable<IMessage, ulong> arg0, SocketMessage arg1, ISocketMessageChannel arg2) =>
		PublishEvent(new MessageUpdatedEvent(arg0, arg1, arg2));
	private Task PublishReactionAdded(Cacheable<IUserMessage, ulong> arg0, Cacheable<IMessageChannel, ulong> arg1, SocketReaction arg2) =>
		PublishEvent(new ReactionAddedEvent(arg0, arg1, arg2));
	private Task PublishReactionRemoved(Cacheable<IUserMessage, ulong> arg0, Cacheable<IMessageChannel, ulong> arg1, SocketReaction arg2) =>
		PublishEvent(new ReactionRemovedEvent(arg0, arg1, arg2));
	private Task PublishReactionsCleared(Cacheable<IUserMessage, ulong> arg0, Cacheable<IMessageChannel, ulong> arg1) =>
		PublishEvent(new ReactionsClearedEvent(arg0, arg1));
	private Task PublishReactionsRemovedForEmote(Cacheable<IUserMessage, ulong> arg0, Cacheable<IMessageChannel, ulong> arg1, IEmote arg2) =>
		PublishEvent(new ReactionsRemovedForEmoteEvent(arg0, arg1, arg2));
	private Task PublishPollVoteAdded(Cacheable<IUser, ulong> arg0, Cacheable<ISocketMessageChannel, Discord.Rest.IRestMessageChannel, IMessageChannel, ulong> arg1, Cacheable<IUserMessage, ulong> arg2, Cacheable<SocketGuild, Discord.Rest.RestGuild, IGuild, ulong>? arg3, ulong arg4) =>
		PublishEvent(new PollVoteAddedEvent(arg0, arg1, arg2, arg3, arg4));
	private Task PublishPollVoteRemoved(Cacheable<IUser, ulong> arg0, Cacheable<ISocketMessageChannel, Discord.Rest.IRestMessageChannel, IMessageChannel, ulong> arg1, Cacheable<IUserMessage, ulong> arg2, Cacheable<SocketGuild, Discord.Rest.RestGuild, IGuild, ulong>? arg3, ulong arg4) =>
		PublishEvent(new PollVoteRemovedEvent(arg0, arg1, arg2, arg3, arg4));
	private Task PublishRoleCreated(SocketRole arg0) =>
		PublishEvent(new RoleCreatedEvent(arg0));
	private Task PublishRoleDeleted(SocketRole arg0) =>
		PublishEvent(new RoleDeletedEvent(arg0));
	private Task PublishRoleUpdated(SocketRole arg0, SocketRole arg1) =>
		PublishEvent(new RoleUpdatedEvent(arg0, arg1));
	private Task PublishJoinedGuild(SocketGuild arg0) =>
		PublishEvent(new JoinedGuildEvent(arg0));
	private Task PublishLeftGuild(SocketGuild arg0) =>
		PublishEvent(new LeftGuildEvent(arg0));
	private Task PublishGuildAvailable(SocketGuild arg0) =>
		PublishEvent(new GuildAvailableEvent(arg0));
	private Task PublishGuildUnavailable(SocketGuild arg0) =>
		PublishEvent(new GuildUnavailableEvent(arg0));
	private Task PublishGuildMembersDownloaded(SocketGuild arg0) =>
		PublishEvent(new GuildMembersDownloadedEvent(arg0));
	private Task PublishGuildUpdated(SocketGuild arg0, SocketGuild arg1) =>
		PublishEvent(new GuildUpdatedEvent(arg0, arg1));
	private Task PublishGuildJoinRequestDeleted(Cacheable<SocketGuildUser, ulong> arg0, SocketGuild arg1) =>
		PublishEvent(new GuildJoinRequestDeletedEvent(arg0, arg1));
	private Task PublishGuildScheduledEventCreated(SocketGuildEvent arg0) =>
		PublishEvent(new GuildScheduledEventCreatedEvent(arg0));
	private Task PublishGuildScheduledEventUpdated(Cacheable<SocketGuildEvent, ulong> arg0, SocketGuildEvent arg1) =>
		PublishEvent(new GuildScheduledEventUpdatedEvent(arg0, arg1));
	private Task PublishGuildScheduledEventCancelled(SocketGuildEvent arg0) =>
		PublishEvent(new GuildScheduledEventCancelledEvent(arg0));
	private Task PublishGuildScheduledEventCompleted(SocketGuildEvent arg0) =>
		PublishEvent(new GuildScheduledEventCompletedEvent(arg0));
	private Task PublishGuildScheduledEventStarted(SocketGuildEvent arg0) =>
		PublishEvent(new GuildScheduledEventStartedEvent(arg0));
	private Task PublishGuildScheduledEventUserAdd(Cacheable<SocketUser, Discord.Rest.RestUser, IUser, ulong> arg0, SocketGuildEvent arg1) =>
		PublishEvent(new GuildScheduledEventUserAddEvent(arg0, arg1));
	private Task PublishGuildScheduledEventUserRemove(Cacheable<SocketUser, Discord.Rest.RestUser, IUser, ulong> arg0, SocketGuildEvent arg1) =>
		PublishEvent(new GuildScheduledEventUserRemoveEvent(arg0, arg1));
	private Task PublishIntegrationCreated(IIntegration arg0) =>
		PublishEvent(new IntegrationCreatedEvent(arg0));
	private Task PublishIntegrationUpdated(IIntegration arg0) =>
		PublishEvent(new IntegrationUpdatedEvent(arg0));
	private Task PublishIntegrationDeleted(IGuild arg0, ulong arg1, Optional<ulong> arg2) =>
		PublishEvent(new IntegrationDeletedEvent(arg0, arg1, arg2));
	private Task PublishUserJoined(SocketGuildUser arg0) =>
		PublishEvent(new UserJoinedEvent(arg0));
	private Task PublishUserLeft(SocketGuild arg0, SocketUser arg1) =>
		PublishEvent(new UserLeftEvent(arg0, arg1));
	private Task PublishUserBanned(SocketUser arg0, SocketGuild arg1) =>
		PublishEvent(new UserBannedEvent(arg0, arg1));
	private Task PublishUserUnbanned(SocketUser arg0, SocketGuild arg1) =>
		PublishEvent(new UserUnbannedEvent(arg0, arg1));
	private Task PublishUserUpdated(SocketUser arg0, SocketUser arg1) =>
		PublishEvent(new UserUpdatedEvent(arg0, arg1));
	private Task PublishGuildMemberUpdated(Cacheable<SocketGuildUser, ulong> arg0, SocketGuildUser arg1) =>
		PublishEvent(new GuildMemberUpdatedEvent(arg0, arg1));
	private Task PublishUserVoiceStateUpdated(SocketUser arg0, SocketVoiceState arg1, SocketVoiceState arg2) =>
		PublishEvent(new UserVoiceStateUpdatedEvent(arg0, arg1, arg2));
	private Task PublishVoiceServerUpdated(SocketVoiceServer arg0) =>
		PublishEvent(new VoiceServerUpdatedEvent(arg0));
	private Task PublishCurrentUserUpdated(SocketSelfUser arg0, SocketSelfUser arg1) =>
		PublishEvent(new CurrentUserUpdatedEvent(arg0, arg1));
	private Task PublishUserIsTyping(Cacheable<IUser, ulong> arg0, Cacheable<IMessageChannel, ulong> arg1) =>
		PublishEvent(new UserIsTypingEvent(arg0, arg1));
	private Task PublishRecipientAdded(SocketGroupUser arg0) =>
		PublishEvent(new RecipientAddedEvent(arg0));
	private Task PublishRecipientRemoved(SocketGroupUser arg0) =>
		PublishEvent(new RecipientRemovedEvent(arg0));
	private Task PublishPresenceUpdated(SocketUser arg0, SocketPresence arg1, SocketPresence arg2) =>
		PublishEvent(new PresenceUpdatedEvent(arg0, arg1, arg2));
	private Task PublishInviteCreated(SocketInvite arg0) =>
		PublishEvent(new InviteCreatedEvent(arg0));
	private Task PublishInviteDeleted(SocketGuildChannel arg0, string arg1) =>
		PublishEvent(new InviteDeletedEvent(arg0, arg1));
	private Task PublishInteractionCreated(SocketInteraction arg0) =>
		PublishEvent(new InteractionCreatedEvent(arg0));
	private Task PublishButtonExecuted(SocketMessageComponent arg0) =>
		PublishEvent(new ButtonExecutedEvent(arg0));
	private Task PublishSelectMenuExecuted(SocketMessageComponent arg0) =>
		PublishEvent(new SelectMenuExecutedEvent(arg0));
	private Task PublishSlashCommandExecuted(SocketSlashCommand arg0) =>
		PublishEvent(new SlashCommandExecutedEvent(arg0));
	private Task PublishUserCommandExecuted(SocketUserCommand arg0) =>
		PublishEvent(new UserCommandExecutedEvent(arg0));
	private Task PublishMessageCommandExecuted(SocketMessageCommand arg0) =>
		PublishEvent(new MessageCommandExecutedEvent(arg0));
	private Task PublishAutocompleteExecuted(SocketAutocompleteInteraction arg0) =>
		PublishEvent(new AutocompleteExecutedEvent(arg0));
	private Task PublishModalSubmitted(SocketModal arg0) =>
		PublishEvent(new ModalSubmittedEvent(arg0));
	private Task PublishApplicationCommandCreated(SocketApplicationCommand arg0) =>
		PublishEvent(new ApplicationCommandCreatedEvent(arg0));
	private Task PublishApplicationCommandUpdated(SocketApplicationCommand arg0) =>
		PublishEvent(new ApplicationCommandUpdatedEvent(arg0));
	private Task PublishApplicationCommandDeleted(SocketApplicationCommand arg0) =>
		PublishEvent(new ApplicationCommandDeletedEvent(arg0));
	private Task PublishThreadCreated(SocketThreadChannel arg0) =>
		PublishEvent(new ThreadCreatedEvent(arg0));
	private Task PublishThreadUpdated(Cacheable<SocketThreadChannel, ulong> arg0, SocketThreadChannel arg1) =>
		PublishEvent(new ThreadUpdatedEvent(arg0, arg1));
	private Task PublishThreadDeleted(Cacheable<SocketThreadChannel, ulong> arg0) =>
		PublishEvent(new ThreadDeletedEvent(arg0));
	private Task PublishThreadMemberJoined(SocketThreadUser arg0) =>
		PublishEvent(new ThreadMemberJoinedEvent(arg0));
	private Task PublishThreadMemberLeft(SocketThreadUser arg0) =>
		PublishEvent(new ThreadMemberLeftEvent(arg0));
	private Task PublishStageStarted(SocketStageChannel arg0) =>
		PublishEvent(new StageStartedEvent(arg0));
	private Task PublishStageEnded(SocketStageChannel arg0) =>
		PublishEvent(new StageEndedEvent(arg0));
	private Task PublishStageUpdated(SocketStageChannel arg0, SocketStageChannel arg1) =>
		PublishEvent(new StageUpdatedEvent(arg0, arg1));
	private Task PublishRequestToSpeak(SocketStageChannel arg0, SocketGuildUser arg1) =>
		PublishEvent(new RequestToSpeakEvent(arg0, arg1));
	private Task PublishSpeakerAdded(SocketStageChannel arg0, SocketGuildUser arg1) =>
		PublishEvent(new SpeakerAddedEvent(arg0, arg1));
	private Task PublishSpeakerRemoved(SocketStageChannel arg0, SocketGuildUser arg1) =>
		PublishEvent(new SpeakerRemovedEvent(arg0, arg1));
	private Task PublishGuildStickerCreated(SocketCustomSticker arg0) =>
		PublishEvent(new GuildStickerCreatedEvent(arg0));
	private Task PublishGuildStickerUpdated(SocketCustomSticker arg0, SocketCustomSticker arg1) =>
		PublishEvent(new GuildStickerUpdatedEvent(arg0, arg1));
	private Task PublishGuildStickerDeleted(SocketCustomSticker arg0) =>
		PublishEvent(new GuildStickerDeletedEvent(arg0));
	private Task PublishWebhooksUpdated(SocketGuild arg0, SocketChannel arg1) =>
		PublishEvent(new WebhooksUpdatedEvent(arg0, arg1));
	private Task PublishAuditLogCreated(SocketAuditLogEntry arg0, SocketGuild arg1) =>
		PublishEvent(new AuditLogCreatedEvent(arg0, arg1));
	private Task PublishAutoModRuleCreated(SocketAutoModRule arg0) =>
		PublishEvent(new AutoModRuleCreatedEvent(arg0));
	private Task PublishAutoModRuleUpdated(Cacheable<SocketAutoModRule, ulong> arg0, SocketAutoModRule arg1) =>
		PublishEvent(new AutoModRuleUpdatedEvent(arg0, arg1));
	private Task PublishAutoModRuleDeleted(SocketAutoModRule arg0) =>
		PublishEvent(new AutoModRuleDeletedEvent(arg0));
	private Task PublishAutoModActionExecuted(SocketGuild arg0, AutoModRuleAction arg1, AutoModActionExecutedData arg2) =>
		PublishEvent(new AutoModActionExecutedEvent(arg0, arg1, arg2));
	private Task PublishEntitlementCreated(SocketEntitlement arg0) =>
		PublishEvent(new EntitlementCreatedEvent(arg0));
	private Task PublishEntitlementUpdated(Cacheable<SocketEntitlement, ulong> arg0, SocketEntitlement arg1) =>
		PublishEvent(new EntitlementUpdatedEvent(arg0, arg1));
	private Task PublishEntitlementDeleted(Cacheable<SocketEntitlement, ulong> arg0) =>
		PublishEvent(new EntitlementDeletedEvent(arg0));
	private Task PublishSubscriptionCreated(SocketSubscription arg0) =>
		PublishEvent(new SubscriptionCreatedEvent(arg0));
	private Task PublishSubscriptionUpdated(Cacheable<SocketSubscription, ulong> arg0, SocketSubscription arg1) =>
		PublishEvent(new SubscriptionUpdatedEvent(arg0, arg1));
	private Task PublishSubscriptionDeleted(Cacheable<SocketSubscription, ulong> arg0) =>
		PublishEvent(new SubscriptionDeletedEvent(arg0));
	private Task PublishSentRequest(string arg0, string arg1, double arg2) =>
		PublishEvent(new SentRequestEvent(arg0, arg1, arg2));

	#endregion

}
