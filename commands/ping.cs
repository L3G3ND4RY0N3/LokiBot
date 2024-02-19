using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System.Threading.Tasks;

namespace LokiBot.commands
{
    internal class ping : BaseCommandModule
    {
        [Command("ping")]
        public async Task Ping(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("Pong!");
        }

        [Command("tag")]
        public async Task Tag(CommandContext ctx,  DiscordUser usr)
        {
            await ctx.Channel.SendMessageAsync($"Hey {usr.Mention}, how are you doin?");
        }

        [Command("embed")]
        public async Task Embed(CommandContext ctx, DiscordUser usr)
        {
            var emb = new DiscordEmbedBuilder()
            {
                Title = "*Hello!*",
                Description = $"Hello, {usr.Mention}!",
                Color = DiscordColor.Blurple
            };
            await ctx.Channel.SendMessageAsync(embed: emb);
        }
    }
}
