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
		public string IMG { get; set; } = "https://is1-ssl.mzstatic.com/image/thumb/Music123/v4/2f/81/af/2f81af2f-25c3-d5c2-9ea5-6d623ea22574/artwork.jpg/900x900cc-60.jpg";
		[StringLength(1000, ErrorMessage = "El Link no puede superar los 100 caracteres.")]
		public string VIDEO { get; set; } = "https://www.youtube.com/embed/o3yOhfbqYEs?si=ln0jSx3-0ZnLr0ly";
		[Required]
		public CardType cardType { get; set; } = CardType.Song;
		[Required]
		public DateTime date { get; set; } = DateTime.Now;
        [Required]
        public Guid UserId { get; set; } = new Guid();

        public Card()
        {
           
        }

        public Card(Card card)
        {
            Id = card.Id;
            Title = card.Title;
            Subtitle = card.Subtitle;
            SpotifyLink = card.SpotifyLink;
            YoutubeLink = card.YoutubeLink;
            AppleMusicLink = card.AppleMusicLink;
            InstagramLink = card.InstagramLink;
            SoundCloudLink = card.SoundCloudLink;
            BeatStarsLink = card.BeatStarsLink;
            TwitterLink = card.TwitterLink;
            Ubicacion = card.Ubicacion;
            IMG = card.IMG;
            VIDEO = card.VIDEO;
            cardType = card.cardType;
            date = card.date;
            UserId = card.UserId;
        }
    }

}

