[System.Serializable]
public struct Players
{
	[System.Serializable]
	public struct Player
	{
		public int id;
		public string login;
		public string password;
	
	}

	public Player[] objetos;
}