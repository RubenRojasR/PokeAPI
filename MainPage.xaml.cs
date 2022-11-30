using Newtonsoft.Json;
using PokeAPI.Models;
using System.Runtime.CompilerServices;

namespace PokeAPI;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
		GetPokemon();
	}

	public async void GetPokemon()
	{
		HttpClient client = new HttpClient();
		string ApiConnection = "https://pokeapi.co/api/v2/pokemon?limit=151&offset=0";
		try
		{
			var response = await client.GetAsync(ApiConnection);
			if (response.IsSuccessStatusCode)
			{
				var json = response.Content.ReadAsStringAsync().Result;	
				var result = JsonConvert.DeserializeObject<PokeResponse>(json);
				if(result != null)
				{
                    List<PokemonItemList> pokemonItems = result.Results;
					if(pokemonItems.Count != 0)
					{
						int i = 1;
						foreach (var item in pokemonItems)
						{
							item.Number = i;
							SetCard(item);
							i++;
						}
					}
				}
			}
		}
		catch(Exception e)
		{
			Console.WriteLine(e);
		}

    }

	private void SetCard(PokemonItemList item)
	{
		Label Number = new()
		{
            VerticalTextAlignment = TextAlignment.Center,
            Text = $"#{item.Number:000}",
			FontSize = 18,
			TextColor = Color.FromArgb("#fff"),

		};
		Label Name = new()
        {
			VerticalTextAlignment = TextAlignment.Center,
			FontAttributes = FontAttributes.Bold,
            Text = $"{item.Name}",
            FontSize = 18,
            TextColor = Color.FromArgb("#fff"),
        };

		Image pokeball = new()
		{
			Source = "Resources/Images/poke.png",
			Aspect = Aspect.AspectFit,
			HeightRequest = 50,


		};
		var tapped = new TapGestureRecognizer();
		tapped.Tapped += (sender,args) => GetPokemonData(item);
		pokeball.GestureRecognizers.Add(tapped);
		//Frame pokeballFrame = new()
		//{
		//	Padding = new Thickness(0),

		//}
		Grid grid = new()
		{
			ColumnDefinitions =
			{
				new ColumnDefinition(new GridLength(0.5,GridUnitType.Star)),
				new ColumnDefinition(new GridLength(0.5,GridUnitType.Star)),
			}
			
		};
     

        HorizontalStackLayout pokeLayout = new()
		{
			Children =
			{
				Number,
				Name,
				
			},
			Spacing = 15
			
		};

		grid.Add(pokeLayout, 0, 0);
		grid.Add(pokeball, 1, 0);
		Frame localPokeFrame = new()
		{
			BackgroundColor = Color.FromArgb("#0d1455"),
			CornerRadius = 15,
			Content = grid,
		};

		pokeFrame.Add(localPokeFrame);
    }

	private async void GetPokemonData(PokemonItemList item)
	{
		
		try
		{
			HttpClient httpClient = new();
			var response = httpClient.GetAsync(item.Url).Result;
			if (response.IsSuccessStatusCode)
			{
				var data = response.Content.ReadAsStringAsync().Result;
				var pokemonData = JsonConvert.DeserializeObject<Pokemon>(data);
				if (pokemonData != null)
				{
					await Navigation.PushAsync(new PokemonPage(pokemonData,item.Number));
				}
			}
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
		}
	}
}

