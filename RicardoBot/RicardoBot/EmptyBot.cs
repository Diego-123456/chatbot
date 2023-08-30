// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RicardoBot
{
    public class EmptyBot<T> : ActivityHandler where T : Dialog
    {
        protected readonly Dialog _dialog;
        protected readonly BotState _conversationState;
        protected readonly ILogger _logger;

        public EmptyBot(T dialog, ConversationState conversationState, ILogger<EmptyBot<T>> logger)
        {
            _dialog = dialog;
            _conversationState = conversationState;
            _logger = logger;
        }

        //Mensaje de bienvenida
        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    await _dialog.RunAsync(
                    turnContext,
                    _conversationState.CreateProperty<DialogState>(nameof(DialogState)),
                    cancellationToken
                    );
                }
            }
        }

        //Verifica si se ha recibido una actividad por parte del usuario
        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken = default)
        {
            await _dialog.RunAsync(
                turnContext,
                _conversationState.CreateProperty<DialogState>(nameof(DialogState)),
                cancellationToken
                );
        }

        //Procesa una actividad entrante por parte del bot o el usuario
        public override async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default)
        {
            await base.OnTurnAsync(turnContext, cancellationToken);
            await _conversationState.SaveChangesAsync(turnContext, false, cancellationToken);

        }

    }
}
