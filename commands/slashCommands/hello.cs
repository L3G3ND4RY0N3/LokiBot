using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using System.Threading.Tasks;

namespace LokiBot.commands.slashCommands
{
    // group attribute to keep slash commands together
    [SlashCommandGroup("Greetings", "Greet users or yourself.")]
    internal class Hello : ApplicationCommandModule
    {
        [SlashCommand("sayhello", "Make the bot say hello to you.")]
        public async Task SayHello(InteractionContext interaction)
        {
            var emb = new DiscordEmbedBuilder()
            {
                Title = "**Hello!**",
                Description = $"Hello, {interaction.User.Mention}!",
                Color = DiscordColor.Blurple
            };
            //await interaction.Interaction.CreateResponseAsync(DSharpPlus.InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent("Hello!"));

            await interaction.DeferAsync();

            await interaction.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(emb));
        }

        [SlashCommand("greet", "Make the bot greet a user of your choice.")]
        public async Task Greet(InteractionContext interaction, [Option("User", "User to greet")] DiscordUser user)
        {

            await interaction.DeferAsync();

            var member = (DiscordMember)user; // cast to member to gain acces to member properties

            var emb = new DiscordEmbedBuilder()
            {
                Title = "**Hello!**",
                Description = $"Hello, {user.Mention}!",
                Color = DiscordColor.Blurple
            };

            await interaction.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(emb));
        }
    }
}
