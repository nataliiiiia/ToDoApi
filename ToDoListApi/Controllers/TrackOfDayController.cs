using ToDoListApi.Clients;
using System.Text.RegularExpressions;
using ToDoListApi.Models.TrackOfDayModel;
using ToDoListApi.Models.MusicUriModel;
using Microsoft.AspNetCore.Mvc;

namespace ToDoListApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrackOfDayController : ControllerBase
    {
        private readonly ILogger<TrackOfDayController> _logger;
        private readonly TrackOfDayClient _client;
        private readonly FindMusicUriClient _fclient;
        public TrackOfDayController(ILogger<TrackOfDayController> logger,TrackOfDayClient client, FindMusicUriClient fclient)
        {
            _logger = logger;
            _client = client;
            _fclient = fclient;
        }
        
        [HttpGet("GetSongUri")]
        public async Task<MusicRoot> GetMusicUri()
        {
            TrackRoot mr = GetFirstTrack().Result;
            string track = SongUri(mr);
            var song = await _fclient.GetMusicUriAsync(track);
            return song;      
        }
        [HttpGet("GetSong")]
        public async Task<TrackRoot> GetFirstTrack()
        {
            var track = await _client.GetFirstChartTrack();
            return track;
        }
        private string SongUri(TrackRoot tr)
        {
            List<Track> tracks = new List<Track>();
            tracks = tr.Tracks.Track;
            string name = tracks[0].Name;
            string artist = tracks[0].Artist.Name;
            string track = $"{name} {artist}";
            string pattern = @"\s";
            string target = "%20";
            Regex regex = new Regex(pattern);
            string result = regex.Replace(track, target);
            return result;

        }
    }
}
