using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tune_Star.BLL.DTO;
using Tune_Star.BLL.Interfaces;
using Tune_Star.BLL.Services;

namespace TuneStarApiWeb.Controllers
{
    [ApiController]
    [Route("api/Songs")]
    public class SongsConroller : Controller
    {
        private readonly ISongService songService;
        public SongsConroller(ISongService songServ)
        {
            songService = songServ;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SongDTO>>> GetSongs()
        {
            return songService.GetSongs().Result.ToList();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDTO>> DeleteSong(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var song = await songService.GetSong(id);
            if (song == null)
            {
                return NotFound();
            }

            await songService.DeleteSong(id);

            return Ok(song);
        }

        [HttpPut]
        public async Task<ActionResult<SongDTO>> EditSong(SongDTO song)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
             var song_ = await songService.GetSong(song.Id);
            if (song == null)
            {
                return NotFound();
            }

            await songService.UpdateSong(song);
            return Ok(song);
        }
    }
 }
