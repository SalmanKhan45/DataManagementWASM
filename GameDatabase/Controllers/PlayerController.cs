using GameDatabase.Database;
using GameDatabase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using Telerik.DataSource;
using Telerik.DataSource.Extensions;


namespace GameDatabase.Controllers
{
    public class PlayerController : ControllerBase
    {
        private readonly PlayerContext dbContext;
        private readonly ILogger<PlayerController> logger;
        public PlayerController(PlayerContext _dbContext, ILogger<PlayerController> _logger) 
        {
            dbContext = _dbContext;
            logger = _logger;
        }

        [HttpPost("get-all-players")]
        public async Task<IActionResult> GetPlayers([FromBody] DataSourceRequest request)
        {
            logger.LogInformation("--------------FETCHING PLAYERS---------------------");
            DataSourceResult players = await dbContext.Players.ToDataSourceResultAsync(request);

            return Ok(new
            {
                CurrentPageData = players.Data.Cast<Player>().ToList(),
                TotalItemCount = players.Total
            });
        }

        [HttpPost("add-player")]
        public async Task<IActionResult> AddPlayer([FromBody] Player player)
        {
            logger.LogInformation("-------------CREATING PLAYER-------------");
            await dbContext.Players.AddAsync(player);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("edit-player/{id}")]
        public async Task<IActionResult> EditPlayer([FromBody] Player player, [FromRoute] int id)
        {
            logger.LogInformation("------------EDITING PLAYER---------------");
            var playerToEdit = await dbContext.Players.FindAsync(id);

            if (playerToEdit == null)
            {
                return BadRequest();
            }

            playerToEdit.username = player.username;
            playerToEdit.email = player.email;
            playerToEdit.rank = player.rank;
            playerToEdit.kills = player.kills;
            playerToEdit.KD = player.KD;
            playerToEdit.headshots = player.headshots;
            playerToEdit.accuracy = player.accuracy;

            await dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("batch-edit-players")]
        public async Task<IActionResult> EditMultiplePlayers([FromBody] List<Player> players)
        {
            logger.LogInformation("------------EDITING MULTIPLE PLAYERS---------------");

            int playersChangedCount = 0;
            foreach (var player in players)
            {
                var playerToEdit = await dbContext.Players.FindAsync(player.Id);

                if (playerToEdit == null)
                {
                    return BadRequest();
                }

                playerToEdit.username = player.username;
                playerToEdit.email = player.email;
                playerToEdit.rank = player.rank;
                playerToEdit.kills = player.kills;
                playerToEdit.KD = player.KD;
                playerToEdit.headshots = player.headshots;
                playerToEdit.accuracy = player.accuracy;

                playersChangedCount++;
            }

            await dbContext.SaveChangesAsync();
            logger.LogInformation($"---------------- {playersChangedCount} PLAYERS CHANGED ------------------");

            return Ok();
        }

        [HttpPut("edit-column")]
        public async Task<IActionResult> EditColumn([FromBody] ColumnEditDTO column)
        {
            logger.LogInformation("--------------EDITING COLUMN FOR MULLTIPLE ROWS----------------");

            if (column.ids.Count() == 0)
                return BadRequest();

            PropertyInfo? propertyInfo = null;
            PropertyInfo[] playerProperties = typeof(Player).GetProperties();
            foreach (var property in playerProperties)
            {
                if (property.Name == column.property)
                {
                    propertyInfo = property;
                }
            }

            var val = propertyInfo.GetValue(column.playerData);

            if (column.forAll)
            {
                await dbContext.Players.ForEachAsync(p => { propertyInfo?.SetValue(p, val); });
                await dbContext.SaveChangesAsync();
                return Ok();
            }

            await dbContext.Players.Where(p => column.ids.Contains(p.Id))
                .ForEachAsync(p => { propertyInfo?.SetValue(p, val); });
            await dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("delete-player/{id}")]
        public async Task<IActionResult> DeletePlayer([FromRoute] int id)
        {
            logger.LogInformation("-------------------DELETING PLAYER-------------------");
            var playerToDelete = await dbContext.Players.FindAsync(id);

            if (playerToDelete == null)
            {
                return BadRequest();
            }

            dbContext.Players.Remove(playerToDelete);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("get-players")]
        public async Task<IActionResult> GetPlayers()
        {
            logger.LogInformation("-------------FETCHING PLAYERS------------");
            return Ok(await dbContext.Players.ToListAsync());
        }

    }
}
