using PokeAPI.Models;

namespace PokeAPI;

public partial class PokemonPage : ContentPage
{
	Pokemon Pokemon;

	public PokemonPage(Pokemon pokemon, int Number)
	{
		InitializeComponent();
		Pokemon = pokemon;
		SetPokemon(Pokemon, Number);
	}

	private void SetPokemon(Pokemon pokemon, int Number)
	{
		this.Title = $"{pokemon.Name} - #{Number:000}";
		PokeName.Text = pokemon.Name;
		
		PokeImage.Source = ImageSource.FromUri(new Uri(pokemon.Sprites.Front_default));
		float WeightKg = pokemon.Weight/ 10f;
		WeightLabel.Text = $" {WeightKg:0.0} Kg.";
		float HeightMts = pokemon.Height / 10f;
        HeightLabel.Text = $" {HeightMts:0.0} M.";
		HPLabel.Text = $"{pokemon.Stats[0].Base_stat}";
		HpBar.Progress = pokemon.Stats[0].Base_stat / 255f;
        AttackLabel.Text = $"{pokemon.Stats[1].Base_stat}";
        AttackBar.Progress = pokemon.Stats[1].Base_stat / 255f;
        DefenseLabel.Text = $"{pokemon.Stats[2].Base_stat}";
        DefenseBar.Progress = pokemon.Stats[2].Base_stat / 255f;
        SpecialAttackLabel.Text = $"{pokemon.Stats[3].Base_stat}";
        SpecialAttackBar.Progress = pokemon.Stats[4].Base_stat / 255f;
        SpecialDefenseLabel.Text = $"{pokemon.Stats[4].Base_stat}";
        SpecialDefenseBar.Progress = pokemon.Stats[4].Base_stat / 255f;
        SpeedLabel.Text = $"{pokemon.Stats[5].Base_stat}";
        SpeedBar.Progress = pokemon.Stats[5].Base_stat / 255f;

		foreach(var item in pokemon.Types)
		{
			var TypeName = "";
			var TypeColor = "";
			switch (item.Type.Name)
			{
				case "flying":
					TypeName = "Volador";
					TypeColor = App.FlyingColor;
					break;
				case "poison":
					TypeName = "Veneno";
					TypeColor = App.PoisonColor;
					break;
				case "bug":
					TypeName = "Bicho";
					TypeColor = App.BugColor;
					break;
				case "fire":
					TypeName = "Fuego";
					TypeColor = App.FireColor;
					break;
				case "ice":
					TypeName = "Hielo";
					TypeColor = App.IceColor;
					break;
				case "ground":
					TypeName = "Tierra";
					TypeColor = App.GroundColor;
					break;
				case "rock":
					TypeName = "Roca";
					TypeColor = App.RockColor;
					break;
				case "grass":
					TypeName = "Planta";
					TypeColor = App.GrassColor;
					break;
				case "water":
					TypeName = "Agua";
					TypeColor = App.WaterColor;
					break;
				case "electric":
					TypeName = "Eléctrico";
					TypeColor = App.ElectricColor;
					break;
				case "dragon":
					TypeName = "Dragón";
					TypeColor = App.DragonColor;
					break;
				case "normal":
					TypeName = "Normal";
					TypeColor = App.NormalColor;
					break;
				case "fighting":
					TypeName = "Lucha";
					TypeColor = App.FightingColor;
					break;
				case "ghost":
					TypeName = "Fantasma";
					TypeColor = App.GhostColor;
					break;
				case "psychic":
					TypeName = "Psíquico";
					TypeColor = App.PsychicColor;
					break;
				default:
                    TypeName = "Undefined";
                    TypeColor = App.PokedexColor;
                    break;
            }
			Frame type = new()
			{
				Padding = 15,
				BackgroundColor = Color.FromArgb(TypeColor),
				BorderColor = Color.FromArgb(TypeColor),
				Content = new Label
				{
					TextColor = Color.FromArgb("#FFF"),
					Text = TypeName,
					FontSize = 15,
					VerticalTextAlignment = TextAlignment.Center,

				}
			};
			TypeLayout.Children.Add(type);
		}


    }

	
}