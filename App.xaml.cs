namespace PokeAPI;

public partial class App : Application
{
    public static string PokedexColor = "#9f0e10";
    public static string GrassColor = "#2bdab1";

    public static string PoisonColor = "#a13fa0";
    public static string FireColor = "#f08032";
    public static string FlyingColor = "#aa8ef1";
    public static string WaterColor = "#6791f0";
    public static string BugColor = "#a8b821";
    public static string NormalColor = "#a9a877";
    public static string ElectricColor = "#f8cf29";
    public static string GroundColor = "#e0c068";
    public static string FightingColor = "#c02f27";
    public static string PsychicColor = "#f75486";
    public static string RockColor = "#b8a038";
    public static string IceColor = "#96d7d7";
    public static string GhostColor = "#5b2f8f";
    public static string DragonColor = "#7038f8";

	public App()
	{
		InitializeComponent();
		var page = new NavigationPage(new MainPage());
		page.BarBackgroundColor = Color.FromArgb(PokedexColor);
		page.BarTextColor = Color.FromArgb("#FFFFFF");
		MainPage = page;
	}
}
