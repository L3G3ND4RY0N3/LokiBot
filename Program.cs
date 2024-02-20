using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.SlashCommands;
using LokiBot.commands;
using LokiBot.commands.slashCommands;
using LokiBot.config;
using System;
using System.Threading.Tasks;

namespace LokiBot
{
    internal class Program
    {
        private static DiscordClient Client { get; set; }
        private static CommandsNextExtension Commands { get; set; }
        static async Task Main(string[] args)
        {
            var jsonReader = new JSONReader();

            await jsonReader.ReadJSON();

            var discordConfig = new DiscordConfiguration()
            {
                Intents = DiscordIntents.All,
                Token = jsonReader.token,
                TokenType = TokenType.Bot,
                AutoReconnect = true    
            };

            Client = new DiscordClient(discordConfig);

            Client.Ready += Client_Ready;

            // creation of the Command Config
            var commandsConfig = new CommandsNextConfiguration()
            {
                StringPrefixes = new string[] { jsonReader.prefix},
                EnableMentionPrefix = true,
                EnableDms = true,
                EnableDefaultHelp = false
                
            };

            Commands = Client.UseCommandsNext(commandsConfig);

            // enable slash commands
            var slashCommandConfig = Client.UseSlashCommands();

            // registering normal commands, TODO find way to do this iteratively
            Commands.RegisterCommands<Ping>();

            // register slash commands too
            slashCommandConfig.RegisterCommands<Hello>();

            await Client.ConnectAsync();
            await Task.Delay(-1);
        }

        private static Task Client_Ready(DiscordClient sender, DSharpPlus.EventArgs.ReadyEventArgs args)
        {
            Console.WriteLine($"{sender.CurrentUser.Username} is online.");
            return Task.CompletedTask;
        }
    }
}
