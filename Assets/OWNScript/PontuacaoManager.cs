public static class PontuacaoManager {

	public static readonly int pontosPorSemente = 10;
	private static int fullScore=0;
	private static int partialScore=0;
	public static string lastLevel="";

	public static int PontosPorSemente {
		get {
			return pontosPorSemente;
		}
	}
	
	public static void addScore (int score){
		fullScore += score;
		partialScore += score;

		PontuacaoTextManager.efeitoAoPontuar();
	}
	public static void resetScore (){
		fullScore = 0;
	}
	public static int getScore (){
		return fullScore;
	}

	private static void fixScore(){
		fullScore -= partialScore;
	
	}

	private static void resetPartialScore(){
		partialScore = 0;
	
	}

	/*
		Esse metodo eh chamado em todo START() de CameraMove, fazendo com que
		obrigatoriamente essa funçao seja chamada, e force a comparaçao dos estagios.
		Caso o estagio que o CameraMove startou seja DIFERENTE do que o estagio usuario acabou de jogar,
		eh um novo estagio e a pontuaçao permanece. Caso seja IGUAL (estagio), o usuario clicou em repetir
		o estagio, logo, a pontuaçao que ele fez anteriormente naquele mesmo estagio e retirada.
	 */
	public static void verifyLevel(string currentLevel){
		if (lastLevel.Equals (currentLevel)) {
			fixScore ();
			resetPartialScore();
		} else {
			lastLevel = currentLevel;
			resetPartialScore();
		}
	}

}