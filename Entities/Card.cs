using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using static OtherPeopleRecordsWeb.Entities.Enums;

namespace OtherPeopleRecordsWeb.Entities
{
	public class Card
	{
		public Guid Id { get; set; }
		[Required]
		[StringLength(50, ErrorMessage = "El título no puede superar los 50 caracteres.")]
		public string Title { get; set; } = "Title";
		[Required]
		[StringLength(50, ErrorMessage = "El Subtitulo no puede superar los 50 caracteres.")]
		public string Subtitle { get; set; } = "Subtitle";
		[StringLength(100, ErrorMessage = "El Link no puede superar los 100 caracteres.")]
		public string SpotifyLink { get; set; } = "";
		[StringLength(100, ErrorMessage = "El Link no puede superar los 100 caracteres.")]
		public string YoutubeLink { get; set; } = "";
		[StringLength(100, ErrorMessage = "El Link no puede superar los 100 caracteres.")]
		public string AppleMusicLink { get; set; } = "";
		[StringLength(100, ErrorMessage = "El Link no puede superar los 100 caracteres.")]
		public string InstagramLink { get; set; } = "";
		[StringLength(100, ErrorMessage = "El Link no puede superar los 100 caracteres.")]
		public string SoundCloudLink { get; set; } = "";
		[StringLength(100, ErrorMessage = "El Link no puede superar los 100 caracteres.")]
		public string BeatStarsLink { get; set; } = "";
		[StringLength(100, ErrorMessage = "El Link no puede superar los 100 caracteres.")]
		public string TwitterLink { get; set; } = "";
		[StringLength(50, ErrorMessage = "La Ubicacion no puede superar los 50 caracteres.")]
		public string Ubicacion { get; set; } = "Ubicacion";
		[StringLength(1000, ErrorMessage = "El Link no puede superar los 100 caracteres.")]
		public string IMG { get; set; } = "https://otherpeople.es/cdn/shop/files/BRIKS_900x.png?v=1657108163&quot";
		[StringLength(1000, ErrorMessage = "El Link no puede superar los 100 caracteres.")]
		public string VIDEO { get; set; } = "https://www.youtube.com/embed/o3yOhfbqYEs?si=ln0jSx3-0ZnLr0ly";
		[Required]
		public CardType cardType { get; set; } = CardType.Song;
		[Required]
		public DateTime date { get; set; } = DateTime.Now;
    }
}
